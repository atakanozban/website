using System.Data.Entity;

namespace atakanozbancomtr.Models.classes
{
    public class Context : DbContext 
    {
        public Context() : base("Context")
        {
            // MODEL–DB uyuşmazlığını kapatır:
            Database.SetInitializer<Context>(null);
        }

        public DbSet<admin> admins { get; set; }
        public DbSet<myprojects> MyProjects { get; set; }

    }
}