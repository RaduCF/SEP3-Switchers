﻿using Microsoft.EntityFrameworkCore;

namespace UserAPI.Model
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Login>Login { get; set; }



    }
}
