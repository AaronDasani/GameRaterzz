using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace GameStarz.Models
{
    public class Like
    {
        [Key]
        public int like_id{get;set;}

        public int user_id{get;set;}
        public int review_id{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

        
    }
}