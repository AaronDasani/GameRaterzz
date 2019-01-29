

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameStarz.Models
{
    
    public class GameProfileBundle
    {
        public Game game{get;set;}
        public User user{get;set;}

        public Review formReview{get;set;}
        public ReviewResponse Comment{get;set;}


    }
}