using AutoMapper;
using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.WebApp
{
    // AutoMapper configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configure auto mapper
        /// </summary>
        private void ConfigureAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            this._services.AddSingleton(sp => mapperConfiguration.CreateMapper());
        }

        private class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration()
            {
                // User Mappings
                CreateMap<UserDto, User>()
                    .ForMember(dest => dest.Password, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.DeletedAt, opt => opt.Ignore());
                CreateMap<User, UserDto>()
                    .ForMember(dest => dest.Password, opt => opt.Ignore())
                    .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());

                // Training Category Mappings
                CreateMap<TrainingCategoryDto, TrainingCategory>()
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.CoverImageUrl, opt => opt.Ignore());
                CreateMap<TrainingCategory, TrainingCategoryDto>();

                // Training Mappings
                CreateMap<TrainingDto, Training>()
                   .ForMember(dest => dest.CoverImageUrl, opt => opt.Ignore())
                   .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                   .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                   .ForMember(dest => dest.UpdatedByUser, opt => opt.Ignore())
                   .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                   .ForMember(dest => dest.TrainingCategory, opt => opt.Ignore())
                   .ForMember(dest => dest.Topics, opt => opt.Ignore());
                CreateMap<Training, TrainingDto>()
                    .ForMember(dest => dest.Author,
                        opt => opt.MapFrom(src => (src.CreatedByUser != null) ? $"{src.CreatedByUser.LastName}, {src.CreatedByUser.FirstName}" : "N/A"))
                    .ForMember(dest => dest.CategoryList, opt => opt.Ignore());

                // Topic Mappings
                CreateMap<TopicDto, Topic>()
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.CoverImageUrl, opt => opt.Ignore())
                    .ForMember(dest => dest.ResourceMaterials, opt => opt.Ignore());
                CreateMap<Topic, TopicDto>();

                // Resource Material Mappings
                CreateMap<ResourceMaterial, ResourceMaterialDto>().ReverseMap();

                // Training Rating Mappings
                CreateMap<TrainingRating, TrainingRatingDto>();
                CreateMap<TrainingRatingDto, TrainingRating>()
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

                // UserDashboard Mappings
                CreateMap<Training, SuggestedTrainingDto>()
                    .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings != null && src.Ratings.Any() ? src.Ratings.Average(r => r.Rating) : 0.0))
                    .ForMember(dest => dest.ReviewCount, opt => opt.MapFrom(src => src.Ratings != null ? src.Ratings.Count : 0))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.CoverImageUrl));

            }
        }
    }
}
