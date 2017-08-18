using Microsoft.EntityFrameworkCore;
 
namespace csharpbelt.Models
{
    public class auctionContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public auctionContext(DbContextOptions<auctionContext> options) : base(options) { }
            public DbSet<Userrecord> user { get; set; }
            public DbSet<AuctionObj> auction { get; set; }
            public DbSet<Bid> bid { get; set; }
           

    }
}