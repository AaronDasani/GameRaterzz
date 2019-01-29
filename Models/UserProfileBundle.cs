

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

    public class UserProfileBundle
    {
        public User current_user{get;set;}
        public List<Game> RecentlyReviewdGame{get;set;}
    }

}