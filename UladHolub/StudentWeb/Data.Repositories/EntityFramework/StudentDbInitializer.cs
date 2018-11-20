using Data.Contracts.Entities;
using System.Data.Entity;

namespace Data.Repositories.EntityFramework
{
    public class StudentDbInitializer : CreateDatabaseIfNotExists<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            context.Students.Add(new Student { FirstName = "Vasya", LastName = "Pupkin" });
            context.Tags.Add(new Tag { Name = "Study" });
            context.Tags.Add(new Tag { Name = "IT" });
            context.Tags.Add(new Tag { Name = "People" });
            context.Tags.Add(new Tag { Name = "VideoGames" });
            base.Seed(context);
        }
    }
}
