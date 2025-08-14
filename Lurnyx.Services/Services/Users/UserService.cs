using AutoMapper;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Resources.Helpers;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.Manager;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Users, aligned with the generic repository and async patterns.
    /// </summary>
    public class UserService : ServiceBase,IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository repository,
            IPasswordResetTokenRepository tokenRepository,
            IUnitOfWork unitOfWork,
            IFileStorageService fileStorageService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _repository = repository;
            _tokenRepository = tokenRepository;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task RegisterUserAsync(UserDto model)
        {
            if (await _repository.ExistsAsync(u => u.Email == model.Email))
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }

            var user = _mapper.Map<User>(model);
            user.Password = PasswordManager.HashPassword(model.Password);
            user.Role = Enums.UserRole.USER;

            await _repository.AddAsync(user, 1); // Temporarily use 1 as creator
            await _unitOfWork.SaveChangesAsync();

            user.CreatedBy = user.Id;
            user.UpdatedBy = user.Id;
            _repository.Update(user, user.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddNewUserAsync(UserDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            if (await _repository.ExistsAsync(u => u.Email == model.Email))
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }

            var user = _mapper.Map<User>(model);
            user.Password = PasswordManager.HashPassword("@deFaultPass12");

            await _repository.AddAsync(user, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDto> GetCurrentUserDetailsAsync()
        {
            var user = await _repository.GetByIdAsync(GetCurrentUserId());
            if (user == null)
            {
                throw new InvalidOperationException(Resources.Messages.Errors.UserDoesNotExist);
            }

            return _mapper.Map<UserDto>(user);
        }
        #endregion

        #region Read

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user != null && PasswordManager.VerifyPassword(password, user.Password))
            {
                return _mapper.Map<User>(user);
            }

            return null;
        }

        public async Task<PaginatedList<UserDto>> GetPaginatedUsersAsync(int pageNumber, int pageSize, string searchQuery, Enums.UserRole roleFilter)
        {
            var paginatedUsers = await _repository.GetPaginatedAsync(pageNumber, pageSize, searchQuery, roleFilter);
            var userViewModels = _mapper.Map<List<UserDto>>(paginatedUsers.Items);

            return new PaginatedList<UserDto>(userViewModels, paginatedUsers.TotalCount, paginatedUsers.PageNumber, pageSize);
        }


        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        #endregion

        #region Update

        public async Task UpdateUserAsync(UserDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var user = await _repository.GetByIdAsync(model.Id);
            _mapper.Map(model, user);

            _repository.Update(user, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user == null)
            {
                return string.Empty; // Do not reveal that the user does not exist.
            }

            var token = Guid.NewGuid().ToString("N");
            var passwordResetToken = new PasswordResetToken
            {
                UserEmail = user.Email,
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddHours(1)
            };

            await _tokenRepository.AddAsync(passwordResetToken, user.Id);
            await _unitOfWork.SaveChangesAsync();

            return token;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            var passwordResetToken = await _tokenRepository.GetByTokenAsync(token);
            if (passwordResetToken == null)
            {
                return false; // Token is invalid, expired, or already used.
            }

            var user = await _repository.GetByEmailAsync(passwordResetToken.UserEmail);
            if (user == null)
            {
                return false;
            }

            user.Password = PasswordManager.HashPassword(newPassword);
            _repository.Update(user, user.Id);

            await _tokenRepository.DeleteAsync(passwordResetToken.Id, user.Id); // "Use" the token by soft-deleting it.
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<User> UpdateCurrentUserProfileAsync(UserDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var userToUpdate = await _repository.GetByIdAsync(currentUserId);
            if (userToUpdate == null)
            {
                throw new InvalidOperationException(Resources.Messages.Errors.UserDoesNotExist);
            }

            userToUpdate.FirstName = model.FirstName ?? userToUpdate.FirstName;
            userToUpdate.LastName = model.LastName ?? userToUpdate.LastName;
            userToUpdate.Email = model.Email ?? userToUpdate.Email;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var oldImageUrl = userToUpdate.ProfileImageUrl;

                var newImageUrl = await _fileStorageService.UploadImageAsync(
                    model.ImageFile, Enums.FolderName.UserProfileImages.GetDescription());

                userToUpdate.ProfileImageUrl = newImageUrl;

                if (!string.IsNullOrEmpty(oldImageUrl))
                {
                    await _fileStorageService.DeleteImageAsync(oldImageUrl);
                }
            }

            _repository.Update(userToUpdate, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            return userToUpdate;
        }

        public async Task<bool> ChangePasswordAsync(string currentPassword, string newPassword)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var user = await _repository.GetByIdAsync(currentUserId);
            if (user == null)
            {
                return false;
            }

            if (!PasswordManager.VerifyPassword(currentPassword, user.Password))
            {
                return false;
            }

            user.Password = PasswordManager.HashPassword(newPassword);
            _repository.Update(user, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Delete

        public async Task DeleteUserAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var userToDelete = await _repository.GetByIdAsync(id);
            if (userToDelete == null)
            {
                throw new InvalidOperationException(Resources.Messages.Errors.UserDoesNotExist);
            }

            var imageUrlToDelete = userToDelete.ProfileImageUrl;

            await _repository.DeleteAsync(id, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            if (!string.IsNullOrEmpty(imageUrlToDelete))
            {
                await _fileStorageService.DeleteImageAsync(imageUrlToDelete);
            }
        }
        
        #endregion
    }
}
