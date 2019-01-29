using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace GameStarz.Models
{
    
    public class Game
    {
        [JsonProperty(PropertyName="id")]
        [Key]
        public int gameId{get;set;}

        public string name{get;set;} 
        public double rating{get;set;} 
        public double popularity{get;set;} 

        public string summary{get;set;} 
        
        [ForeignKey("User")]
        public int user_id{get;set;}

       
        public Cover cover{get;set;}

        [NotMapped]
        public double first_release_date{get;set;}
        public DateTime release_date{get;set;}

        public  List<Screenshot> screenshots{get;set;}

        public  List<Video> videos{get;set;}

        [NotMapped]
        public List<Genre> genres{get;set;}

        [NotMapped]
        public List<Platform> platforms{get;set;}
        
        public List<Expansion> expansions{get;set;}

        [NotMapped]
        public List<InvolvedCompany> involved_companies{get;set;}
        // Many to Many Relationship
        public List<GamePlatforms> game_Platforms{get;set;}
        public List<GameGenres> game_Genres{get;set;}

        public List<GameCompanies> game_Companies{get;set;}
        public List<Review> Reviews{get;set;}

    }

    public class PopularGame
    {
        [JsonProperty(PropertyName="id")]
        public int gameId{get;set;}
        public Cover cover{get;set;}
        public string name{get;set;} 
        public double rating{get;set;} 
        public double popularity{get;set;} 
        public List<Platform> platforms{get;set;}
        public  List<Screenshot> screenshots{get;set;}
    }

    public class Filters
    {
        public List<Genre> genres{get;set;}
        public List<string> platforms=new List<string>(){
            "Linux","Mac","PC(Microsoft Windows)","Nintendo","Playstation 4","PlayStation 3","Xbox One","Xbox 360"
        };

    }

    public class Screenshot
    {
        [JsonProperty(PropertyName="id")]
        [Key]
        public int screenshot_id{get;set;}
        public int gameId{get;set;}
        public string image_id{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }
    public class Cover{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int cover_id{get;set;}
        public int gameId{get;set;}
        public string image_id{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }
    public class ExpansionCover{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int expansionCover_id{get;set;}
        public int gameId{get;set;}
        public int expansion_id{get;set;}
        public string image_id{get;set;}

        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }
    public class Video{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int TheVideo_id{get;set;}
        public int gameId{get;set;}
        public string name{get;set;}
        public string video_id{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }
    public class Expansion{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int id{get;set;}
        public string name{get;set;}
        public ExpansionCover cover{get;set;}
        public int gameId{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }
    public class Genre{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int genre_id{get;set;}
        public string name{get;set;}
        public string slug{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

        [NotMapped]
        public List<GameGenres> Games{get;set;}

    }
    public class Platform{
        [JsonProperty(PropertyName="id")]
        [Key]
        public int platform_id{get;set;}
        public string name{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;
        [NotMapped]
        public List<GamePlatforms> HostingGames{get;set;}
    }
   
    public class Company
    {
        [JsonProperty(PropertyName="id")]
        [Key]
        public int company_id{get;set;}
        public string name{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;
        public List<GameCompanies> gameInvested{get;set;}


    }

    // This one is for the API, i did not use it as the many to many realationship between game and companies becuase it is giving some weird behavior
    // So i am using this one as just to get he information ina a class and then i will manuallly created the relationship
    // between game and companies using the GameCompanies Model [found below]
    public class InvolvedCompany
    {
        [JsonProperty(PropertyName="id")]
        [Key]
        public int involveCompany_id{get;set;}
        public int company_id{get;set;}
        public int gameId{get;set;}
        public Company company{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;
        
    
    }
   
   // Many to Many Relationship between Game and Companies

    public class GameCompanies
    {
        [Key]
        public int gameCompany_id{get;set;}
        public int company_id{get;set;}
        public int gameId{get;set;}
        public Company company{get;set;}
        public Game game{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;
        
    
    }



    // Many to Many Relationship between Game and Genre
    public class GameGenres
    {
        [Key]
        public int gameGenre_id{get;set;}
        public int gameId{get;set;}
        public int genre_id{get;set;}
        
        public Genre genre{get;set;}
        public Game game{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }

    // Many to Many relationship between Game and Platform
    public class GamePlatforms
    {
        [Key]
        public int gamePlatform_id{get;set;}
        public int gameId{get;set;}
        public int platform_id{get;set;}
        public Game game{get;set;}
        public Platform platform{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

    }


    // For the Rating Form
    public class RatingForm
    {
        [Required]
        [Display(Name="Minimum Rating")]
        [Range(1,100,ErrorMessage="Min Rating should be bwtween 1-100")]
        public double MinRating{get;set;}

        [Required]
        [Display(Name="Maximum Rating")]
        [Range(1,100,ErrorMessage=" Max Rating should be bwtween 1-100")]
        public double MaxRating{get;set;}

    }

}