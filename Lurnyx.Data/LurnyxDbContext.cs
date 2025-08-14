using Microsoft.EntityFrameworkCore;
using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public partial class LurnyxDBContext : DbContext
    {
        public LurnyxDBContext() { }

        public LurnyxDBContext(DbContextOptions<LurnyxDBContext> options)
            : base(options) { }

        #region DbSets
        // By adding '= null!;', you are telling the compiler that these properties
        // will be initialized by Entity Framework Core and will not be null.
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;

        // For Trainings
        public virtual DbSet<TrainingCategory> TrainingCategories { get; set; } = null!;
        public virtual DbSet<Training> Trainings { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<ResourceMaterial> ResourceMaterials { get; set; } = null!;
        public virtual DbSet<TrainingRating> TrainingRatings { get; set; } = null!;

        // For User Dashboard
        public virtual DbSet<UserTrainingProgress> UserTrainingProgresses { get; set; } = null!;
        public virtual DbSet<UserTopicProgress> UserTopicProgresses { get; set; } = null!;
        public virtual DbSet<UserResourceDownload> UserResourceDownloads { get; set; } = null!;
        #endregion

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Entity Configurations

            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);
                entity.Property(e => e.ProfileImageUrl).HasMaxLength(255);
                entity.Property(e => e.Role).IsRequired().HasConversion<string>().HasMaxLength(50);
            });

            // PasswordResetToken Configuration
            modelBuilder.Entity<PasswordResetToken>(entity =>
            {
                entity.ToTable("PasswordResetToken");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Token).IsUnique();
                entity.Property(e => e.Token).IsRequired().HasMaxLength(255);
                entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(255);
                entity.Property(e => e.ExpirationDate).IsRequired().HasColumnType("datetime2");
            });

            // TrainingCategory Configuration
            modelBuilder.Entity<TrainingCategory>(entity =>
            {
                entity.ToTable("TrainingCategory");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.CoverImageUrl).HasMaxLength(255);
            });

            // Training Configuration
            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("Training");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Difficulty).IsRequired().HasConversion<string>().HasMaxLength(50);
                entity.Property(e => e.CoverImageUrl).HasMaxLength(255);
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.ViewCount).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.IsFeatured).IsRequired().HasDefaultValue(false);
                
                entity.HasIndex(e => e.TrainingCategoryId).HasDatabaseName("idx_training_category");
                entity.HasIndex(e => e.Title).HasDatabaseName("idx_training_title");
                entity.HasOne(d => d.TrainingCategory)
                    .WithMany(p => p.Trainings)
                    .HasForeignKey(d => d.TrainingCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Topic Configuration
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Order).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.CoverImageUrl).HasMaxLength(255);
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.DurationInMinutes).IsRequired();
                entity.Property(e => e.ViewCount).IsRequired().HasDefaultValue(0);
                
                entity.HasIndex(e => e.TrainingId).HasDatabaseName("idx_topic_training");
                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ResourceMaterial Configuration
            modelBuilder.Entity<ResourceMaterial>(entity =>
            {
                entity.ToTable("ResourceMaterial");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FileAccessUrl).HasMaxLength(255).IsRequired();
                entity.Property(e => e.FileType).IsRequired().HasMaxLength(7);
                entity.Property(e => e.Metadata).HasMaxLength(15);
                entity.Property(e => e.FileSize).HasColumnType("integer");
                
                entity.HasIndex(e => e.TopicId).HasDatabaseName("idx_resource_topic");
                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.ResourceMaterials)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // TrainingRating Configuration
            modelBuilder.Entity<TrainingRating>(entity =>
            {
                entity.ToTable("TrainingRating");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.Comments).HasColumnType("text");
                
                entity.HasIndex(e => e.TrainingId).HasDatabaseName("idx_rating_training");
                entity.HasIndex(e => e.CreatedBy).HasDatabaseName("idx_training_rating_user");
                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // UserTrainingProgress Configuration
            modelBuilder.Entity<UserTrainingProgress>(entity =>
            {
                entity.ToTable("UserTrainingProgress");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.CreatedBy, e.TrainingId }).IsUnique();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>().HasMaxLength(50);
                entity.Property(e => e.StartedAt).HasColumnType("datetime2");
                entity.Property(e => e.CompletedAt).HasColumnType("datetime2");
                entity.Property(e => e.LastAccessedAt).IsRequired().HasColumnType("datetime2");
                entity.Property(e => e.ViewCount).IsRequired().HasDefaultValue(0);
                
                entity.HasIndex(e => e.Status).HasDatabaseName("idx_training_progress_status");
                entity.HasIndex(e => e.LastAccessedAt).HasDatabaseName("idx_training_access_time");
                entity.HasOne(d => d.Training)
                    .WithMany(p => p.UserProgresses)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // UserTopicProgress Configuration
            modelBuilder.Entity<UserTopicProgress>(entity =>
            {
                entity.ToTable("UserTopicProgress");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.CreatedBy, e.TopicId }).IsUnique();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>().HasMaxLength(50);
                entity.Property(e => e.StartedAt).HasColumnType("datetime2");
                entity.Property(e => e.CompletedAt).HasColumnType("datetime2");
                entity.Property(e => e.LastAccessedAt).IsRequired().HasColumnType("datetime2");
                entity.Property(e => e.ViewCount).IsRequired().HasDefaultValue(0);
                
                entity.HasIndex(e => e.Status).HasDatabaseName("idx_topic_progress_status");
                entity.HasIndex(e => e.LastAccessedAt).HasDatabaseName("idx_topic_access_time");
                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.UserProgresses)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // UserResourceDownload Configuration
            modelBuilder.Entity<UserResourceDownload>(entity =>
            {
                entity.ToTable("UserResourceDownload");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DownloadCount).IsRequired().HasDefaultValue(1);
                entity.Property(e => e.FirstDownloadedAt).IsRequired().HasColumnType("datetime2");
                entity.Property(e => e.LastDownloadedAt).IsRequired().HasColumnType("datetime2");
                
                entity.HasIndex(e => e.CreatedBy).HasDatabaseName("idx_download_user");
                entity.HasIndex(e => e.LastDownloadedAt).HasDatabaseName("idx_download_time");
                entity.HasOne(d => d.ResourceMaterial)
                    .WithMany()
                    .HasForeignKey(d => d.ResourceMaterialId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            #endregion

            #region Dynamic Auditable Configuration

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Configure BaseAuditableEntity properties
                if (typeof(BaseAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType, entity =>
                    {
                        entity.Property<DateTime>("CreatedAt")
                            .IsRequired().HasColumnType("datetime2");

                        entity.Property<DateTime>("UpdatedAt")
                            .IsRequired().HasColumnType("datetime2");
                            
                        entity.HasOne(typeof(User), "CreatedByUser")
                            .WithMany()
                            .HasForeignKey("CreatedBy")
                            .OnDelete(DeleteBehavior.ClientSetNull);
                            
                        entity.HasOne(typeof(User), "UpdatedByUser")
                            .WithMany()
                            .HasForeignKey("UpdatedBy")
                            .OnDelete(DeleteBehavior.ClientSetNull);
                    });
                }

                // Configure SoftDeletableEntity properties
                if (typeof(SoftDeletableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType, entity =>
                    {
                        entity.Property<DateTime?>("DeletedAt").HasColumnType("datetime2");
                        entity.HasOne(typeof(User), "DeletedByUser")
                            .WithMany()
                            .HasForeignKey("DeletedBy")
                            .OnDelete(DeleteBehavior.ClientSetNull);
                    });
                    
                }
            }

            #endregion

            DataSeeder.Seed(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }
    }
}