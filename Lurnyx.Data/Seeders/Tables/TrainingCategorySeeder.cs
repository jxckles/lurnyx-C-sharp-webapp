using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public static class TrainingCategorySeeder
    {
        public static List<TrainingCategory> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();

            var categories = new List<TrainingCategory> {
          new TrainingCategory {
              Id = 1,
              Name = "Programming",
              Description = "Master the fundamentals of programming through this comprehensive beginner's course. Learn essential concepts like variables, loops, conditionals, and functions while working with practical examples. Perfect for absolute beginners, this training establishes a solid foundation for all future coding endeavors.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/55b96c18-6574-41db-b0f4-c2206f814f64.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 2,
              Name = "Website Development",
              Description = "Explore the core technologies of modern web development, including front-end frameworks, back-end architectures, and database integration. Build responsive, scalable web applications from the ground up.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/22bc8ebef610eb881071e1a7007a7a80.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 3,
              Name = "Cybersecurity",
              Description = "Dive into the principles of securing digital systems, networks, and data. Learn about encryption, threat detection, ethical hacking, and best practices for protecting against cyber threats.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/cyber-security-firewall-interface-protection-concept-businesswoman-protecting-herself-from.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 4,
              Name = "Data Structures & Algorithms",
              Description = "Understand the building blocks of efficient software development. Master arrays, linked lists, trees, sorting, and searching algorithms to optimize performance in your applications.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/c7fc020567f7bd15c1ac7dda928dda52.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 5,
              Name = "Database Systems",
              Description = "Learn to design, implement, and manage relational and NoSQL databases. Explore SQL queries, indexing, transactions, and data modeling for real-world applications.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/document-management-system-or-dms-setup-by-it-consultant-with-modern-computer-are-searching.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 6,
              Name = "Cloud Computing",
              Description = "Discover cloud platforms like AWS, Azure, and Google Cloud. Learn to deploy, scale, and manage applications in the cloud while exploring serverless architectures and DevOps practices.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/360_F_889307264_4Uc7TdNpOOg7kOdd0wpguhtpO5qnida0.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 7,
              Name = "Machine Learning & AI",
              Description = "Introduction to artificial intelligence and machine learning concepts. Explore neural networks, data preprocessing, model training, and real-world AI applications.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/ai-machine-learning-hands-of-robot-and-human-touching-on-big-data-network-connection.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 8,
              Name = "Software Engineering Practices",
              Description = "Master industry-standard methodologies like Agile, Scrum, and CI/CD. Learn version control (Git), testing frameworks, and software design patterns for scalable development.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/software-engineering-practices-2.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 9,
              Name = "Networking & Systems",
              Description = "Grasp the fundamentals of computer networks, protocols (TCP/IP), and system administration. Configure routers, troubleshoot connectivity, and understand cloud networking.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/depositphotos_24812691-stock-photo-network-cables-in-a-data.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 10,
              Name = "Embedded Systems & IoT",
              Description = "Explore the intersection of hardware and software in embedded systems. Learn microcontroller programming, sensor integration, and IoT device communication for smart applications.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/embedded-systems-engineering-1800x500-hero.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 11,
              Name = "Game Development",
              Description = "Build interactive games using Unity with C# scripting. Cover game physics, 3D modeling integration, multiplayer networking, and performance optimization for PC/mobile platforms.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/360_F_919837931_ArVwtxgniexGWbCO35L4xg1eNw1r1i8K.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 12,
              Name = "Quantum Computing Basics",
              Description = "Explore the future of computing with quantum algorithms. Learn Q#, quantum gates, and hybrid quantum-classical programming using Microsoft's Quantum Development Kit.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/image.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 13,
              Name = "Blockchain Development",
              Description = "Develop smart contracts and decentralized apps (DApps) with C# and .NET tools like Nethermind. Understand Ethereum, Solidity integration, and blockchain security principles.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/3d-rendering-blockchain-technology_23-2151480176.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 14,
              Name = "AR/VR Development",
              Description = "Create immersive augmented/virtual reality experiences with C# in Unity or Unreal Engine. Master 3D interaction, spatial mapping, and cross-platform deployment for headsets like HoloLens and Oculus.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/amazed-man-interacting-with-virtual-reality_251859-3802.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new TrainingCategory {
              Id = 15,
              Name = "Mobile Development",
              Description = "Master cross-platform mobile app development using C# and .NET technologies like Xamarin and .NET MAUI. Learn to build, test, and deploy iOS and Android apps with shared codebases, integrating REST APIs, SQLite databases, and cloud services. Explore UI/UX design principles, performance optimization, and platform-specific features to create scalable, production-ready applications.",
              CoverImageUrl = "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/mobile-app-development-frameworks%20Banner.webp",
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          }
      };
            return categories;
        }
    }
}
