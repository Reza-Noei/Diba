using Diba.Core.Data.Configuration;
using Diba.Core.Domain;
using Diba.Core.Domain.Products;
using Diba.Core.Domain.Products.ProductConstraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Diba.Core.Data
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public static Context Create() { return new Context(); }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Authority> Memberships { get; set; }
        public DbSet<SecretaryMembership> SecretaryMemberships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<BaseRole> Roles { get; set; }
        public DbSet<CustomerOrder> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<StringConstraint> StringConstraints { get; set; }

        public DbSet<SelectiveConstraint> SelectiveConstraints { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD:Source/Diba.Core/Diba.Core.Data/Context.cs
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DibaTT; Integrated Security=True; MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-LOCCOLD\DIBA;Database=DibaTest;UserId=sa;password=325896;Trusted_Connection=True;");
=======
            //optionsBuilder.UseSqlServer(@"Provider=SQLOLEDB.1;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Diba; Integrated Security=True; MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=diba;Data Source=DESKTOP-S17KDGA\SQLEXPRESS01;");
>>>>>>> 7ca288125e51b76bcde0bedcfbf56bfe9da2b1bf:Code/Source/Diba.Core/Diba.Core.Data/Context.cs
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new BaseRoleConfiguration());

            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());

            modelBuilder.ApplyConfiguration(new SecretaryMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new SuperAdminMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new AdminMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new CollectorMembershipConfiguration());

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorityPermissionConfiguration());

            modelBuilder.ApplyConfiguration(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConstraintConfiguration());
            modelBuilder.ApplyConfiguration(new StringConstraintConfiguration());
            modelBuilder.ApplyConfiguration(new SelectiveConstraintConfiguration());

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
            modelBuilder.ApplyConfiguration(new CollectorConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryConfiguration());
            modelBuilder.ApplyConfiguration(new SecretaryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorityConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerOrderConfiguration());
            modelBuilder.ApplyConfiguration(new QuickAccessListConfiguration());
            modelBuilder.ApplyConfiguration(new QNameConfiguration());

            var RoleActions = new List<RolePermission>();
            RoleActions.Add(new RolePermission()
            {
                Id = 1,
                Role = RoleEnum.SuperAdmin,
                Action = ActionEnum.CreateUser,
                IsGranted = true
            });

            RoleActions.Add(new RolePermission()
            {
                Id = 2,
                Role = RoleEnum.SuperAdmin,
                Action = ActionEnum.Login,
                IsGranted = true
            });

            RoleActions.Add(new RolePermission()
            {
                Id = 3,
                Role = RoleEnum.SuperAdmin,
                Action = ActionEnum.EditUser,
                IsGranted = true
            });

            RoleActions.Add(new RolePermission()
            {
                Id = 4,
                Role = RoleEnum.SuperAdmin,
                Action = ActionEnum.DeleteUser,
                IsGranted = true
            });

            RoleActions.Add(new RolePermission()
            {
                Id = 5,
                Role = RoleEnum.Secretary,
                Action = ActionEnum.Login,
                IsGranted = true
            });

            modelBuilder.Entity<RolePermission>().HasData(RoleActions);

            var SuperAdminUserId = 1;
            var SuperAdminUser = new User() { Id = SuperAdminUserId, Username = "SuperAdmin", Password = "123456" };

            var SecretaryUserId = 2;
            var SecretaryUser = new User() { Id = SecretaryUserId, Username = "Secretary", Password = "123456" };

            modelBuilder.Entity<User>().HasData(SuperAdminUser);
            modelBuilder.Entity<User>().HasData(SecretaryUser);


            var SecretaryRole = new BaseRole(RoleEnum.Secretary)
            {
                Id = 1,
                UserId = SecretaryUserId
            };

            modelBuilder.Entity<BaseRole>().HasData(SecretaryRole);

            var SuperAdminRole = new BaseRole(RoleEnum.SuperAdmin)
            {
                Id = 2,
                UserId = SuperAdminUserId
            };

            modelBuilder.Entity<BaseRole>().HasData(SuperAdminRole);

            SuperAdmin SuperAdmin = new SuperAdmin()
            {
                Id = 1,
                RoleId = SuperAdminRole.Id
            };

            modelBuilder.Entity<SuperAdmin>().HasData(SuperAdmin);

            var Secretary = new Secretary()
            {
                Id = 2,
                RoleId = SecretaryRole.Id
            };

            modelBuilder.Entity<Secretary>().HasData(Secretary);

            var SecretaryAuthority = new Authority()
            {
                Id = 1,
                Active = true
            };

            modelBuilder.Entity<Authority>().HasData(SecretaryAuthority);

            var SuperAdminAuthority = new Authority()
            {
                Id = 2,
                Active = true
            };

            modelBuilder.Entity<Authority>().HasData(SuperAdminAuthority);

            var OrganizationId = 1;
            var Organization = new Organization("Default Organization")
            {
                Id = OrganizationId,
                CreatorId = SuperAdminUser.Id,
                Prefix = "935"
            };

            modelBuilder.Entity<Organization>().HasData(Organization);

            modelBuilder.Entity<SuperAdminMembership>().HasData(new SuperAdminMembership()
            {
                Id = 1,
                AuthorityId = SuperAdminAuthority.Id,
                SuperAdminId = SuperAdmin.Id,
                OrganizationId = Organization.Id
            });

            modelBuilder.Entity<SecretaryMembership>().HasData(new SecretaryMembership()
            {
                Id = 2,
                AuthorityId = SecretaryAuthority.Id,
                SecretaryId = Secretary.Id,
                OrganizationId = Organization.Id
            });

             base.OnModelCreating(modelBuilder);
        }
    }
}
