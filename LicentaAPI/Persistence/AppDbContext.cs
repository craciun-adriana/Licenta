using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence
{
    /// <summary>
    /// Class used to connect database to API with <see cref="AppUser"/> as the Identity class.
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ReviewBook> ReviewBooks { get; set; }
        public DbSet<ReviewFilm> ReviewFilms { get; set; }
        public DbSet<ReviewSeries> ReviewSeries { get; set; }
        public DbSet<Series> Series { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
    }
}