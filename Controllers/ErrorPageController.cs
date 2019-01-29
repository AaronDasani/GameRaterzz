

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStarz.Models;

namespace GameStarz
{
    public class ErrorPageController:Controller
    {
        [HttpGet("ForbiddenPage")]
        public IActionResult ForbiddenPage()
        {
            return View("ForbiddenPage");
        }
    }


}