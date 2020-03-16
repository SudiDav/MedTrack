using MedTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Approvisionnement> Approvisionnements { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<ConfirmationReception> ConfirmationReceptions { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Distributeur> Distributeurs { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<Transporteur> Transporteurs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
