using Microsoft.EntityFrameworkCore;
using back.Models;
namespace back.Repository;
public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions options): base(options){}
    public DbSet<User> users {get;set;}
    public DbSet<Cliente> clientes {get;set;}
    public DbSet<Loja> lojas {get;set;}

}