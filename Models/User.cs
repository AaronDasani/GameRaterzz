using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace GameStarz.Models
{
    public class User
    {
        [Key]
        public int user_id{get;set;}

        [Required]
        [Display(Name="First Name")]
        [MaxLength(30,ErrorMessage="First name exceeded the maximum 30 characters")]
        [MinLength(2,ErrorMessage="First name should be atleast 2 chracters")]
        public string firstname{get;set;}

        [Required]
        [Display(Name="Last Name")]
        [MaxLength(30,ErrorMessage="Last name exceeded the maximum 30 characters")]
        [MinLength(2,ErrorMessage="Last name should be atleast 2 chracters")]
        public string lastname{get;set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string email{get;set;}

        [Required]
        [MinLength(8,ErrorMessage="Password should be atleast 8 chracters")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password{get;set;}

        [Required]
        [NotMapped]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Confirm Password does not Match")]
        public string confirmPassword{get;set;}

        public DateTime created_at{get;set;}=DateTime.Now;
        public DateTime updated_at{get;set;}=DateTime.Now;

        public List<Review> reviews{get;set;}
        public List<Like> likedReviews{get;set;}

        // public List<ReviewResponse> reviewsResponded{get;set;}


    }
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string LoginEmail{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string LoginPassword{get;set;}
    }

    public class RegisterNLogin
    {
        public User registerUser{get;set;}
        public LoginUser loginUser{get;set;}
    }
}