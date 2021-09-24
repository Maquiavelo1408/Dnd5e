using Dnd5e.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
        public DbSet<AttributeSkill> AttributeSkills { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Dnd5e;Trusted_Connection=True;");
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(c => new { c.CharacterId, c.SkillId });
            modelBuilder.Entity<AttributeSkill>()
                .HasKey(c => new { c.AttributeId, c.SkillId });
        }
    }
}
