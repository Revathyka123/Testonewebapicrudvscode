

using testone.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace testone.Model.Entities;

public class DbaseContext:DbContext
{

   
     public DbaseContext(DbContextOptions<DbaseContext> options) : base(options)
    {

    }
    public DbSet<Ship> TestShipping {get; set;}
}

