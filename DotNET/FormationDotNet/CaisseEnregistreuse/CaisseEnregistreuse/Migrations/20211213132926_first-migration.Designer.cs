﻿// <auto-generated />
using System;
using CaisseEnregistreuse.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaisseEnregistreuse.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211213132926_first-migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaisseEnregistreuse.Classes.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenteId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("CaisseEnregistreuse.Classes.Vente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Etat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalFromBase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypePaiement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ventes");
                });

            modelBuilder.Entity("CaisseEnregistreuse.Classes.Produit", b =>
                {
                    b.HasOne("CaisseEnregistreuse.Classes.Vente", null)
                        .WithMany("Produits")
                        .HasForeignKey("VenteId");
                });

            modelBuilder.Entity("CaisseEnregistreuse.Classes.Vente", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
