using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameStarz.Models
{
    
    public class DashboardGameBundle
    {
        public List<Game> games{get;set;}
        public List<PopularGame> popularGames{get;set;}
        public User user{get;set;}
        public RatingForm rating_form{get;set;}



    }
}