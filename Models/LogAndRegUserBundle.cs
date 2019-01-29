using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace GameStarz.Models
{
    public class LogAndRegUserBundle
    {
        public User register_user{get;set;}
        public LoginUser login_user{get;set;}

    }

}