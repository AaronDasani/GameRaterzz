using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using GameStarz.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GameStarz
{

    public class DashboardController:Controller
    {
        private DatabaseContext dbContext;
        public DashboardController(DatabaseContext context)
        {
            dbContext = context;
        }


        // query games function
        public async Task<DashboardGameBundle> FetchGames(string gameName=null)
        {
            ViewBag.MaxRating=(int)HttpContext.Session.GetInt32("MaxRating");
            ViewBag.MinRating=(int)HttpContext.Session.GetInt32("MinRating");
            var games=new List<Game>();
            if (gameName!=null)
            {
                games=await GamesProcessor.LoadGamesBasedOnSearch(gameName);
            }
            else
            {
                games=await GamesProcessor.LoadGamesBasedOnFilters(MinRating:ViewBag.MinRating,MaxRating:ViewBag.MaxRating,genre:HttpContext.Session.GetString("Genre"),platform:HttpContext.Session.GetString("Platform")); 
            }

            var DashboardBundle=new DashboardGameBundle();

            if (games.Count>0)
            {
                DashboardBundle.popularGames= await GamesProcessor.LoadPopularGames();
                
            }
            DashboardBundle.games=games;
           
            return DashboardBundle;
        } 


        [HttpGet("Home")]
        
        public async Task<IActionResult> Home(){
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}

            int? Maxrating=HttpContext.Session.GetInt32("MaxRating");
            int? Minrating=HttpContext.Session.GetInt32("MinRating");
            if (Maxrating==null)
            {
                HttpContext.Session.SetInt32("MaxRating", 100);
            }
             if (Minrating==null)
            {
                HttpContext.Session.SetInt32("MinRating", 1);
            }
            var DashboardBundle= await FetchGames((string)TempData["gameName"]);
            if (DashboardBundle.games.Count<1)
            {
                return RedirectToAction("ForbiddenPage","ErrorPage");
            }
            DashboardBundle.user=dbContext.Users.FirstOrDefault(user=>user.user_id==user_id);
            HttpContext.Session.SetString("userName",DashboardBundle.user.firstname +" "+DashboardBundle.user.lastname);

            ViewBag.filters=new Dictionary<string,object> {
                {"MinRating",(int)HttpContext.Session.GetInt32("MinRating")},
                {"MaxRating",(int)HttpContext.Session.GetInt32("MaxRating")},
                {"Platform",HttpContext.Session.GetString("Platform")},
                {"Genre",HttpContext.Session.GetString("Genre")}

            };
            ViewBag.userName=HttpContext.Session.GetString("userName");
            return View("Dashboard",DashboardBundle);
            

        }

        [HttpGet("UserProfile")]
        public IActionResult UserProfile()
        {
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}

            var UserProfile_bundle=new UserProfileBundle();
            
            UserProfile_bundle.current_user=dbContext.Users.Include(u=>u.reviews).ThenInclude(r=>r.reviewedGames).ThenInclude(g=>g.cover).FirstOrDefault(u=>u.user_id==user_id);

            ViewBag.userName=HttpContext.Session.GetString("userName");

            return View("UserProfile",UserProfile_bundle);
           
        }





        [HttpGet("ShowGame/{gameId}")]
        public async Task<IActionResult> ShowGame(int gameId){

            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}

            var gameProfileBundle= new GameProfileBundle();
            gameProfileBundle.user=dbContext.Users.FirstOrDefault(user=>user.user_id==user_id);
           

            if(dbContext.Games.FirstOrDefault(game=>game.gameId==gameId)==null)
            {
                Game game=await GamesProcessor.ShowOneGame(gameId);
                SaveGame(game);
                
            }
     
            gameProfileBundle.game=dbContext.Games.Include(g=>g.cover)
                                                .Include(g=>g.game_Genres).ThenInclude(g=>g.genre)
                                                .Include(g=>g.game_Companies).ThenInclude(invc=>invc.company)
                                                .Include(g=>g.game_Platforms).ThenInclude(p=>p.platform)
                                                .Include(g=>g.screenshots)
                                                .Include(g=>g.videos)
                                                .Include(g=>g.expansions).ThenInclude(e=>e.cover)
                                                .Include(g=>g.Reviews).ThenInclude(r=>r.reviewer)                                                
                                                .Include(g=>g.Reviews).ThenInclude(r=>r.likeCounts)
                                                .Include(g=>g.Reviews).ThenInclude(r=>r.responses)
                                                .FirstOrDefault(g=>g.gameId==gameId);

           
            gameProfileBundle.formReview=new Review();
            gameProfileBundle.Comment=new ReviewResponse();
            ViewBag.userName=HttpContext.Session.GetString("userName");
            return View("GameProfile",gameProfileBundle);

        }

        public void SaveGame(Game game)
        {
            game.user_id=(int)HttpContext.Session.GetInt32("user_id");

            if (game.expansions !=null)
            {
                foreach (var expansion in game.expansions)
                {
                    expansion.cover.expansion_id=expansion.id;
                    expansion.cover.gameId=expansion.id;
                }
                
            }
            
            dbContext.Games.Add(game);
            
            if (game.genres !=null)
            {
                foreach (var genre in game.genres)
                {
                    if(dbContext.Genres.All(g=>g.genre_id!=genre.genre_id))
                    {
                        dbContext.Genres.Add(genre); 
                    }
                    var gameGenre=new GameGenres();
                    gameGenre.gameId=game.gameId;
                    gameGenre.genre_id=genre.genre_id;
                    dbContext.GameGenres.Add(gameGenre);

                }
            }
            
            if (game.involved_companies !=null)
            {
                foreach (var involComp in game.involved_companies)
                {
                    if(dbContext.Companies.All(comp=>comp.company_id!=involComp.company.company_id))
                    {
                        dbContext.Companies.Add(involComp.company); 
                    }
                    var gameCompany=new GameCompanies();
                    gameCompany.company_id=involComp.company.company_id;
                    gameCompany.gameId=game.gameId;
                    dbContext.GameCompanies.Add(gameCompany);

                }
            }
            

           if(game.platforms !=null)
            {
               foreach (var platform in game.platforms)
                {
                    if(dbContext.Platforms.All(p=>p.platform_id!=platform.platform_id))
                    {
                        dbContext.Platforms.Add(platform); 
                    }
                    var gamePlatform=new GamePlatforms();
                    gamePlatform.gameId=game.gameId;
                    gamePlatform.platform_id=platform.platform_id;
                    dbContext.GamePlatforms.Add(gamePlatform);


                }
            }
            
            dbContext.SaveChanges();

        } 



        [HttpGet("fetchGenres")]
        public async Task<IActionResult> FetchGenres(){
                
            var filters= await GamesProcessor.FetchGenres();

            return Json(filters.genres);
        }
        
        [HttpGet("fetchPlatforms")]
        public IActionResult FetchPlatforms(){
                
            var filters= new Filters();

            return Json(filters.platforms);
        }



        [HttpPost("FetchGamesBaseOnRating")]
        public IActionResult FetchGamesBaseOnRating(RatingForm rating_form){
            
            HttpContext.Session.SetInt32("MaxRating", (int)rating_form.MaxRating);
            HttpContext.Session.SetInt32("MinRating", (int)rating_form.MinRating);
            
            Console.WriteLine(rating_form.MaxRating +","+ rating_form.MinRating);

            return RedirectToAction("Home");
        }

        [HttpGet("fetchGameBaseOnGenres/{genre}")]
        public async Task<IActionResult> FetchGameBaseOnGenres(string genre){
           

            HttpContext.Session.SetString("Genre", genre);
            var DashboardBundle= await FetchGames();
            ViewBag.filters=new Dictionary<string,object> {
                {"MinRating",(int)HttpContext.Session.GetInt32("MinRating")},
                {"MaxRating",(int)HttpContext.Session.GetInt32("MaxRating")},
                {"Platform",HttpContext.Session.GetString("Platform")},
                {"Genre",HttpContext.Session.GetString("Genre")}

            };
            ViewBag.userName=HttpContext.Session.GetString("userName");
            return View("Dashboard",DashboardBundle);

        }

        [HttpGet("fetchGameBaseOnPlatform/{platform}")]
        public async Task<IActionResult> FetchGameBaseOnPlatform(string platform){
           

            HttpContext.Session.SetString("Platform", platform);
            var DashboardBundle= await FetchGames();
            ViewBag.filters=new Dictionary<string,object> {
                {"MinRating",(int)HttpContext.Session.GetInt32("MinRating")},
                {"MaxRating",(int)HttpContext.Session.GetInt32("MaxRating")},
                {"Platform",HttpContext.Session.GetString("Platform")},
                {"Genre",HttpContext.Session.GetString("Genre")}

            };
            ViewBag.userName=HttpContext.Session.GetString("userName");
            return View("Dashboard",DashboardBundle);

        }

        [HttpPost("fetchGameBaseOnSearch")]
        public async Task<IActionResult> FetchGameBaseOnSearch(string gameName){

            if (ModelState.IsValid)
            {
                TempData["gameName"]=gameName;
                return RedirectToAction("Home");
            }

            var DashboardBundle= await FetchGames();
            ViewBag.filters=new Dictionary<string,object> {
                {"MinRating",(int)HttpContext.Session.GetInt32("MinRating")},
                {"MaxRating",(int)HttpContext.Session.GetInt32("MaxRating")},
                {"Platform",HttpContext.Session.GetString("Platform")},
                {"Genre",HttpContext.Session.GetString("Genre")}

            };
            ViewBag.userName=HttpContext.Session.GetString("userName");
           return View("Dashboard",DashboardBundle);
           

        }
    
        // remove filter tag
        [HttpGet("RemoveFilterTag/{filter}")]
        public IActionResult RemoveFilterTag(string filter){
            HttpContext.Session.Remove(filter);
            
            return RedirectToAction("Home");

        }


        // ------------------Review Feature---------------------

