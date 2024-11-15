

using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Galaxy.Storage.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Message> Messages { get; set; }
    }
}
