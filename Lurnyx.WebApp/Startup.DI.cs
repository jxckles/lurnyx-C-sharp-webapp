using Lurnyx.Data;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Repositories;
using Lurnyx.Data.Repositories.Users;
using Lurnyx.Infrastructure.Services;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.Interfaces.Users;
using Lurnyx.Services.Services;
using Lurnyx.Services.Services.Users;
using Lurnyx.WebApp.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Lurnyx.WebApp
{
    // Other services configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configures the other services.
        /// </summary>
        private void ConfigureOtherServices()
        {
            // Framework
            this._services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            this._services.AddScoped<TokenProvider>();
            this._services.TryAddSingleton<TokenProviderOptionsFactory>();
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            this._services.AddScoped<IUserRepository, UserRepository>();
            this._services.AddScoped<ITrainingCategoryRepository, TrainingCategoryRepository>();
            this._services.AddScoped<ITrainingRepository, TrainingRepository>();
            this._services.AddScoped<ITopicRepository, TopicRepository>();
            this._services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>(); 
            this._services.AddScoped<IResourceMaterialRepository, ResourceMaterialRepository>();
            this._services.AddScoped<ITrainingRatingRepository, TrainingRatingRepository>();
            this._services.AddScoped<IUserTrainingProgressRepository, UserTrainingProgressRepository>();
            this._services.AddScoped<IUserTopicProgressRepository, UserTopicProgressRepository>();
            this._services.AddScoped<IUserResourceDownloadRepository, UserResourceDownloadRepository>();

            // Application Services (Business Logic)
            this._services.AddScoped<IUserService, UserService>();
            this._services.AddScoped<ITrainingCategoryService, TrainingCategoryService>();
            this._services.AddScoped<ITrainingService, TrainingService>();
            this._services.AddScoped<ITopicService, TopicService>();
            this._services.AddScoped<IResourceMaterialService, ResourceMaterialService>();
            this._services.AddScoped<ITrainingRatingService, TrainingRatingService>();
            this._services.AddScoped<IUserDashboardService, UserDashboardService>();
            this._services.AddScoped<IUserTrainingProgressService, UserTrainingProgressService>();
            this._services.AddScoped<IUserTopicProgressService, UserTopicProgressService>();
            this._services.AddScoped<IUserResourceDownloadService, UserResourceDownloadService>();

            // Infrastructure Services (External Concerns)
            this._services.AddScoped<IEmailService, EmailService>();
            this._services.AddScoped<IFileStorageService, SupabaseStorageService>();

            // Manager Class
            this._services.AddScoped<SignInManager>();

            this._services.AddHttpClient();
        }
    }
}
