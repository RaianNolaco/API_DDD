using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public String ObterStringDeConexao() 
        {
            return "COLOCAR CONEXAO AQUI";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer(ObterStringDeConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }



    }
}
