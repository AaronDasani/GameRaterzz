using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace GameStarz.Models
{
    public class Review
    {
        [Key]
        public int review_id{get;set;}

        [Required]
        [MinLength(5,ErrorMessage="Review should be atleast 5 characters long")]
        [MaxLength(200,ErrorMessage="Review exceeded the 200 character limit")]
        [Display(Name="Review")]
        public string text{get;set;}

        public int user_id{get;set;}
        public int gameId{get;set;}
        public User reviewer{get;set;}
        public Game reviewedGames{get;set;}
        public List<Like> likeCounts{get;set;}
        public List<ReviewResponse> responses{get;set;}

        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

        
    }
    public class ReviewResponse
    {
        [Key]
        public int reviewResponse_id{get;set;}

        [Required]
        [MinLength(5,ErrorMessage="Comment should be atleast 5 characters long")]
        [MaxLength(100,ErrorMessage="Comment exceeded the 100 character limit")]
        [Display(Name="Comment")]
        public string response{get;set;}

        public int user_id{get;set;}
        public int review_id{get;set;}
        public User respondent{get;set;}
        public Review theReview{get;set;}
        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

        
    }
}