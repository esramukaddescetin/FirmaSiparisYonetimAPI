﻿// <auto-generated />
using System;
using FirmaSiparisYonetimDataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirmaSiparisYonetimDataLayer.Migrations
{
    [DbContext(typeof(SiparisYonetimDBContext))]
    [Migration("20240107192347_Migration_2")]
    partial class Migration_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FirmaSiparisYonetimDataLayer.Tables.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Onay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SiparisIzinBaslangicSaati")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SiparisIzinBitisSaati")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Firma");
                });

            modelBuilder.Entity("FirmaSiparisYonetimDataLayer.Tables.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<string>("KisiAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SiparisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Siparis");
                });

            modelBuilder.Entity("FirmaSiparisYonetimDataLayer.Tables.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Urun");
                });
#pragma warning restore 612, 618
        }
    }
}
