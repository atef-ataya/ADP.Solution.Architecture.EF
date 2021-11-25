using ADP.Solution.Application.Contracts;
using ADP.Solution.Domain.Common;
using ADP.Solution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Persistence
{
    public class ADPDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ADPDbContext(DbContextOptions<ADPDbContext> options)
          : base(options)
        {
        }

        public ADPDbContext(DbContextOptions<ADPDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<AdaaTask> AdaaTasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ADPDbContext).Assembly);

            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);
            modelBuilder.Entity<AdaaTask>().HasKey(y => y.TaskId);
            

            //seed data, added through migrations
            var frontEnd = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var backEnd = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var microFrontEnd = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var microBackEnd = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = frontEnd,
                Name = "frontEnd"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = backEnd,
                Name = "backEnd"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = microFrontEnd,
                Name = "microFrontEnd"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = microBackEnd,
                Name = "microBackEnd"
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "Solution Architect",
                Date = DateTime.Now.AddMonths(6),
                Description = "Creating ADP Solution Architect",
                CategoryId = frontEnd
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "Exception Middleware",
                Date = DateTime.Now.AddMonths(2),
                Description = "Creating ADP Solution Architect",
                CategoryId = backEnd
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Exception Middleware",
                Date = DateTime.Now.AddMonths(9),
                Description = "Creating ADP Solution Architect",
                CategoryId = microFrontEnd
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "Exception Middleware",
                Date = DateTime.Now.AddMonths(5),
                Description = "Creating ADP Solution Architect",
                CategoryId = backEnd
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "Exception Middleware",
                Date = DateTime.Now.AddMonths(1),
                Description = "Creating ADP Solution Architect",
                CategoryId = microFrontEnd
            });

            modelBuilder.Entity<AdaaTask>().HasData(new AdaaTask
            {
                TaskId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "Exception Middleware",
                Date = DateTime.Now.AddMonths(8),
                Description = "Creating ADP Solution Architect",
                CategoryId = microBackEnd
            });

          
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