// Post review
        [HttpPost("addReview")]
        public IActionResult AddReview(GameProfileBundle bundle)
        {
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}
            var postedReview=bundle.formReview;
            if (ModelState.IsValid)
            {
                postedReview.user_id=(int)user_id;
                dbContext.Reviews.Add(postedReview);
                dbContext.SaveChanges();
                return RedirectToAction("ShowGame",new{gameId=postedReview.gameId});
            }

            var gameProfileBundle= new GameProfileBundle();
            gameProfileBundle.game=dbContext.Games.Include(g=>g.cover)
                                                .Include(g=>g.game_Genres).ThenInclude(g=>g.genre)
                                                .Include(g=>g.game_Companies).ThenInclude(invc=>invc.company)
                                                .Include(g=>g.game_Platforms).ThenInclude(p=>p.platform)
                                                .Include(g=>g.screenshots)
                                                .Include(g=>g.videos)
                                                .Include(g=>g.expansions)
                                                .Include(g=>g.Reviews).ThenInclude(r=>r.likeCounts)
                                                // .Include(g=>g.Reviews).ThenInclude(r=>r.responses)
                                                .FirstOrDefault(g=>g.gameId==postedReview.gameId);

            gameProfileBundle.formReview=new Review();
            gameProfileBundle.Comment=new ReviewResponse();

            return View("GameProfile",gameProfileBundle);
        }

