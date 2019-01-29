using Microsoft.EntityFrameworkCore;


namespace GameStarz.Models
{
    public class DatabaseContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<Cover> Covers {get;set;}
        public DbSet<Screenshot> Screenshots {get;set;}
        public DbSet<Video> Videos {get;set;}
        public DbSet<Platform> Platforms {get;set;}
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Expansion> Expansions {get;set;}
        public DbSet<Company> Companies {get;set;}
        public DbSet<GameCompanies> GameCompanies {get;set;}

        public DbSet<GameGenres> GameGenres {get;set;}
        public DbSet<GamePlatforms> GamePlatforms {get;set;}
        public DbSet<Review> Reviews {get;set;}
        public DbSet<ReviewResponse> ReviewResponses {get;set;}
        public DbSet<Like> Likes {get;set;}



    }

    

}