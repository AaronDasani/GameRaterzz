﻿// <auto-generated />
using System;
using GameStarz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStarz.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190125025702_removenotmapped")]
    partial class removenotmapped
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GameStarz.Models.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_id");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("companyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GameStarz.Models.Cover", b =>
                {
                    b.Property<int>("cover_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_id");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<string>("image_id");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("cover_id");

                    b.HasIndex("gameId")
                        .IsUnique();

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("GameStarz.Models.Expansion", b =>
                {
                    b.Property<int>("expansion_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_Id");

                    b.Property<int?>("cover_id");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("expansion_id");

                    b.HasIndex("cover_id");

                    b.HasIndex("gameId");

                    b.ToTable("Expansions");
                });

            modelBuilder.Entity("GameStarz.Models.Game", b =>
                {
                    b.Property<int>("gameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_Id");

                    b.Property<string>("name");

                    b.Property<double>("popularity");

                    b.Property<double>("rating");

                    b.Property<DateTime>("release_date");

                    b.Property<string>("summary");

                    b.Property<int>("user_id");

                    b.HasKey("gameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameStarz.Models.GameGenres", b =>
                {
                    b.Property<int>("gameGenre_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<int>("genre_id");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("gameGenre_id");

                    b.HasIndex("gameId");

                    b.HasIndex("genre_id");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("GameStarz.Models.GamePlatforms", b =>
                {
                    b.Property<int>("gamePlatform_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<int>("platform_id");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("gamePlatform_id");

                    b.HasIndex("gameId");

                    b.HasIndex("platform_id");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("GameStarz.Models.Genre", b =>
                {
                    b.Property<int>("genre_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_id");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<string>("slug");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("genre_id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GameStarz.Models.InvolvedCompany", b =>
                {
                    b.Property<int>("involveCompany_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_id");

                    b.Property<int>("companyId");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("involveCompany_id");

                    b.HasIndex("companyId");

                    b.HasIndex("gameId");

                    b.ToTable("InvolvedCompanies");
                });

            modelBuilder.Entity("GameStarz.Models.Platform", b =>
                {
                    b.Property<int>("platform_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_id");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("platform_id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GameStarz.Models.Screenshot", b =>
                {
                    b.Property<int>("screenshot_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_Id");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<string>("image_id");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("screenshot_id");

                    b.HasIndex("gameId");

                    b.ToTable("Screenshots");
                });

            modelBuilder.Entity("GameStarz.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameStarz.Models.Video", b =>
                {
                    b.Property<int>("TheVideo_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Api_Id");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("gameId");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.Property<string>("video_id");

                    b.HasKey("TheVideo_id");

                    b.HasIndex("gameId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("GameStarz.Models.Cover", b =>
                {
                    b.HasOne("GameStarz.Models.Game")
                        .WithOne("cover")
                        .HasForeignKey("GameStarz.Models.Cover", "gameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.Expansion", b =>
                {
                    b.HasOne("GameStarz.Models.Cover", "cover")
                        .WithMany()
                        .HasForeignKey("cover_id");

                    b.HasOne("GameStarz.Models.Game")
                        .WithMany("expansions")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.GameGenres", b =>
                {
                    b.HasOne("GameStarz.Models.Game", "game")
                        .WithMany("game_Genres")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStarz.Models.Genre", "genre")
                        .WithMany()
                        .HasForeignKey("genre_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.GamePlatforms", b =>
                {
                    b.HasOne("GameStarz.Models.Game", "game")
                        .WithMany("game_Platforms")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStarz.Models.Platform", "platform")
                        .WithMany()
                        .HasForeignKey("platform_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.InvolvedCompany", b =>
                {
                    b.HasOne("GameStarz.Models.Company", "company")
                        .WithMany("gameInvested")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStarz.Models.Game")
                        .WithMany("involved_companies")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.Screenshot", b =>
                {
                    b.HasOne("GameStarz.Models.Game")
                        .WithMany("screenshots")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStarz.Models.Video", b =>
                {
                    b.HasOne("GameStarz.Models.Game")
                        .WithMany("videos")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