// Post Comment
        [HttpPost("addComment")]
        public IActionResult AddComment(GameProfileBundle bundle)
        {
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}

            var postedComment=bundle.Comment;
            if (ModelState.IsValid)
            {
                postedComment.user_id=(int)user_id;
                dbContext.ReviewResponses.Add(postedComment);
                dbContext.SaveChanges();
                int totalComment=dbContext.ReviewResponses.Where(c=>c.review_id==postedComment.review_id).Count();

                var newCommentInfo= new Dictionary<string,object>{
                    {"userName",HttpContext.Session.GetString("userName")},
                    {"comment",postedComment},
                    {"totalComment",totalComment},                
                };

                return Json(newCommentInfo);

            }


            return Json("Invalid");
        }

// Like Review
        [HttpGet("like/{review_id}/{likeCount}")]
        public IActionResult LikeReview(int review_id,int likeCount)
        {
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}

         
            if (dbContext.Likes.Where(l=>l.user_id==user_id).FirstOrDefault(l=>l.review_id==review_id)==null)
            {
                var likeModel=new Like();
                likeModel.review_id=review_id;
                likeModel.user_id=(int)user_id;
                dbContext.Likes.Add(likeModel);
                dbContext.SaveChanges();
                var likeCounts=likeCount+1; 
                return Json(likeCounts);
            }
            int SavedlikeCount=dbContext.Likes.Where(l=>l.review_id==review_id).Count();
            return Json(SavedlikeCount);
        }

// View All Comments
        [HttpGet("viewComments/{review_id}")]
        public IActionResult ViewAllComments(int review_id)
        {
            var user_id=HttpContext.Session.GetInt32("user_id");
            if (user_id==null){return RedirectToAction("LoginAndRegister", "LoginAndRegister");}


            var Comments=dbContext.ReviewResponses.Include(c=>c.respondent).Where(c=>c.review_id==review_id).OrderBy(c=>c.created_at).ToList();
            return Json(Comments);
        }






    }
}