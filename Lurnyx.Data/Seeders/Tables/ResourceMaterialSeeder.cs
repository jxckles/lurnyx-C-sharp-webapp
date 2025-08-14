using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public static class ResourceMaterialSeeder
    {
        public static List<ResourceMaterial> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            
            var resources = new List<ResourceMaterial> {
          new ResourceMaterial {
              Id = 1,
              Name = "Introduction to Computers & Programming",
              Metadata = "PDF, 2 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-1-Introduction%20to%20Computers%20&%20Programming.pdf",
              FileType = "PDF",
              FileSize = 350,
              TopicId = 1,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 2,
              Name = "Variables & Data Types (Python PDF)",
              Metadata = "PDF, ~10 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-2-Variables%20&%20Data%20Types%20(Python%20PDF).pdf",
              FileType = "PDF",
              FileSize = 200,
              TopicId = 2,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 3,
              Name = "Control Structures",
              Metadata = "PDF, ~15 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-3-Control%20Structures.pdf",
              FileType = "PDF",
              FileSize = 600,
              TopicId = 6,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 4,
              Name = "Functions & Modular Programming (BTU PDF)",
              Metadata = "PDF, ~8 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-4-Functions%20&%20Modular%20Programming%20(BTU%20PDF).pdf",
              FileType = "PDF",
              FileSize = 300,
              TopicId = 9,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 5,
              Name = "Error Handling & Defensive Programming (BYU PDF)",
              Metadata = "PDF, ~12 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-5-Error%20Handling%20&%20Defensive%20Programming%20(BYU%20PDF).pdf",
              FileType = "PDF",
              FileSize = 400,
              TopicId = 13,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 6,
              Name = "Classes & Objects (GMU CS slides)",
              Metadata = "PDF, ~15 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-6-Classes%20&%20Objects%20(GMU%20CS%20slides).pdf",
              FileType = "PDF",
              FileSize = 512,
              TopicId = 17,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 7,
              Name = "Inheritance & Polymorphism (SMU Lecture)",
              Metadata = "PDF, ~20 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-7-Inheritance%20&%20Polymorphism%20(SMU%20Lecture).pdf",
              FileType = "PDF",
              FileSize = 1024,
              TopicId = 20,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 8,
              Name = "Abstract Classes & Interfaces (UMD slides)",
              Metadata = "PDF, ~49 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-8-Abstract%20Classes%20&%20Interfaces%20(UMD%20slides).pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 22,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 9,
              Name = "HTML Tutorial (Tutorialspoint)",
              Metadata = "PDF, ~200 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-9-HTML%20Tutorial%20(Tutorialspoint).pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 25,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 10,
              Name = "CSS Styling Techniques (Stanford CS)",
              Metadata = "PDF, ~30 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-10-CSS%20Styling%20Techniques%20(Stanford%20CS).pdf",
              FileType = "PDF",
              FileSize = 800,
              TopicId = 28,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 11,
              Name = "JavaScript Fundamentals - TutorialsPoint Guide",
              Metadata = "PDF, ~250 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-11-JavaScript%20Fundamentals%20%20(TutorialsPoint%20Guide).pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 31,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 12,
              Name = "JavaScript Handbook - Edu-9",
              Metadata = "PDF, ~150 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-12-JavaScript%20Handbook.pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 34,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 13,
              Name = "JavaScript for Absolute Beginners - Pepa PDF",
              Metadata = "PDF, ~80 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-13-JavaScript%20for%20Absolute%20Beginners%20(Pepa%20PDF).pdf",
              FileType = "PDF",
              FileSize = 7382, // Missing in original data
              TopicId = 37,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 14,
              Name = "Getting Started with Programming - Dave Gray Video",
              Metadata = "Video, ~15 min",
              FileAccessUrl = "https://www.youtube.com/watch?v=8Ze0b2VvwHQ",
              FileType = "URL",
              FileSize = 0, // Video size not provided
              TopicId = 43,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 15,
              Name = "Getting Started with ASP.NET Core - Tutorialspoint PDF",
              Metadata = "PDF, ~150 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-15-Getting%20Started%20with%20ASP.NET%20Core%20(Tutorialspoint%20PDF).pdf",
              FileType = "PDF",
              FileSize = 250,
              TopicId = 45,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 16,
              Name = "Understanding MVC (TutorialsPoint PDF)",
              Metadata = "PDF, ~40 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-16-Understanding%20MVC%20(TutorialsPoint%20PDF).pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 66,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 17,
              Name = "Getting Started - MVC Architecture (CSU Ohio PDF)",
              Metadata = "PDF, ~10 pages",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-17-Getting%20Started%20MVC%20Architecture%20(CSU%20Ohio%20PDF).pdf",
              FileType = "PDF",
              FileSize = 200,
              TopicId = 69,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new ResourceMaterial {
              Id = 18,
              Name = "Working with Data - IBM Data Analyst Course (YouTube video)",
              Metadata = "Video, ~1 hr",
              FileAccessUrl = "https://www.youtube.com/watch?v=1PAy6d16ADQ",
              FileType = "URL",
              FileSize = 0, // Video size not provided
              TopicId = 72,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new ResourceMaterial {
              Id = 19,
              Name = "Introduction to Pandas (PDF Slides)",
              Metadata = "PPT, ~30 slides",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-19-Introduction%20to%20Pandas%20(PDF%20Slides).pdf",
              FileType = "PDF",
              FileSize = 0, // Missing in original data
              TopicId = 81,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 2,
              UpdatedBy = 2
          },
          new ResourceMaterial {
              Id = 20,
              Name = "Pandas Cheat Sheet - Quick Reference",
              Metadata = "PDF, 1 page",
              FileAccessUrl = "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-20-Pandas%20Cheat%20Sheet.pdf",
              FileType = "PDF",
              FileSize = 150,
              TopicId = 84,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          }
      };
            return resources;
        }
    }
}
