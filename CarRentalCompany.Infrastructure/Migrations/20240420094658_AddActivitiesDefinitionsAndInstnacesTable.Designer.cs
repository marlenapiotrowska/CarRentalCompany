﻿// <auto-generated />
using System;
using CarRentalCompany.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    [DbContext(typeof(CarRentalCompanyDbContext))]
    [Migration("20240420094658_AddActivitiesDefinitionsAndInstnacesTable")]
    partial class AddActivitiesDefinitionsAndInstnacesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ActivityDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivitiesDefinitions");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ActivityInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivityDefinitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReceiptFormId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActivityDefinitionId");

                    b.HasIndex("ReceiptFormId");

                    b.ToTable("ActivitiesInstances");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ReceiptForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ReceiptForms");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ActivityInstance", b =>
                {
                    b.HasOne("CarRentalCompany.Infrastructure.Entities.ActivityDefinition", "ActivityDefinition")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalCompany.Infrastructure.Entities.ReceiptForm", "ReceiptForm")
                        .WithMany("Activities")
                        .HasForeignKey("ReceiptFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityDefinition");

                    b.Navigation("ReceiptForm");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ReceiptForm", b =>
                {
                    b.HasOne("CarRentalCompany.Infrastructure.Entities.Client", "Client")
                        .WithMany("ReceiptForms")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ActivityDefinition", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.Client", b =>
                {
                    b.Navigation("ReceiptForms");
                });

            modelBuilder.Entity("CarRentalCompany.Infrastructure.Entities.ReceiptForm", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}