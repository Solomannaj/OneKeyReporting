using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataExtractionTool.DataLayer.Models;
using DataExtractionTool.DataLayer.Repositories;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _context;

        public LoginController( IUserRepository context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<User> PostLogin(User inputUser)
        {
          var user =  await _context.FindByExpressionAsync(x=>x.Email== inputUser.Email && x.Password==inputUser.Password);
          return user.FirstOrDefault();

        }
    }
}
