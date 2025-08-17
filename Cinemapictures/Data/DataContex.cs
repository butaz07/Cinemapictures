using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinemapictures.Models.Entities;

    public class DataContex : DbContext
    {
        public DataContex (DbContextOptions<DataContex> options)
            : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; } 
    public DbSet<Client> Clients { get; set; } 
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Kind> Kinds { get; set; }
    public DbSet<Rent> Rents { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Movie) 
            .WithMany()
            .HasForeignKey(i => i.MovieId) 
            .OnDelete(DeleteBehavior.Restrict); 
                                                  
       
        modelBuilder.Entity<InvoiceDetail>()
            .HasOne(id => id.Movie)
            .WithMany()
            .HasForeignKey(id => id.MovieId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
