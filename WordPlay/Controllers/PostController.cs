using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordPlay.Models;
using WordPlay.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace WordPlay.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext db;
        
        public PostController(UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                Post post = new Post() { Text = model.Text, UserId = user.Id, UserName = user.UserName };
                if (post.Text != null)
                {
                    db.Posts.Add(post);
                    await db.SaveChangesAsync();

                    return RedirectToAction("");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Post post = await db.Posts.FindAsync(id);
            if ( post.UserId == user.Id)
            {
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return RedirectToAction("");
            }

            return RedirectToAction("");
        }
    }
}
