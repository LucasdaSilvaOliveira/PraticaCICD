using Microsoft.EntityFrameworkCore;
using PraticaCICD.Api.Data.Entities;

namespace PraticaCICD.Api.Data.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Roupa> Roupas { get; set; }
    }
}
