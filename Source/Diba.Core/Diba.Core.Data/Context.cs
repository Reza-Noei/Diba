using Diba.Core.Data.Configuration;
using Diba.Core.Domain;
using Diba.Core.Domain.Products;
using Diba.Core.Domain.Products.ProductConstraints;
using Microsoft.EntityFrameworkCore;

namespace Diba.Core.Data
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public static Context Create()
        {
            return new Context();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<CustomerOrder> Orders { get; set; }
        public DbSet<ProductClass> Products { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Service> Services { get; set; }



        public DbSet<StringConstraint> StringConstraints { get; set; }

        public DbSet<SelectiveConstraint> SelectiveConstraints { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;Initial Catalog=Diba;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;");
            //TODO:Resolve Bug
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
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
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerOrderConfiguration());
            modelBuilder.ApplyConfiguration(new QuickAccessListConfiguration());
            modelBuilder.ApplyConfiguration(new QNameConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}