﻿using Electronic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic.Data
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }
    }
}
