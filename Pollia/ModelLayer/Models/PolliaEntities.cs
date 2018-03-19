namespace ModelLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PolliaEntities : DbContext
    {
        public PolliaEntities()
            : base("name=PolliaEntities")
        {
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<EventKind> EventKinds { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ImageKind> ImageKinds { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<PlaceKind> PlaceKinds { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<RoleViewModel> RoleViewModels { get; set; }
        public virtual DbSet<Scope> Scopes { get; set; }
        public virtual DbSet<TripBookHasDestination> TripBookHasDestinations { get; set; }
        public virtual DbSet<TripBook> TripBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.LastUpdateUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Events1)
                .WithRequired(e => e.AspNetUser1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Places)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.LastUpdateUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Places1)
                .WithRequired(e => e.AspNetUser1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.TripBooks)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventKind>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.EventKind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Articles)
                .WithOptional(e => e.Event)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ImageKind>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.ImageKind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlaceKind>()
                .HasMany(e => e.Places)
                .WithRequired(e => e.PlaceKind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Articles)
                .WithOptional(e => e.Place)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Places1)
                .WithOptional(e => e.Place1)
                .HasForeignKey(e => e.NextPlaceId);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Places11)
                .WithOptional(e => e.Place2)
                .HasForeignKey(e => e.PrevPlaceId);

            modelBuilder.Entity<TripBook>()
                .HasMany(e => e.TripBooks1)
                .WithRequired(e => e.TripBook1)
                .HasForeignKey(e => e.TB);
        }
    }
}
