using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CompareIT_API.Model_2
{
    public class TodoContext_2: DbContext
    {
            public TodoContext_2(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }
        public DbSet<UserList> ManageUsers { get; set; }
        }
    }





