using Microsoft.EntityFrameworkCore;
using CanteiroAPI.Models;

namespace CanteiroAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios {get; set;}
    public DbSet<Equipamento> Equipamentos {get; set;}
    public DbSet<Tarefa> Tarefas {get; set;}

}