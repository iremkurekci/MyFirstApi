using ApiProject.API.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiProject.API.Context
{
    public class IlContext : DbContext
    {
        public IlContext()
        {
        }

        public IlContext(DbContextOptions<IlContext> options) : base (options)
        {}

        public DbSet<Il> il {get; set;}
    }
}