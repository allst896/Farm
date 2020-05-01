﻿// <auto-generated />
using System;
using Farm.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Farm.Models.Migrations
{
    [DbContext(typeof(FarmContext))]
    partial class FarmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Farm.Models.Db.Animals", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<int>("AnimalType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Badge")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<int>("DamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RelocationsRelocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SaleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SexType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SireId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VaccinationsVaccinationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId");

                    b.HasIndex("LocationId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("RelocationsRelocationId");

                    b.HasIndex("SaleId");

                    b.HasIndex("VaccinationsVaccinationId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Farm.Models.Db.Buyers", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Farm.Models.Db.Locations", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Acreage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Farm.Models.Db.Machinery", b =>
                {
                    b.Property<int>("MachineryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Identification")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PurchasesPurchaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RelocationsRelocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SalesSaleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MachineryId");

                    b.HasIndex("PurchasesPurchaseId");

                    b.HasIndex("RelocationsRelocationId");

                    b.HasIndex("SalesSaleId");

                    b.ToTable("Machinery");
                });

            modelBuilder.Entity("Farm.Models.Db.Purchases", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PossessionType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Unit")
                        .HasColumnType("INTEGER");

                    b.HasKey("PurchaseId");

                    b.HasIndex("LocationId");

                    b.HasIndex("SellerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Farm.Models.Db.Relocations", b =>
                {
                    b.Property<int>("RelocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PossessionType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RelocationDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("RelocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Relocations");
                });

            modelBuilder.Entity("Farm.Models.Db.Sales", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PossessionType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Unit")
                        .HasColumnType("INTEGER");

                    b.HasKey("SaleId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Farm.Models.Db.Sellers", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("SellerId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Farm.Tracker.Models.Vaccinations", b =>
                {
                    b.Property<int>("VaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Symptoms")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Unit")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VaccinationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vaccine")
                        .HasColumnType("TEXT");

                    b.HasKey("VaccinationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("Farm.Models.Db.Animals", b =>
                {
                    b.HasOne("Farm.Models.Db.Locations", "Locations")
                        .WithMany("Animals")
                        .HasForeignKey("LocationId");

                    b.HasOne("Farm.Models.Db.Purchases", "Purchases")
                        .WithMany("AnimalId")
                        .HasForeignKey("PurchaseId");

                    b.HasOne("Farm.Models.Db.Relocations", null)
                        .WithMany("AnimalId")
                        .HasForeignKey("RelocationsRelocationId");

                    b.HasOne("Farm.Models.Db.Sales", "Sales")
                        .WithMany("AnimalId")
                        .HasForeignKey("SaleId");

                    b.HasOne("Farm.Tracker.Models.Vaccinations", null)
                        .WithMany("Animal")
                        .HasForeignKey("VaccinationsVaccinationId");
                });

            modelBuilder.Entity("Farm.Models.Db.Machinery", b =>
                {
                    b.HasOne("Farm.Models.Db.Purchases", null)
                        .WithMany("MachineryId")
                        .HasForeignKey("PurchasesPurchaseId");

                    b.HasOne("Farm.Models.Db.Relocations", null)
                        .WithMany("MachineryId")
                        .HasForeignKey("RelocationsRelocationId");

                    b.HasOne("Farm.Models.Db.Sales", null)
                        .WithMany("MachineryId")
                        .HasForeignKey("SalesSaleId");
                });

            modelBuilder.Entity("Farm.Models.Db.Purchases", b =>
                {
                    b.HasOne("Farm.Models.Db.Locations", "Locations")
                        .WithMany("Purchases")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Farm.Models.Db.Sellers", "Sellers")
                        .WithMany()
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("Farm.Models.Db.Relocations", b =>
                {
                    b.HasOne("Farm.Models.Db.Locations", "Locations")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Farm.Models.Db.Sales", b =>
                {
                    b.HasOne("Farm.Models.Db.Buyers", "Buyers")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("Farm.Models.Db.Locations", "Locations")
                        .WithMany("Sales")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Farm.Tracker.Models.Vaccinations", b =>
                {
                    b.HasOne("Farm.Models.Db.Locations", "Locations")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
