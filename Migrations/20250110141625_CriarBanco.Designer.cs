﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoVendas.Data;

#nullable disable

namespace ProjetoVendas.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250110141625_CriarBanco")]
    partial class CriarBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoVendas.Modal.CLienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProjetoVendas.Modal.VendasModel", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenda"));

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VendedoridVendedor")
                        .HasColumnType("int");

                    b.Property<int>("cLienteIdCliente")
                        .HasColumnType("int");

                    b.HasKey("IdVenda");

                    b.HasIndex("VendedoridVendedor");

                    b.HasIndex("cLienteIdCliente");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("ProjetoVendas.Modal.VendedorModel", b =>
                {
                    b.Property<int>("idVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVendedor"));

                    b.Property<string>("NomeVendedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVendedor");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("ProjetoVendas.Modal.VendasModel", b =>
                {
                    b.HasOne("ProjetoVendas.Modal.VendedorModel", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedoridVendedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoVendas.Modal.CLienteModel", "cLiente")
                        .WithMany("Compras")
                        .HasForeignKey("cLienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");

                    b.Navigation("cLiente");
                });

            modelBuilder.Entity("ProjetoVendas.Modal.CLienteModel", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("ProjetoVendas.Modal.VendedorModel", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}