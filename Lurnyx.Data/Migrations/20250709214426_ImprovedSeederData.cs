using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class ImprovedSeederData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "Name", "TopicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-1-Introduction%20to%20Computers%20&%20Programming.pdf", 350, "PDF, 2 pages", "Introduction to Computers & Programming", 1, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-2-Variables%20&%20Data%20Types%20(Python%20PDF).pdf", 200, "PDF", "PDF, ~10 pages", "Variables & Data Types (Python PDF)", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-1-What%20is%20Programming.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), "Understand the purpose and fundamentals of programming, including what it means to give instructions to a computer.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 87 });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "DurationInMinutes", "Title", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-2-Variables%20and%20Data%20Types.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, "Learn how to store and manipulate data in your programs using different types like integers, strings, and booleans.", 34, "Variables & Data Types", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 140 });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "DurationInMinutes", "Order", "Title", "TrainingId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 6, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-6-Classes%20and%20Objects.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Understand the core of object-oriented design by creating and using classes and objects in Java.", 35, 1, "Classes and Objects", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 93 },
                    { 9, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-9-HTML%20Basics.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Learn how to structure web content using semantic HTML tags and attributes.", 25, 1, "HTML Basics", 3, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 54 },
                    { 13, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-13-Understanding%20MVC.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Learn the Model-View-Controller pattern and how ASP.NET Core applies it in web development.", 60, 2, "Understanding MVC", 4, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 129 },
                    { 17, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-17-Data%20Visualization.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Create meaningful visualizations with matplotlib and seaborn.", 50, 3, "Data Visualization", 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 200 },
                    { 20, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-20-State%20Management.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Manage UI state using Provider or Riverpod for scalable app architecture.", 40, 3, "State Management", 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 177 }
                });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Title", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-1-Programming%20Fundamentals%20with%20Python.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), "Start your coding journey with Python, one of the most beginner-friendly languages. This course covers basic syntax, data structures, and problem-solving techniques through hands-on exercises. By the end, you'll be able to write simple programs and understand core programming principles.", "Programming Fundamentals with Python", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 245 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-2-Object-Oriented%20Java%20Programming.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, "Learn Java by exploring the core principles of object-oriented programming. This course includes classes, inheritance, interfaces, and abstraction through interactive coding examples.", "INTERMEDIATE", "Object-Oriented Java Programming", 1, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 198 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "IsFeatured", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-3-Web%20Development%20Essentials.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, "Discover how to build beautiful and responsive websites using HTML, CSS, and JavaScript. This course guides you through layout techniques, styling, DOM manipulation, and project-based learning.", "BEGINNER", true, 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 312 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Title", "TrainingCategoryId", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-4-Introduction%20to%20ASP.NET%20Core.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), "Build robust web applications using ASP.NET Core and the MVC architecture. This course covers routing, controllers, views, and working with databases through Entity Framework.", "Introduction to ASP.NET Core", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 175 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 8, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-8-Introduction%20to%20SQL%20&%20Databases.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Explore the fundamentals of database design and querying using SQL. This course walks you through data retrieval, joins, filtering, and table relationships.", "BEGINNER", "Introduction to SQL & Databases", 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 137 },
                    { 9, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-9-Introduction%20to%20Node%20js.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Discover how to build scalable back-end applications using Node.js and Express. This course introduces asynchronous programming, RESTful APIs, and database integration with MongoDB.", "INTERMEDIATE", "Introduction to Node.js", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 162 },
                    { 10, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-10-Git%20&%20Version%20Control%20Essentials.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Master version control using Git and GitHub. Learn how to track changes, manage branches, resolve merge conflicts, and collaborate on codebases.", "BEGINNER", "Git & Version Control Essentials", 1, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 221 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { 11, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-11-Introduction%20to%20Reactjs.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Learn to build dynamic web interfaces with React. This course covers components, props, state, and React Hooks through engaging examples and hands-on labs.", "INTERMEDIATE", true, "Introduction to React.js", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 247 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 13, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-13-Fundamentals%20of%20UXUI%20Design.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Understand what makes a product user-friendly and visually appealing. This course introduces UX research, wireframing, design systems, and interactive prototyping using Figma and other tools.", "BEGINNER", "Fundamentals of UX/UI Design", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 148 },
                    { 14, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-14-Cybersecurity%20Basics.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Learn the foundations of cybersecurity and how to protect digital assets. This course covers encryption, common threats, network vulnerabilities, and security best practices.", "BEGINNER", "Cybersecurity Basics", 3, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 121 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { 16, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-16-Introduction%20to%20Programming.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "A beginner's guide to the world of programming. This course explores what programming is, how it works, and its impact on modern computing. Gain foundational knowledge to start writing basic code.", "BEGINNER", true, "Introduction to Programming", 1, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 142 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 20, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-20-Web%20Accessibility%20and%20SEO%20Fundamentals.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Learn how to build inclusive, discoverable websites. This course covers WCAG compliance, screen reader support, semantic HTML, and on-page SEO best practices.", "INTERMEDIATE", "Web Accessibility and SEO Fundamentals", 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 128 },
                    { 21, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-21-Algorithms%20and%20Problem%20Solving.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Strengthen your logical thinking and coding efficiency through foundational algorithms and data structures. This course covers sorting, searching, recursion, and problem-solving strategies commonly used in software engineering. Ideal for those preparing for technical interviews and competitive programming challenges.", "INTERMEDIATE", "Algorithms and Problem Solving", 4, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 110 },
                    { 22, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-22-Relational%20Database%20Systems.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Learn how relational databases manage and store data efficiently. This course introduces schema design, normalization, indexing, and SQL querying techniques. You'll gain practical skills to design, query, and optimize relational databases in real-world applications.", "INTERMEDIATE", "Relational Database Systems", 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 98 }
                });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/55b96c18-6574-41db-b0f4-c2206f814f64.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), "Master the fundamentals of programming through this comprehensive beginner's course. Learn essential concepts like variables, loops, conditionals, and functions while working with practical examples. Perfect for absolute beginners, this training establishes a solid foundation for all future coding endeavors.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/22bc8ebef610eb881071e1a7007a7a80.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), "Explore the core technologies of modern web development, including front-end frameworks, back-end architectures, and database integration. Build responsive, scalable web applications from the ground up.", "Website Development", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/cyber-security-firewall-interface-protection-concept-businesswoman-protecting-herself-from.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), "Dive into the principles of securing digital systems, networks, and data. Learn about encryption, threat detection, ethical hacking, and best practices for protecting against cyber threats.", "Cybersecurity", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/c7fc020567f7bd15c1ac7dda928dda52.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), "Understand the building blocks of efficient software development. Master arrays, linked lists, trees, sorting, and searching algorithms to optimize performance in your applications.", "Data Structures & Algorithms", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/document-management-system-or-dms-setup-by-it-consultant-with-modern-computer-are-searching.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), "Learn to design, implement, and manage relational and NoSQL databases. Explore SQL queries, indexing, transactions, and data modeling for real-world applications.", "Database Systems", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.InsertData(
                table: "TrainingCategory",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 6, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/360_F_889307264_4Uc7TdNpOOg7kOdd0wpguhtpO5qnida0.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Discover cloud platforms like AWS, Azure, and Google Cloud. Learn to deploy, scale, and manage applications in the cloud while exploring serverless architectures and DevOps practices.", "Cloud Computing", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 7, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/ai-machine-learning-hands-of-robot-and-human-touching-on-big-data-network-connection.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Introduction to artificial intelligence and machine learning concepts. Explore neural networks, data preprocessing, model training, and real-world AI applications.", "Machine Learning & AI", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 8, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/software-engineering-practices-2.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Master industry-standard methodologies like Agile, Scrum, and CI/CD. Learn version control (Git), testing frameworks, and software design patterns for scalable development.", "Software Engineering Practices", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 9, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/depositphotos_24812691-stock-photo-network-cables-in-a-data.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Grasp the fundamentals of computer networks, protocols (TCP/IP), and system administration. Configure routers, troubleshoot connectivity, and understand cloud networking.", "Networking & Systems", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 10, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/embedded-systems-engineering-1800x500-hero.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Explore the intersection of hardware and software in embedded systems. Learn microcontroller programming, sensor integration, and IoT device communication for smart applications.", "Embedded Systems & IoT", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 11, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/360_F_919837931_ArVwtxgniexGWbCO35L4xg1eNw1r1i8K.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Build interactive games using Unity with C# scripting. Cover game physics, 3D modeling integration, multiplayer networking, and performance optimization for PC/mobile platforms.", "Game Development", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 12, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/image.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Explore the future of computing with quantum algorithms. Learn Q#, quantum gates, and hybrid quantum-classical programming using Microsoft's Quantum Development Kit.", "Quantum Computing Basics", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 13, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/3d-rendering-blockchain-technology_23-2151480176.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Develop smart contracts and decentralized apps (DApps) with C# and .NET tools like Nethermind. Understand Ethereum, Solidity integration, and blockchain security principles.", "Blockchain Development", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 14, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/amazed-man-interacting-with-virtual-reality_251859-3802.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Create immersive augmented/virtual reality experiences with C# in Unity or Unreal Engine. Master 3D interaction, spatial mapping, and cross-platform deployment for headsets like HoloLens and Oculus.", "AR/VR Development", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 },
                    { 15, "https://qjdzumwjsejtsekslrnj.supabase.co/storage/v1/object/public/lurnyx-images/training-category-images/2025-07/07/mobile-app-development-frameworks%20Banner.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2, null, null, "Master cross-platform mobile app development using C# and .NET technologies like Xamarin and .NET MAUI. Learn to build, test, and deploy iOS and Android apps with shared codebases, integrating REST APIs, SQLite databases, and cloud services. Explore UI/UX design principles, performance optimization, and platform-specific features to create scalable, production-ready applications.", "Mobile Development", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8794), 2 }
                });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Excellent course for beginners! The Python examples were clear and practical.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Great content, but some exercises could be more challenging.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Perfect introduction to Java OOP concepts. The instructor explains complex topics simply.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comments", "CreatedAt", "CreatedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "Good material but the pace was too fast in some sections.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, 3, 2, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 });

            migrationBuilder.InsertData(
                table: "TrainingRating",
                columns: new[] { "Id", "Comments", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, "Best web development course I've taken! Loved the hands-on projects.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 5, 3, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 6, "Very comprehensive, though the CSS module could use more modern techniques.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 4, 3, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 7, "ASP.NET Core explained perfectly. The MVC examples were especially helpful.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 5, 4, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 8, "Great course, but would benefit from more real-world application examples.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 4, 4, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 9, "Pandas is now my favorite data analysis tool thanks to this course!", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 5, 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 10, "Excellent content, though some datasets were too simplistic.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 4, 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 11, "Flutter makes mobile development so much easier. Great tutorials!", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 5, 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 12, "Good introduction but needs more coverage of state management solutions.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 3, 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), "admin.account@lurnyx.com", "Admin", "Account", "$2a$12$XooJIR.hW..3P1TXNnn3G.ggOuVRPYd7u.SM3D4F2VDdjOzfM8Mpm", null, "ADMIN", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, "super.admin@lurny.com", "SuperAdmin", "Account", "$2a$12$JdHCqOf2UZUyScDmciQCbu99/qvLNB7oeSz2azbpjqp2RHfuP3sLm", null, "SUPER_ADMIN", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, "michael.t@outlook.com", "Michael", "Thompson", "$2a$12$Fc1XIfeydhXGUkxAa9CImeIPqkYOrdrRUhlbBttY4x2nYhJf3XzTa", null, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), "sarah_martinez@gmail.com", "Sarah", "Martinez", "$2a$12$TA7jhW8GyCWK/LAlaLrIVuOtvK7u3UqvddDpL5OSZUct09AKOFeDa", null, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), "davidlee88@yahoo.com", "David", "Lee", "$2a$12$JfCHSybx96xMA6Rm.S8B3OJxFWmxuX5CNkC/po2/hC3uQtPJJyhN2", null, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "jessharris@outlook.com", "Jessica", "Harris", "$2a$12$ez1tr3JEFx.tqG0.O3ceqOUWHncRs6i0Zjj8qJc6xoo35FaOW/r7G", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 7, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "dan.nelson@gmail.com", "Daniel", "Nelson", "$2a$12$NZIj.0OxNbQ2loYZn8JPeOoN3dVc3bKYb74S4eCRVuResfokF3YTu", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 8, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "olivia.carterwork@yahoo.com", "Olivia", "Carter", "$2a$12$aVQ3cKFf1vGmrseOasioCedKG1KE54vSGUnblKngsPuQxLCW1GMgK", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 9, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "robertbaker@outlook.com", "Robert", "Baker", "$2a$12$euszfFmP0fgoEIzjnbjta.OjiOIRH24trE3s3cIRNSUWtlAtu1P96", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 10, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "sophia.green2023@gmail.com", "Sophia", "Green", "$2a$12$9e0gz9Dgq1QyokiqyGYlk.ejNjuXCLDr4LtDIzjvbjveYA64LHEAm", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 11, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "will.adams@yahoo.com", "William", "Adams", "$2a$12$g66soUR0ae8OsVE.6vO8Le./e1n0scFTALKJ3aYHQGwkGo.E9ypcS", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 12, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "ava.hall5@outlook.com", "Ava", "Hall", "$2a$12$dAa5VXJNZIcIxgmEDrnAF.lfW51VA3l1KUejZ9ZwPpWrZnIE.OAHu", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 13, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "cyoung@gmail.com", "Christopher", "Young", "$2a$12$XOGXui0b9NYJCTaaf6PRCe.5r4Vt41PriW96NgGfki6b6mBOjFtDC", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 14, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "mia_allen@yahoo.com", "Mia", "Allen", "$2a$12$KODMWKECr15MRmm2DkAZOOEjSk6nHXoRJbJyYHKbyLQ2L0nzJML9q", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 15, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "matthewking@outlook.com", "Matthew", "King", "$2a$12$75K1/3xyha5L4P612VhvKeaBv7Uv4xsHF0KUZQlxGIsd7KjIh1rOa", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 16, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "charlotte.scott@gmail.com", "Charlotte", "Scott", "$2a$12$NPfcklBAH6xBJYLVYWlsuec4srKj/qsQAhIzPxDo7jqn4EkmXQqEC", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 17, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "andrew_wright@yahoo.com", "Andrew", "Wright", "$2a$12$A45pnWbzgq68CdTkiwTs2O4dZMkMO/GiuPaaY1yf38zBxHOd2Ia7y", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 18, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "amtorres@outlook.com", "Amelia", "Torres", "$2a$12$fRJWm3sTAWYdKQRAu8mqReGL9.eYrqGeUHLzlIIpnLWnZmHpfE6iC", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 19, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "ethan.nguyen@gmail.com", "Ethan", "Nguyen", "$2a$12$6BLQpJCdj2pkTi4CeP0M4.X6N6WNeM3FE506jpxToYZe70YvpG42i", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 },
                    { 20, new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1, null, null, "harper.evans99@yahoo.com", "Harper", "Evans", "$2a$12$ONHH6ap9TxakVlbrf.jnq.gGhKr0ouAUn1Bkh/K8EU3DDPfcF9DK2", null, "USER", new DateTime(2025, 7, 9, 21, 44, 14, 506, DateTimeKind.Utc).AddTicks(4538), 1 }
                });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-3-Control%20Structures.pdf", 600, "PDF", "PDF, ~15 pages", "Control Structures", 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-4-Functions%20&%20Modular%20Programming%20(BTU%20PDF).pdf", 300, "PDF", "PDF, ~8 pages", "Functions & Modular Programming (BTU PDF)", 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 },
                    { 5, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-5-Error%20Handling%20&%20Defensive%20Programming%20(BYU%20PDF).pdf", 400, "PDF", "PDF, ~12 pages", "Error Handling & Defensive Programming (BYU PDF)", 13, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 },
                    { 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-6-Classes%20&%20Objects%20(GMU%20CS%20slides).pdf", 512, "PDF", "PDF, ~15 pages", "Classes & Objects (GMU CS slides)", 17, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 },
                    { 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-7-Inheritance%20&%20Polymorphism%20(SMU%20Lecture).pdf", 1024, "PDF", "PDF, ~20 pages", "Inheritance & Polymorphism (SMU Lecture)", 20, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 }
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "DurationInMinutes", "Order", "Title", "TrainingId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 25, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-25-Joins%20and%20Relationships.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Combine data across tables using inner, outer, and self joins.", 40, 2, "Joins and Relationships", 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 133 },
                    { 28, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-28-Building%20RESTful%20APIs.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Design scalable web APIs using Express and middleware.", 45, 2, "Building RESTful APIs", 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 104 },
                    { 31, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-31-Branching%20and%20Merging.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Work with branches, resolve merge conflicts, and understand version history.", 35, 2, "Branching and Merging", 10, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 167 },
                    { 34, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-34-React%20State%20and%20Props.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Understand data flow in React using props and manage local state.", 35, 2, "React State and Props", 11, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 161 },
                    { 43, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-43-Authentication%20and%20Encryption.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Learn about password protocols, 2FA, and data encryption methods.", 35, 2, "Authentication and Encryption", 14, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 128 },
                    { 60, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-60-Sorting%20Algorithms.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Learn bubble, merge, and quick sort with practical coding examples.", 35, 1, "Sorting Algorithms", 21, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 126 },
                    { 63, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-63-Normalization%20Rules.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Apply normalization techniques to reduce data redundancy.", 30, 1, "Normalization Rules", 22, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 109 }
                });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-5-Data%20Analysis%20with%20Python%20&%20Pandas.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, "Dive into data analysis using Python's powerful libraries like pandas and NumPy. Learn how to manipulate, analyze, and visualize real datasets through practical exercises.", "INTERMEDIATE", true, "Data Analysis with Python & Pandas", 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 204 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-6-Mobile%20App%20Development%20with%20Flutter.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, "Learn how to develop cross-platform mobile applications using Flutter and the Dart programming language. This course covers widget trees, layouts, navigation, and state management through hands-on projects and exercises.", "INTERMEDIATE", "Mobile App Development with Flutter", 15, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 189 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 7, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-7-Machine%20Learning%20Foundations.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Gain a beginner-friendly introduction to machine learning. Topics include supervised learning, model training, and evaluation using real-world datasets.", "BEGINNER", "Machine Learning Foundations", 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 150 },
                    { 12, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-12-DevOps%20Fundamentals.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Explore the key principles of DevOps and modern software delivery. This course covers CI/CD pipelines, Docker containers, infrastructure as code, and basic deployment practices.", "INTERMEDIATE", "DevOps Fundamentals", 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 132 },
                    { 15, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-15-Cloud%20Computing%20with%20AWS.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Get started with Amazon Web Services (AWS) by learning key services such as EC2, S3, and RDS. This course walks you through deployment, storage, and networking basics using real-world use cases.", "INTERMEDIATE", "Cloud Computing with AWS", 6, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 176 },
                    { 17, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-17-Advanced%20Data%20Science.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Build upon your data science skills with topics like machine learning pipelines, model tuning, and deep learning. This course is ideal for learners with prior data experience.", "ADVANCED", "Advanced Data Science", 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 131 },
                    { 18, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-18-Cross-Platform%20Mobile%20Development.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Learn the fundamentals of developing apps that run across iOS and Android using tools like Flutter and React Native.", "INTERMEDIATE", "Cross-Platform Mobile Development", 15, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 168 },
                    { 19, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-19-Practical%20Machine%20Learning%20with%20Python.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Apply machine learning principles using Python. Emphasis on hands-on implementation of classification, clustering, and regression techniques using scikit-learn.", "INTERMEDIATE", "Practical Machine Learning with Python", 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 156 },
                    { 23, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-23-Agile%20Software%20Development.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Explore industry-standard software engineering practices that improve development workflows. This course covers Agile methodologies, Scrum, version control using Git, unit testing, and continuous integration pipelines. Perfect for developers aiming to enhance team collaboration and code quality.", "INTERMEDIATE", "Agile Software Development", 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 123 },
                    { 24, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-24-Introduction%20to%20Computer%20Networks.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Understand the principles behind computer networks and how devices communicate over the internet. Topics include network models, IP addressing, protocols like TCP/IP, routing, and basic network troubleshooting. A great starting point for careers in IT and systems administration.", "BEGINNER", "Introduction to Computer Networks", 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 115 },
                    { 25, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-25-IoT%20and%20Embedded%20Systems.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Delve into the world of smart devices and real-time embedded computing. Learn about microcontrollers, sensors, and communication protocols used in the Internet of Things (IoT). This course offers hands-on experience in building connected systems for smart environments.", "INTERMEDIATE", "IoT and Embedded Systems", 10, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 89 },
                    { 26, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-26-Game%20Development%20with%20Unity.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Learn how to create interactive 2D and 3D games using Unity, one of the most popular game engines. This course covers scripting in C#, game physics, animation, and user interface design. Ideal for aspiring game developers who want to bring their ideas to life.", "INTERMEDIATE", "Game Development with Unity", 11, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 142 },
                    { 27, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-27-Quantum%20Computing%20Basics.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, null, null, "Explore the revolutionary concepts behind quantum computing. This course introduces qubits, entanglement, quantum gates, and basic quantum algorithms using tools like Qiskit or Q#. No prior experience in quantum physics is required—just curiosity and a willingness to learn.", "ADVANCED", "Quantum Computing Basics", 12, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 4, 67 },
                    { 28, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-28-Blockchain%20App%20Development.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, null, null, "Build decentralized applications using blockchain technologies such as Ethereum. Learn how smart contracts work, how to write them using Solidity, and how blockchain networks handle consensus and transactions. Designed for developers interested in Web3 and decentralized platforms.", "ADVANCED", "Blockchain App Development", 13, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 2, 103 },
                    { 29, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/training-cover-images/2025-07/08/training-29-AR%20VR%20Development%20Fundamentals.jpeg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, null, null, "Enter the world of immersive technology through Augmented and Virtual Reality development. This course explores spatial computing, Unity XR toolkit, and user interaction in 3D environments. By the end, you'll be equipped to build engaging AR/VR experiences.", "INTERMEDIATE", "AR/VR Development Fundamentals", 14, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(8935), 3, 95 }
                });

            migrationBuilder.InsertData(
                table: "TrainingRating",
                columns: new[] { "Id", "Comments", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 15, "SQL has never been this easy to understand. Perfect for database beginners!", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 5, 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 16, "Good coverage of basics, would love an advanced sequel course.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 4, 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 17, "Node.js finally makes sense! The async programming explanation was gold.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 5, 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 18, "Decent but could use more practical API building exercises.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 3, 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 19, "Git is no longer scary! The branching/merging examples were lifesavers.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 5, 10, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 20, "Very useful, though some advanced GitHub features weren't covered.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 4, 10, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 21, "React clicked for me after this course. The state management section was perfect.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 5, 11, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 22, "Great introduction, but needs more real-world project examples.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 4, 11, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 25, "UX principles well explained. The wireframing exercises were particularly valuable.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 4, 13, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 26, "Essential cybersecurity knowledge presented in an accessible way.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 5, 14, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 }
                });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 9, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-9-HTML%20Tutorial%20(Tutorialspoint).pdf", 0, "PDF", "PDF, ~200 pages", "HTML Tutorial (Tutorialspoint)", 25, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 },
                    { 10, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-10-CSS%20Styling%20Techniques%20(Stanford%20CS).pdf", 800, "PDF", "PDF, ~30 pages", "CSS Styling Techniques (Stanford CS)", 28, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 },
                    { 11, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-11-JavaScript%20Fundamentals%20%20(TutorialsPoint%20Guide).pdf", 0, "PDF", "PDF, ~250 pages", "JavaScript Fundamentals - TutorialsPoint Guide", 31, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 },
                    { 12, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-12-JavaScript%20Handbook.pdf", 0, "PDF", "PDF, ~150 pages", "JavaScript Handbook - Edu-9", 34, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 },
                    { 14, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://www.youtube.com/watch?v=8Ze0b2VvwHQ", 0, "URL", "Video, ~15 min", "Getting Started with Programming - Dave Gray Video", 43, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 }
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "DurationInMinutes", "Order", "Title", "TrainingId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 22, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-22-Model%20Evaluation.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Learn accuracy, precision, recall, and confusion matrix fundamentals.", 35, 2, "Model Evaluation", 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 59 },
                    { 37, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-37-Docker%20Containers.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Understand containerization with Docker and how it simplifies deployment.", 40, 2, "Docker Containers", 12, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 128 },
                    { 45, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-45-AWS%20Core%20Services.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Learn about EC2, S3, and RDS with use case demonstrations.", 40, 1, "AWS Core Services", 15, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 119 },
                    { 50, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-50-Deep%20Learning%20Introduction.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Learn the basics of neural networks and deep learning concepts.", 50, 3, "Deep Learning Introduction", 17, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 120 },
                    { 53, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-53-App%20Deployment.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Learn how to publish apps to the App Store and Google Play.", 40, 3, "App Deployment", 18, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 125 },
                    { 56, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-56-Unsupervised%20Learning.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Explore clustering methods like K-Means and DBSCAN.", 45, 3, "Unsupervised Learning", 19, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 132 },
                    { 66, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-66-Scrum%20Framework.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Understand the roles, ceremonies, and artifacts in Scrum.", 30, 1, "Scrum Framework", 23, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 110 },
                    { 69, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-69-OSI%20Model.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Study the 7-layer OSI model and functions of each layer.", 35, 1, "OSI Model", 24, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 116 },
                    { 72, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-72-Microcontroller%20Basics.webp", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Get hands-on with devices like Arduino and ESP32.", 35, 1, "Microcontroller Basics", 25, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 111 },
                    { 76, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-76-Player%20Input%20and%20Movement.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Implement controls for character movement and actions.", 40, 2, "Player Input and Movement", 26, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 115 },
                    { 78, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-78-Qubits%20and%20Superposition.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, null, null, "Understand quantum states and how qubits differ from bits.", 30, 1, "Qubits and Superposition", 27, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 2, 88 },
                    { 81, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-81-Smart%20Contract%20Design.jpg", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, null, null, "Build reusable and secure smart contracts using Solidity.", 40, 1, "Smart Contract Design", 28, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 3, 118 },
                    { 84, "https://obsdbfqybmsyxlhkkxhc.supabase.co/storage/v1/object/public/lurnyx-images/topic-cover-images/2025-07/07/topic-84-Unity%20XR%20Setup.png", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, null, null, "Set up Unity XR plugins for AR/VR development.", 35, 1, "Unity XR Setup", 29, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9229), 4, 108 }
                });

            migrationBuilder.InsertData(
                table: "TrainingRating",
                columns: new[] { "Id", "Comments", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 13, "Solid ML foundations course. The regression section was particularly strong.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 4, 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 14, "Some concepts weren't explained clearly enough for beginners.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 2, 7, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 23, "DevOps concepts finally made clear. The CI/CD pipeline walkthrough was excellent.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 5, 12, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 24, "Good overview but too theoretical. Needs more hands-on labs.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 3, 12, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 27, "AWS basics covered well, though some newer services weren't included.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 4, 15, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 },
                    { 28, "Advanced topics made approachable. The deep learning intro was brilliant.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5, null, null, 5, 17, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 29, "Great comparison of native vs hybrid approaches. More code examples would help.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3, null, null, 4, 18, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 3 },
                    { 30, "Machine learning with Python finally makes sense! The classification examples were perfect.", new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4, null, null, 5, 19, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9526), 4 }
                });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 8, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-8-Abstract%20Classes%20&%20Interfaces%20(UMD%20slides).pdf", 0, "PDF", "PDF, ~49 pages", "Abstract Classes & Interfaces (UMD slides)", 22, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 },
                    { 13, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-13-JavaScript%20for%20Absolute%20Beginners%20(Pepa%20PDF).pdf", 7382, "PDF", "PDF, ~80 pages", "JavaScript for Absolute Beginners - Pepa PDF", 37, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 },
                    { 15, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-15-Getting%20Started%20with%20ASP.NET%20Core%20(Tutorialspoint%20PDF).pdf", 250, "PDF", "PDF, ~150 pages", "Getting Started with ASP.NET Core - Tutorialspoint PDF", 45, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 },
                    { 16, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-16-Understanding%20MVC%20(TutorialsPoint%20PDF).pdf", 0, "PDF", "PDF, ~40 pages", "Understanding MVC (TutorialsPoint PDF)", 66, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 },
                    { 17, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-17-Getting%20Started%20MVC%20Architecture%20(CSU%20Ohio%20PDF).pdf", 200, "PDF", "PDF, ~10 pages", "Getting Started - MVC Architecture (CSU Ohio PDF)", 69, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 },
                    { 18, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4, null, null, "https://www.youtube.com/watch?v=1PAy6d16ADQ", 0, "URL", "Video, ~1 hr", "Working with Data - IBM Data Analyst Course (YouTube video)", 72, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 4 },
                    { 19, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-19-Introduction%20to%20Pandas%20(PDF%20Slides).pdf", 0, "PDF", "PPT, ~30 slides", "Introduction to Pandas (PDF Slides)", 81, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 2 },
                    { 20, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3, null, null, "https://obsdbfqybmsyxlhkkxhc.storage.supabase.co/v1/object/public/lurnyx-files/resource-materials/2025-07/08/rm-20-Pandas%20Cheat%20Sheet.pdf", 150, "PDF", "PDF, 1 page", "Pandas Cheat Sheet - Quick Reference", 84, new DateTime(2025, 7, 9, 21, 44, 24, 456, DateTimeKind.Utc).AddTicks(9414), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "An overview of programming concepts.", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 0 });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "DurationInMinutes", "Title", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "Understanding how to store information.", 45, "Variables and Data Types", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "DurationInMinutes", "Order", "Title", "TrainingId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[,]
                {
                    { 3, "https://placehold.co/344x242/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, null, null, "Setting up your development environment.", 30, 1, "Getting Started", 6, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 },
                    { 4, "https://placehold.co/344x242/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, null, null, "The Model-View-Controller pattern.", 60, 2, "Understanding MVC", 6, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 },
                    { 5, "https://placehold.co/344x242/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, null, null, "Using Entity Framework Core.", 90, 3, "Working with Data", 6, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Title", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Learn the basics of programming.", "Introduction to Programming", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 0 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "Deep dive into data science techniques.", "ADVANCED", "Advanced Data Science", 2, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "IsFeatured", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "Build modern web applications.", "INTERMEDIATE", false, 3, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Title", "TrainingCategoryId", "UpdatedAt", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Create mobile applications for Android and iOS.", "Mobile App Development", 4, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 0 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "Learn the fundamentals of machine learning.", "BEGINNER", false, "Machine Learning Basics", 5, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy", "ViewCount" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "Build modern web apps with .NET.", "BEGINNER", "Introduction to ASP.NET Core", 3, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, 0 });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Learn programming languages", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Explore data science concepts", "Data Science", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Build modern web applications", "Web Development", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Create mobile applications", "Mobile Development", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "Learn machine learning techniques", "Machine Learning", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Excellent course for beginners!", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Good content, but could use more examples.", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Comments", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Very detailed and informative.", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comments", "CreatedAt", "CreatedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "Great introduction to .NET!", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 5, 5, 6, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 5 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "superadmin@lurnyx.com", "Super", "Admin", "$2a$12$YGAnB6p3SSSmX0qP9f0kJe1iy6zHSiVkcVcS7O6vIoGHzg0sJKmcK", "https://placehold.co/400x400/png", "SUPER_ADMIN", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "admin@lurnyx.com", "Admin", "User", "$2a$12$zYfYrk0XdNS5N1P6pGt6EeL.AHwJ1w8cXc/Tx3qb4zXkOs1rzec/y", "https://placehold.co/400x400/png", "ADMIN", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 3, "user@lurnyx.com", "Generic", "User", "$2a$12$6WlpTr/KftpEmDKC/8ZrfORiKaG9dF0W2LGUj1AzhklNe7xEez1Em", "https://placehold.co/400x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 3 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "john.doe@lurnyx.com", "John", "Doe", "$2a$12$2OUUt6xPaM30jF7m7z4T2.IKAaOePsS5G5DiciDYWt2RMrlC2a9e6", "https://placehold.co/400x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "jane.smith@lurnyx.com", "Jane", "Smith", "$2a$12$JTvstgwWvVHBUQcqrFNYf.DZGTos7CBUhKRuRuX0rqbHMitapCq3e", "https://placehold.co/400x400/png", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "Name", "TopicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/dummy.pdf", 13264, "1 page", "Setup Guide", 3, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/png.png", 7347, "PNG", "1 diagram", "MVC Diagram", 4, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2 });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2, "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/sample1.pptx", 34789, "PPTX", "1 slide", "Sample PowerPoint Presentation", 5, new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), 2 });
        }
    }
}
