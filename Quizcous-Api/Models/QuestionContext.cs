using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quizcous_Api.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext() : base("questionsApi")
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}