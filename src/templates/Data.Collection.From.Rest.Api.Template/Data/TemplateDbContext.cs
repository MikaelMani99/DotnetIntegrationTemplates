using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Data.Collection.From.Rest.Api.Template.Models.Entities;
using System.Threading.Tasks;

namespace Data.Collection.From.Rest.Api.Template.Context
{
    public class TemplateDbContext: DbContext
    {
        private readonly String _connectionString;

        public TemplateDbContext() { }
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options, String connectionString) : base(options) 
        { 
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

    }
}