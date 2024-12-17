using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_Lucas_Lab2.Models;
using Nume_Pren_Lab2.Models;

namespace Pop_Lucas_Lab2.Data
{
    public class Pop_Lucas_Lab2Context : DbContext
    {
        public Pop_Lucas_Lab2Context (DbContextOptions<Pop_Lucas_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Pop_Lucas_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Pop_Lucas_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Nume_Pren_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
    }
}
