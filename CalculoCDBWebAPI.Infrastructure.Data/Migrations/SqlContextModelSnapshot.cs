﻿// <auto-generated />
using System;
using CalculoCDBWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalculoCDBWebAPI.Infrastructure.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CalculoCDBWebAPI.Domain.Models.Calculo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("QuantidadeMeses")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorAplicado")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorBruto")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorLiquido")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Calculos");
                });

            modelBuilder.Entity("CalculoCDBWebAPI.Domain.Models.Taxa", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("ValorPercentual")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("Id");

                    b.ToTable("Taxas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "TB",
                            ValorPercentual = 108.0
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "CDI",
                            ValorPercentual = 0.90000000000000002
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
