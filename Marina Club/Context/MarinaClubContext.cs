using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Context
{
    public class MarinaClubContext : DbContext
    {
        public MarinaClubContext(DbContextOptions<MarinaClubContext> options) : base(options)
        {
        }
        
        public DbSet<WaterFun> WaterFuns { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<SellerManager> SellerManagers { get; set; }
        
        public DbSet<IntroducingWaterFun> IntroducingWaterFuns { get; set; }
        
        public DbSet<Suggestion> Suggestions { get; set; }
        
        public DbSet<Sans> Sanses { get; set; }
        
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Rules> Rules { get;  set; }
        
        public DbSet<AboutUs> AboutUs  { get; set; }
        
        public DbSet<ContactUs> ContactUses { get; internal set; }
        
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<DuplicateQuestions> DuplicateQuestions { get; set; }
        
        public DbSet<Sliders>Sliders{ get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }

        public  DbSet<SellerAddress>SellerAddresses { get; set; }

        public  DbSet<SellerInfo >SellerInfos { get; set; }

        public DbSet<Report> Reports { get; set; }
       
    }
}
