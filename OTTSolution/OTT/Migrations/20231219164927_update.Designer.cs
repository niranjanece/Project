﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OTT.Context;

#nullable disable

namespace OTT.Migrations
{
    [DbContext(typeof(OTTContext))]
    [Migration("20231219164927_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OTT.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("OTT.Models.SubscriptionPlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("PlanId");

                    b.ToTable("SubscriptionPlans");
                });

            modelBuilder.Entity("OTT.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Key")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OTT.Models.UserSubscription", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email", "PlanId");

                    b.HasIndex("PlanId");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("OTT.Models.WatchHistory", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email", "Details");

                    b.ToTable("WatchHistories");
                });

            modelBuilder.Entity("OTT.Models.WatchList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("MovieId");

                    b.ToTable("WatchLists");
                });

            modelBuilder.Entity("OTT.Models.UserSubscription", b =>
                {
                    b.HasOne("OTT.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OTT.Models.SubscriptionPlan", "subscription")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subscription");

                    b.Navigation("user");
                });

            modelBuilder.Entity("OTT.Models.WatchHistory", b =>
                {
                    b.HasOne("OTT.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("OTT.Models.WatchList", b =>
                {
                    b.HasOne("OTT.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OTT.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
