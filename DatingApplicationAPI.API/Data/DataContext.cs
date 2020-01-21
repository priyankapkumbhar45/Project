using Microsoft.EntityFrameworkCore;
using DatingApplicationAPI.API.Models;
namespace DatingApplicationAPI.API.Data
{
    public class DataContext :DbContext
    {
       public DataContext(DbContextOptions<DataContext> options):base(options)      
       {
           
       } 
       public DbSet<Value> Values { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Photo> Photos { get; set; }
    }
}