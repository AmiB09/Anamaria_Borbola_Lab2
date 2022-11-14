using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anamaria_Borbola_Lab2.Models;

namespace Anamaria_Borbola_Lab2.Data
{
    public class Anamaria_Borbola_Lab2Context : DbContext
    {
        public Anamaria_Borbola_Lab2Context (DbContextOptions<Anamaria_Borbola_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Anamaria_Borbola_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Anamaria_Borbola_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Anamaria_Borbola_Lab2.Models.Author> Author { get; set; }

        public DbSet<Anamaria_Borbola_Lab2.Models.Category> Category { get; set; }

        public DbSet<Anamaria_Borbola_Lab2.Models.Member> Member { get; set; }

        public DbSet<Anamaria_Borbola_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
