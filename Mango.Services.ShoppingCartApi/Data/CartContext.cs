using Mango.Services.ShoppingCartApi.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartApi.Data
{
    public class CartContext:DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
