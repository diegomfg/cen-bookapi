using CEN4010_Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace CEN4010_Bookstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>()
        //     .HasOne(user => user.UserProfile)
        //     .WithOne(profile => profile.User)
        //     .HasForeignKey<User>(user => user.UserProfile);
        // }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<BookReview> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishListDetail> WishlistDetails { get; set; }


    }
}
