﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Gate.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240709181714_InitModel")]
    partial class InitModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Core.Sells.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.Property<int>("RuleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("RuleId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.Core.Sells.PaymentRules.PaymentDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("PaymentRuleId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PaymentRuleId");

                    b.ToTable("PaymentDates");
                });

            modelBuilder.Entity("Domain.Core.Sells.PaymentRules.PaymentRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PaymentRules");
                });

            modelBuilder.Entity("Domain.Core.Sells.SalableObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<double>("PriceBuy")
                        .HasColumnType("double precision");

                    b.Property<double>("PriceSell")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("SalableObject");

                    b.HasDiscriminator().HasValue("SalableObject");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Core.Service.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Domain.Core.Service.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RootCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RootCategoryId");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("Domain.Core.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronomic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Core.Service.Service", b =>
                {
                    b.HasBaseType("Domain.Core.Sells.SalableObject");

                    b.Property<int?>("CardId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasIndex("CardId");

                    b.HasIndex("CategoryId");

                    b.HasDiscriminator().HasValue("Service");
                });

            modelBuilder.Entity("Domain.Core.Sells.Payment", b =>
                {
                    b.HasOne("Domain.Core.Users.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Users.User", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Sells.PaymentRules.PaymentRule", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Provider");

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("Domain.Core.Sells.PaymentRules.PaymentDate", b =>
                {
                    b.HasOne("Domain.Core.Sells.PaymentRules.PaymentRule", null)
                        .WithMany("Dates")
                        .HasForeignKey("PaymentRuleId");
                });

            modelBuilder.Entity("Domain.Core.Sells.SalableObject", b =>
                {
                    b.HasOne("Domain.Core.Sells.Payment", null)
                        .WithMany("Cart")
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Domain.Core.Service.Card", b =>
                {
                    b.HasOne("Domain.Core.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Core.Service.Category", b =>
                {
                    b.HasOne("Domain.Core.Service.Category", "RootCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("RootCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RootCategory");
                });

            modelBuilder.Entity("Domain.Core.Users.User", b =>
                {
                    b.HasOne("Domain.Core.Service.Service", null)
                        .WithMany("Providers")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("Domain.Core.Service.Service", b =>
                {
                    b.HasOne("Domain.Core.Service.Card", null)
                        .WithMany("ConnectedServices")
                        .HasForeignKey("CardId");

                    b.HasOne("Domain.Core.Service.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Core.Sells.Payment", b =>
                {
                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Domain.Core.Sells.PaymentRules.PaymentRule", b =>
                {
                    b.Navigation("Dates");
                });

            modelBuilder.Entity("Domain.Core.Service.Card", b =>
                {
                    b.Navigation("ConnectedServices");
                });

            modelBuilder.Entity("Domain.Core.Service.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("Domain.Core.Service.Service", b =>
                {
                    b.Navigation("Providers");
                });
#pragma warning restore 612, 618
        }
    }
}
