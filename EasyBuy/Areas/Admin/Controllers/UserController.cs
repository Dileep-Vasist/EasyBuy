using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBuy.DataAccess.Data;
using EasyBuy.DataAccess.Repository.IRepository;
using EasyBuy.Models;
using EasyBuy.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SQLitePCL;

namespace EasyBuy.Areas.Admin.Controllers
{
    /// <summary>
    /// This class directly works on ApplicationDB Context instead of using UnitOfWork
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Employee)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            ////Mappimg between user and roles will be in UserRoles DB Table
            var userRole = _db.UserRoles.ToList();
            ////Contains All Roles
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u=>u.Id==roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company() {
                        Name = string.Empty
                    };
                    
                }
            }


            return Json(new { data = userList });
        }
        #endregion
    }
}