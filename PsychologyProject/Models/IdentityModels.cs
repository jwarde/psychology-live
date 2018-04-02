using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PsychologyProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PsychologyProject.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<PsychologyProject.Models.DocumentationType> DocumentationTypes { get; set; }

        public System.Data.Entity.DbSet<PsychologyProject.Models.Documentation> Documentations { get; set; }

        public System.Data.Entity.DbSet<PsychologyProject.Models.Tests> Tests { get; set; }

        public System.Data.Entity.DbSet<PsychologyProject.Models.UserTests> UserTests { get; set; }

        public System.Data.Entity.DbSet<PsychologyProject.Models.Experiment> Experiments { get; set; }
    }
}