using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HouseCleanersApi.Data
{
    public class clearnersDbContext: IdentityDbContext<User,IdentityRole,string>
    {
        private readonly IConfiguration _configuration;

        public clearnersDbContext(DbContextOptions<clearnersDbContext>options):base(options)
        {

        }
        
         public virtual DbSet<Categorie> Categories { get; set; }
                public virtual DbSet<Customer> Customers { get; set; }
                public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
                public virtual DbSet<Invoice> Invoices { get; set; }
                public virtual DbSet<Planning> Plannings { get; set; }
                public virtual DbSet<Professional> Professionals { get; set; }
                public virtual DbSet<Reservation> Reservations { get; set; }
                public virtual DbSet<Service> Services { get; set; }
                public virtual DbSet<Status> Status { get; set; }
                public virtual DbSet<ProfessionalService> ProfessionalServices { get; set; }
                 public virtual DbSet<Disponibility> Disponibilities { get; set; }
                
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.categoryId);
                entity.HasIndex(e => e.categoryName).IsUnique(true);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.customerId);
                entity.Property(e => e.active).HasDefaultValue(true);
            
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.HasKey(e => e.invoicelineId);

                entity.HasIndex(e => e.invoiceId);

                entity.HasIndex(e => e.reservationId);

                entity.Property(e => e.amount).HasColumnType("numeric");
                
                entity.Property(e => e.hourCount).HasColumnType("numeric");

                entity.Property(e => e.hourPrice).HasColumnType("numeric");
                
                entity.HasOne(d => d.invoice)
                    .WithMany(p => p.invoiceLines)
                    .HasForeignKey(d => d.invoiceId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.reservation)
                    .WithMany(p => p.invoiceLines)
                    .HasForeignKey(d => d.reservationId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.invoiceId);

                entity.HasIndex(e => e.customerId);

               // entity.HasIndex(e => e.professionalId);

                entity.Property(e => e.invoiceAmountTotal).HasColumnType("numeric");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.customerId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Planning>(entity =>
            {
                entity.HasKey(e => e.planingId);

                entity.HasIndex(e => e.professionalId);

                entity.HasOne(d => d.professionnal)
                    .WithMany(p => p.plannings)
                    .HasForeignKey(d => d.professionalId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.professionalId);
                entity.Property(e => e.active).HasDefaultValue(true);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.reservationId);

                entity.HasIndex(e => e.customerId);

                entity.HasIndex(e => e.ServiceId);

                entity.HasIndex(e => e.professionalId);

                entity.HasIndex(e => e.statusId);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceId");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.customerId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.ServiceId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.professional)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.professionalId).OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(d => d.status)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.statusId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.serviceId);

                entity.HasIndex(e => e.categoryId);

                entity.HasOne(d => d.category)
                    .WithMany(p => p.services)
                    .HasForeignKey(d => d.categoryId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<ProfessionalService>()
                .HasKey(e => new
                {
                    e.professionalId,
                    e.serviceId
                });
            modelBuilder.Entity<Disponibility>()
                .HasOne(p => p.professional)
                .WithMany(d => d.disponibilities)
                .HasForeignKey(p => p.professionalId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Disponibility>()
               .HasIndex(p => new {p.professionalId, p.startHour, p.EndHour}).IsUnique(true);
            base.OnModelCreating(modelBuilder);
        }

   
                
    }
}