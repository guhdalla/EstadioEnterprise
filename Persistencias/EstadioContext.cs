using Fiap.Aula03.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Aula03.Web.Persistencias
{
    public class EstadioContext : DbContext
    {
        //Conjunto de clientes que estão no banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Corrida> Corridas { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Desconto> Descontos { get; set; }

        //Construtor que recebe as options e envia para o construtor do pai
        public EstadioContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<Desconto>().HasKey(i => new { i.CorridaId, i.DroneId });

            //Configurar o relacionamento da tabela associativa com o pedido
            modelBuilder.Entity<Desconto>()
                .HasOne(i => i.Corrida)
                .WithMany(i => i.Decontos)
                .HasForeignKey(i => i.CorridaId);

            //Configurar o relacionamento da tabela associativa com o produto
            modelBuilder.Entity<Desconto>()
                .HasOne(i => i.Drone)
                .WithMany(i => i.Descontos)
                .HasForeignKey(i => i.DroneId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
