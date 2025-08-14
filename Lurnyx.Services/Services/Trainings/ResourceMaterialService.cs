using AutoMapper;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Resources.Helpers;
using Lurnyx.Services.Helpers;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Resource Materials, including file storage operations.
    /// </summary>
    public class ResourceMaterialService : ServiceBase, IResourceMaterialService
    {
        private readonly IResourceMaterialRepository _repository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ResourceMaterialService(
            IResourceMaterialRepository repository,
            ITopicRepository topicRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IFileStorageService fileStorageService,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _repository = repository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        #region Create

        public async Task AddMultipleResourceMaterialsAsync(List<ResourceMaterialDto> models)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            foreach (var model in models)
            {
                if (model.File == null || model.File.Length == 0)
                {
                    continue;
                }

                await _topicRepository.GetByIdAsync(model.TopicId);

                var material = _mapper.Map<ResourceMaterial>(model);

                var fileUrl = await _fileStorageService.UploadFileAsync(model.File, Enums.FolderName.ResourceMaterials.GetDescription());
                material.FileAccessUrl = fileUrl;
                material.Name = FileHelpers.SanitizeFileName(model.File.FileName);
                material.FileType = Path.GetExtension(model.File.FileName)?.TrimStart('.').ToUpper();
                material.FileSize = (int)model.File.Length;

                await _repository.AddAsync(material, currentUserId);
            }
        }

        public async Task AddMultipleResourceUrlsAsync(int topicId, List<ResourceMaterialDto> resources)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            foreach (var resource in resources)
            {
                if (string.IsNullOrEmpty(resource.FileAccessUrl)) continue;

                var material = new ResourceMaterial
                {
                    TopicId = topicId,
                    Name = !string.IsNullOrEmpty(resource.Name) ? resource.Name : resource.FileAccessUrl,
                    FileAccessUrl = resource.FileAccessUrl,
                    FileType = "URL",
                    Metadata = resource.Metadata,
                    FileSize = null
                };
                await _repository.AddAsync(material, currentUserId);
            }
        }

        #endregion

        #region Delete

        public async Task DeleteMultipleResourceMaterialsAsync(List<int> ids)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            foreach (var id in ids)
            {
                var material = await _repository.GetByIdAsync(id);
                if (material != null)
                {
                    if (!string.IsNullOrEmpty(material.FileAccessUrl))
                    {
                        await _fileStorageService.DeleteFileAsync(material.FileAccessUrl);
                    }
                    await _repository.DeleteAsync(id, currentUserId);
                }
            }
        }
        
        #endregion
    }
}
