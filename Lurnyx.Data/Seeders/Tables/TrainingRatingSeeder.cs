using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public static class TrainingRatingSeeder
    {
        public static List<TrainingRating> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();

            var ratings = new List<TrainingRating> {
          new TrainingRating {
              Id = 1,
              Rating = 5,
              Comments = "Excellent course for beginners! The Python examples were clear and practical.",
              TrainingId = 1,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 2,
              Rating = 4,
              Comments = "Great content, but some exercises could be more challenging.",
              TrainingId = 1,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 3,
              Rating = 5,
              Comments = "Perfect introduction to Java OOP concepts. The instructor explains complex topics simply.",
              TrainingId = 2,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 4,
              Rating = 3,
              Comments = "Good material but the pace was too fast in some sections.",
              TrainingId = 2,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 5,
              Rating = 5,
              Comments = "Best web development course I've taken! Loved the hands-on projects.",
              TrainingId = 3,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 6,
              Rating = 4,
              Comments = "Very comprehensive, though the CSS module could use more modern techniques.",
              TrainingId = 3,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 7,
              Rating = 5,
              Comments = "ASP.NET Core explained perfectly. The MVC examples were especially helpful.",
              TrainingId = 4,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 8,
              Rating = 4,
              Comments = "Great course, but would benefit from more real-world application examples.",
              TrainingId = 4,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 9,
              Rating = 5,
              Comments = "Pandas is now my favorite data analysis tool thanks to this course!",
              TrainingId = 5,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 10,
              Rating = 4,
              Comments = "Excellent content, though some datasets were too simplistic.",
              TrainingId = 5,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 11,
              Rating = 5,
              Comments = "Flutter makes mobile development so much easier. Great tutorials!",
              TrainingId = 6,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 12,
              Rating = 3,
              Comments = "Good introduction but needs more coverage of state management solutions.",
              TrainingId = 6,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 13,
              Rating = 4,
              Comments = "Solid ML foundations course. The regression section was particularly strong.",
              TrainingId = 7,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 14,
              Rating = 2,
              Comments = "Some concepts weren't explained clearly enough for beginners.",
              TrainingId = 7,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 15,
              Rating = 5,
              Comments = "SQL has never been this easy to understand. Perfect for database beginners!",
              TrainingId = 8,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 16,
              Rating = 4,
              Comments = "Good coverage of basics, would love an advanced sequel course.",
              TrainingId = 8,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 17,
              Rating = 5,
              Comments = "Node.js finally makes sense! The async programming explanation was gold.",
              TrainingId = 9,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 18,
              Rating = 3,
              Comments = "Decent but could use more practical API building exercises.",
              TrainingId = 9,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 19,
              Rating = 5,
              Comments = "Git is no longer scary! The branching/merging examples were lifesavers.",
              TrainingId = 10,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 20,
              Rating = 4,
              Comments = "Very useful, though some advanced GitHub features weren't covered.",
              TrainingId = 10,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 21,
              Rating = 5,
              Comments = "React clicked for me after this course. The state management section was perfect.",
              TrainingId = 11,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 22,
              Rating = 4,
              Comments = "Great introduction, but needs more real-world project examples.",
              TrainingId = 11,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 23,
              Rating = 5,
              Comments = "DevOps concepts finally made clear. The CI/CD pipeline walkthrough was excellent.",
              TrainingId = 12,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 24,
              Rating = 3,
              Comments = "Good overview but too theoretical. Needs more hands-on labs.",
              TrainingId = 12,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 25,
              Rating = 4,
              Comments = "UX principles well explained. The wireframing exercises were particularly valuable.",
              TrainingId = 13,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 26,
              Rating = 5,
              Comments = "Essential cybersecurity knowledge presented in an accessible way.",
              TrainingId = 14,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 27,
              Rating = 4,
              Comments = "AWS basics covered well, though some newer services weren't included.",
              TrainingId = 15,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          },
          new TrainingRating {
              Id = 28,
              Rating = 5,
              Comments = "Advanced topics made approachable. The deep learning intro was brilliant.",
              TrainingId = 17,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 5,
              UpdatedBy = 5
          },
          new TrainingRating {
              Id = 29,
              Rating = 4,
              Comments = "Great comparison of native vs hybrid approaches. More code examples would help.",
              TrainingId = 18,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 3,
              UpdatedBy = 3
          },
          new TrainingRating {
              Id = 30,
              Rating = 5,
              Comments = "Machine learning with Python finally makes sense! The classification examples were perfect.",
              TrainingId = 19,
              CreatedAt = now,
              UpdatedAt = now,
              CreatedBy = 4,
              UpdatedBy = 4
          }
      };
            return ratings;
        }
    }
}
