using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public static class TopicSeeder
    {
        public static List<Topic> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            
            var topics = new List<Topic> {
          // Programming Fundamentals with Python (TrainingId = 1)
          new Topic {
              Id = 1,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-1-What%20is%20Programming.jpg",
              Title = "What is Programming?",
              Description = "Understand the purpose and fundamentals of programming, including what it means to give instructions to a computer.",
              DurationInMinutes = 25,
              TrainingId = 1,
              ViewCount = 87,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new Topic {
              Id = 2,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-2-Variables%20and%20Data%20Types.png",
              Title = "Variables & Data Types",
              Description = "Learn how to store and manipulate data in your programs using different types like integers, strings, and booleans.",
              DurationInMinutes = 34,
              TrainingId = 1,
              ViewCount = 140,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Object-Oriented Java Programming (TrainingId = 2)
          new Topic {
              Id = 6,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-6-Classes%20and%20Objects.jpg",
              Title = "Classes and Objects",
              Description = "Understand the core of object-oriented design by creating and using classes and objects in Java.",
              DurationInMinutes = 35,
              TrainingId = 2,
              ViewCount = 93,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Web Development Essentials (TrainingId = 3)
          new Topic {
              Id = 9,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-9-HTML%20Basics.jpg",
              Title = "HTML Basics",
              Description = "Learn how to structure web content using semantic HTML tags and attributes.",
              DurationInMinutes = 25,
              TrainingId = 3,
              ViewCount = 54,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Introduction to ASP.NET Core (TrainingId = 4)
          new Topic {
              Id = 13,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-13-Understanding%20MVC.jpg",
              Title = "Understanding MVC",
              Description = "Learn the Model-View-Controller pattern and how ASP.NET Core applies it in web development.",
              DurationInMinutes = 60,
              TrainingId = 4,
              ViewCount = 129,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Data Analysis with Python & Pandas (TrainingId = 5)
          new Topic {
              Id = 17,
              Order = 3,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-17-Data%20Visualization.webp",
              Title = "Data Visualization",
              Description = "Create meaningful visualizations with matplotlib and seaborn.",
              DurationInMinutes = 50,
              TrainingId = 5,
              ViewCount = 200,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Mobile App Development with Flutter (TrainingId = 6)
          new Topic {
              Id = 20,
              Order = 3,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-20-State%20Management.png",
              Title = "State Management",
              Description = "Manage UI state using Provider or Riverpod for scalable app architecture.",
              DurationInMinutes = 40,
              TrainingId = 6,
              ViewCount = 177,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Machine Learning Foundations (TrainingId = 7)
          new Topic {
              Id = 22,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-22-Model%20Evaluation.png",
              Title = "Model Evaluation",
              Description = "Learn accuracy, precision, recall, and confusion matrix fundamentals.",
              DurationInMinutes = 35,
              TrainingId = 7,
              ViewCount = 59,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Introduction to SQL & Databases (TrainingId = 8)
          new Topic {
              Id = 25,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-25-Joins%20and%20Relationships.png",
              Title = "Joins and Relationships",
              Description = "Combine data across tables using inner, outer, and self joins.",
              DurationInMinutes = 40,
              TrainingId = 8,
              ViewCount = 133,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Introduction to Node.js (TrainingId = 9)
          new Topic {
              Id = 28,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-28-Building%20RESTful%20APIs.png",
              Title = "Building RESTful APIs",
              Description = "Design scalable web APIs using Express and middleware.",
              DurationInMinutes = 45,
              TrainingId = 9,
              ViewCount = 104,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Git & Version Control Essentials (TrainingId = 10)
          new Topic {
              Id = 31,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-31-Branching%20and%20Merging.webp",
              Title = "Branching and Merging",
              Description = "Work with branches, resolve merge conflicts, and understand version history.",
              DurationInMinutes = 35,
              TrainingId = 10,
              ViewCount = 167,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Introduction to React.js (TrainingId = 11)
          new Topic {
              Id = 34,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-34-React%20State%20and%20Props.png",
              Title = "React State and Props",
              Description = "Understand data flow in React using props and manage local state.",
              DurationInMinutes = 35,
              TrainingId = 11,
              ViewCount = 161,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // DevOps Fundamentals (TrainingId = 12)
          new Topic {
              Id = 37,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-37-Docker%20Containers.jpg",
              Title = "Docker Containers",
              Description = "Understand containerization with Docker and how it simplifies deployment.",
              DurationInMinutes = 40,
              TrainingId = 12,
              ViewCount = 128,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Cybersecurity Basics (TrainingId = 14)
          new Topic {
              Id = 43,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-43-Authentication%20and%20Encryption.png",
              Title = "Authentication and Encryption",
              Description = "Learn about password protocols, 2FA, and data encryption methods.",
              DurationInMinutes = 35,
              TrainingId = 14,
              ViewCount = 128,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Cloud Computing with AWS (TrainingId = 15)
          new Topic {
              Id = 45,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-45-AWS%20Core%20Services.webp",
              Title = "AWS Core Services",
              Description = "Learn about EC2, S3, and RDS with use case demonstrations.",
              DurationInMinutes = 40,
              TrainingId = 15,
              ViewCount = 119,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Advanced Data Science (TrainingId = 17)
          new Topic {
              Id = 50,
              Order = 3,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-50-Deep%20Learning%20Introduction.jpg",
              Title = "Deep Learning Introduction",
              Description = "Learn the basics of neural networks and deep learning concepts.",
              DurationInMinutes = 50,
              TrainingId = 17,
              ViewCount = 120,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Cross-Platform Mobile Development (TrainingId = 18)
          new Topic {
              Id = 53,
              Order = 3,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-53-App%20Deployment.png",
              Title = "App Deployment",
              Description = "Learn how to publish apps to the App Store and Google Play.",
              DurationInMinutes = 40,
              TrainingId = 18,
              ViewCount = 125,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Practical Machine Learning with Python (TrainingId = 19)
          new Topic {
              Id = 56,
              Order = 3,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-56-Unsupervised%20Learning.jpg",
              Title = "Unsupervised Learning",
              Description = "Explore clustering methods like K-Means and DBSCAN.",
              DurationInMinutes = 45,
              TrainingId = 19,
              ViewCount = 132,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Algorithms and Problem Solving (TrainingId = 21)
          new Topic {
              Id = 60,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-60-Sorting%20Algorithms.webp",
              Title = "Sorting Algorithms",
              Description = "Learn bubble, merge, and quick sort with practical coding examples.",
              DurationInMinutes = 35,
              TrainingId = 21,
              ViewCount = 126,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Relational Database Systems (TrainingId = 22)
          new Topic {
              Id = 63,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-63-Normalization%20Rules.jpg",
              Title = "Normalization Rules",
              Description = "Apply normalization techniques to reduce data redundancy.",
              DurationInMinutes = 30,
              TrainingId = 22,
              ViewCount = 109,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Agile Software Development (TrainingId = 23)
          new Topic {
              Id = 66,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-66-Scrum%20Framework.webp",
              Title = "Scrum Framework",
              Description = "Understand the roles, ceremonies, and artifacts in Scrum.",
              DurationInMinutes = 30,
              TrainingId = 23,
              ViewCount = 110,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Introduction to Computer Networks (TrainingId = 24)
          new Topic {
              Id = 69,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-69-OSI%20Model.png",
              Title = "OSI Model",
              Description = "Study the 7-layer OSI model and functions of each layer.",
              DurationInMinutes = 35,
              TrainingId = 24,
              ViewCount = 116,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // IoT and Embedded Systems (TrainingId = 25)
          new Topic {
              Id = 72,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-72-Microcontroller%20Basics.webp",
              Title = "Microcontroller Basics",
              Description = "Get hands-on with devices like Arduino and ESP32.",
              DurationInMinutes = 35,
              TrainingId = 25,
              ViewCount = 111,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // Game Development with Unity (TrainingId = 26)
          new Topic {
              Id = 76,
              Order = 2,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-76-Player%20Input%20and%20Movement.jpg",
              Title = "Player Input and Movement",
              Description = "Implement controls for character movement and actions.",
              DurationInMinutes = 40,
              TrainingId = 26,
              ViewCount = 115,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },

          // Quantum Computing Basics (TrainingId = 27)
          new Topic {
              Id = 78,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-78-Qubits%20and%20Superposition.png",
              Title = "Qubits and Superposition",
              Description = "Understand quantum states and how qubits differ from bits.",
              DurationInMinutes = 30,
              TrainingId = 27,
              ViewCount = 88,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },

          // Blockchain App Development (TrainingId = 28)
          new Topic {
              Id = 81,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-81-Smart%20Contract%20Design.jpg",
              Title = "Smart Contract Design",
              Description = "Build reusable and secure smart contracts using Solidity.",
              DurationInMinutes = 40,
              TrainingId = 28,
              ViewCount = 118,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },

          // AR/VR Development Fundamentals (TrainingId = 29)
          new Topic {
              Id = 84,
              Order = 1,
              CoverImageUrl = "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-84-Unity%20XR%20Setup.png",
              Title = "Unity XR Setup",
              Description = "Set up Unity XR plugins for AR/VR development.",
              DurationInMinutes = 35,
              TrainingId = 29,
              ViewCount = 108,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          }
      };
            return topics;
        }
    }
}
