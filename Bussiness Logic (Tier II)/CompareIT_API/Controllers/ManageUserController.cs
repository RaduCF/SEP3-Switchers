using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace CompareIT_API.Controllers
{
    [Route("api/ManageUser")]
    public class ManageUserController : ControllerBase
    {
        private readonly TodoContext context;

        public ManageUserController(TodoContext context)
        {
            this.context = context;
        }

        //GET by query string
        [HttpGet]
        public Boolean Login(string username, string pass)
        {
            return true;
        }

        /*
        //POST getting a list by a received string
        [HttpPost]
        public Boolean Login(string username, string pass)
        {
            return true;
        }
        */

    }
}
