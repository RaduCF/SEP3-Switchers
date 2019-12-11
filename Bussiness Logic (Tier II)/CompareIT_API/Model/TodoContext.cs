using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI_V4;
using Microsoft.EntityFrameworkCore;


namespace CompareIT_API.Model
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<TodoItem> TodoItems { get; set; }
        }
    }


