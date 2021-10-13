using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JapaneseStudy.Models;

namespace JapaneseStudy.Data
{
    public class JapaneseStudyContext : DbContext
    {
        public JapaneseStudyContext(DbContextOptions<JapaneseStudyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KanjiReview>()
                .HasKey(k => new { k.PersonID, k.KanjiID });
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Kanji> Kanji { get; set; }
        public DbSet<KanjiReview> KanjiReview { get; set; }
    }
}
