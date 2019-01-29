using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Linq;


namespace GameStarz.Models
{
    
    public class GamesProcessor
    {
        public static async Task<List<Game>> LoadGamesBasedOnFilters(string genre,string platform,int MinRating=1,int MaxRating=100)
        {

            string url="games/";
            var query=queryProcess(MinRating,MaxRating,genre:genre,platform:platform);
            using(HttpResponseMessage response=await ApiHelper.ApiClient.PostAsync(url,new StringContent(query)))
           
            {
            string res=response.ReasonPhrase;
                if(response.IsSuccessStatusCode || res=="Server Error")
                {
                    var games=await response.Content.ReadAsAsync<List<Game>>();
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    foreach (var game in games)
                    {
                        game.release_date=dateTime.AddSeconds(game.first_release_date);
                       
                    }
                    return games;
                }
                else
                {
                    var emptyGameList=new List<Game>();
                    return emptyGameList;
                    // throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<List<PopularGame>> LoadPopularGames()
        {

            string url="games/";
            using(HttpResponseMessage response=await ApiHelper.ApiClient.PostAsync(url,
            new StringContent(@"
            fields screenshots.url,cover.url,cover.image_id,name,rating,first_release_date,platforms.name,popularity;
            where first_release_date > 1527206400 & first_release_date < 1546254191;
            where popularity>100 & rating>1;sort rating desc; 
            limit 6;")))
           
            {
                if(response.IsSuccessStatusCode)
                {
                    var PopularGames=await response.Content.ReadAsAsync<List<PopularGame>>();
                    return PopularGames;
                }
                else
                {
                    var emptyGameList=new List<PopularGame>();
                    return emptyGameList;
                    // throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<Filters> FetchGenres()
        {
            string url="genres/";
            using(HttpResponseMessage response=await ApiHelper.ApiClient.PostAsync(url,
            new StringContent(@"fields name,slug; limit 20; ")))
        
            {
                if(response.IsSuccessStatusCode)
                {
                    var genres=await response.Content.ReadAsAsync<List<Genre>>();
                    var filters=new Filters();
                    filters.genres=genres;
                    return filters;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<List<Game>> LoadGamesBasedOnSearch(string name)
        {
            string url="games/";
            var query=$@"
                fields genres.name,genres.slug,cover.url,cover.image_id,name,rating,first_release_date,platforms.name;
                where popularity>1&rating>1;
                search ""{name}"";
                limit 20;";

            using(HttpResponseMessage response=await ApiHelper.ApiClient.PostAsync(url,new StringContent(query)))
            {
          
                if(response.IsSuccessStatusCode)
                {
                    var games=await response.Content.ReadAsAsync<List<Game>>();
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    foreach (var game in games)
                    {
                        dateTime=dateTime.AddSeconds(game.first_release_date);
                        game.release_date=dateTime;
                    }
                    return games;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
        public static async Task<Game> ShowOneGame(int gameId)
        {

            string url="games/";
            var query=$@"
                fields genres.name,cover.image_id,name,
                rating,first_release_date,platforms.name,
                storyline,summary,popularity,screenshots.image_id,videos.video_id,videos.name,
                expansions.name,expansions.cover.image_id,involved_companies.company.name;
                where id={gameId};";


            using(HttpResponseMessage response=await ApiHelper.ApiClient.PostAsync(url,new StringContent(query)))
            {
            
                if(response.IsSuccessStatusCode)
                {
                    var games=await response.Content.ReadAsAsync<List<Game>>();
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    foreach (var game in games)
                    {
                        dateTime=dateTime.AddSeconds(game.first_release_date);
                        game.release_date=dateTime;

                        if (game.cover !=null)
                        {
                            game.cover.gameId=gameId;
                        }
                        
                        if (game.screenshots!=null)
                        {
                            foreach (var screenshot in game.screenshots)
                            {
                                screenshot.gameId=gameId;
                            }
                        }
                        
                        if (game.videos!=null)
                        {
                           foreach (var videos in game.videos)
                            {
                                videos.gameId=gameId;
                            } 
                        }
                        
                        if (game.expansions!=null)
                        {
                            foreach (var expansion in game.expansions)
                            {
                                expansion.gameId=gameId;
                            }
                            
                        }
                        
                    }
                    return games[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
        public static string queryProcess(int MinRating,int MaxRating,string genre,string platform)
        {
            string query;
            if (genre==null && platform==null)
            {
              query=$@"
                fields genres.name,genres.slug,cover.url,cover.image_id,name,rating,first_release_date,platforms.name;
                where popularity>1&rating>{MinRating}&rating<{MaxRating};
                sort rating desc;
                limit 20;";
            }
            else if(genre==null && platform !=null)
            {
                query=$@"
                    fields genres.name,genres.slug,cover.url,cover.image_id,name,rating,first_release_date,platforms.name;
                    where popularity>1&rating>{MinRating}&rating<{MaxRating};
                    where platforms.name~*""{platform}""*;
                    sort rating desc;
                    limit 20;";
            }
            else if(genre!=null && platform ==null)
            {
                query=$@"
                    fields genres.name,genres.slug,cover.url,cover.image_id,name,rating,first_release_date,platforms.name;
                    where popularity>1&rating>{MinRating}&rating<{MaxRating};
                    where genres.slug~*""{genre}""*;
                    where genres.slug~*""{genre}""*;
                    sort rating desc;
                    limit 20;";
            }
            else
            {
                query=$@"
                    fields genres.name,genres.slug,cover.url,cover.image_id,name,rating,first_release_date,platforms.name;
                    where popularity>1&rating>{MinRating}&rating<{MaxRating};
                    where genres.slug~*""{genre}"";
                    where genres.slug~*""{genre}""*;
                    where platforms.name~*""{platform}""*;
                    sort rating desc;
                    limit 20;";
            }
            return query;
        }
       
    }

 
}