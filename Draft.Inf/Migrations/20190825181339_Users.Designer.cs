﻿// <auto-generated />
using System;
using Draft.Inf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Draft.Inf.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190825181339_Users")]
    partial class Users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Draft.Core.Entities.ArcTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefRating");

                    b.Property<int>("Division");

                    b.Property<int?>("GameTeamGameId");

                    b.Property<int?>("GameTeamTeamId");

                    b.Property<string>("Name");

                    b.Property<int>("OffRating");

                    b.Property<int?>("RecordId");

                    b.Property<int?>("StandingsId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("StandingsId");

                    b.HasIndex("TeamId");

                    b.HasIndex("GameTeamTeamId", "GameTeamGameId");

                    b.ToTable("ArcTeams");
                });

            modelBuilder.Entity("Draft.Core.Entities.Draft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Draft");
                });

            modelBuilder.Entity("Draft.Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayScore");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HomeScore");

                    b.Property<bool>("IsCompleted");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Draft.Core.Entities.GameTeam", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("GameId");

                    b.Property<int>("TeamSide");

                    b.HasKey("TeamId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameTeam");
                });

            modelBuilder.Entity("Draft.Core.Entities.Injury", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Injury");
                });

            modelBuilder.Entity("Draft.Core.Entities.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanTrade");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("MaxRosterSize");

                    b.Property<int>("PhaseType");

                    b.Property<int?>("SeasonId");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Phase");
                });

            modelBuilder.Entity("Draft.Core.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArcTeamId");

                    b.Property<int?>("ArcTeamId1");

                    b.Property<int>("Experience");

                    b.Property<bool>("IsRetired");

                    b.Property<int>("Position");

                    b.Property<int>("RookieRating");

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TeamId1");

                    b.Property<int>("VeteranRating");

                    b.Property<int?>("WaiverId");

                    b.HasKey("Id");

                    b.HasIndex("ArcTeamId");

                    b.HasIndex("ArcTeamId1");

                    b.HasIndex("TeamId");

                    b.HasIndex("TeamId1");

                    b.HasIndex("WaiverId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Draft.Core.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Losses");

                    b.Property<int>("Ties");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Draft.Core.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CurDate");

                    b.Property<int?>("DraftId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCompleted");

                    b.Property<int?>("StandingsId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("WaiverId");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

                    b.HasIndex("StandingsId");

                    b.HasIndex("WaiverId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Draft.Core.Entities.Standings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChampionId");

                    b.Property<int?>("EastChampId");

                    b.Property<int?>("WestChampId");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.HasIndex("EastChampId");

                    b.HasIndex("WestChampId");

                    b.ToTable("Standings");
                });

            modelBuilder.Entity("Draft.Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefRating");

                    b.Property<int>("Division");

                    b.Property<string>("Name");

                    b.Property<int>("OffRating");

                    b.Property<int?>("RecordId");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Draft.Core.Entities.Waiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Waiver");
                });

            modelBuilder.Entity("Draft.Inf.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TeamId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Draft.Core.Entities.ArcTeam", b =>
                {
                    b.HasOne("Draft.Core.Entities.Record", "Record")
                        .WithMany()
                        .HasForeignKey("RecordId");

                    b.HasOne("Draft.Core.Entities.Standings")
                        .WithMany("Teams")
                        .HasForeignKey("StandingsId");

                    b.HasOne("Draft.Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("Draft.Core.Entities.GameTeam", "GameTeam")
                        .WithMany()
                        .HasForeignKey("GameTeamTeamId", "GameTeamGameId");
                });

            modelBuilder.Entity("Draft.Core.Entities.GameTeam", b =>
                {
                    b.HasOne("Draft.Core.Entities.Game", "Game")
                        .WithMany("GameTeams")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Draft.Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Draft.Core.Entities.Injury", b =>
                {
                    b.HasOne("Draft.Core.Entities.Player")
                        .WithMany("Injuries")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Phase", b =>
                {
                    b.HasOne("Draft.Core.Entities.Season")
                        .WithMany("Phases")
                        .HasForeignKey("SeasonId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Player", b =>
                {
                    b.HasOne("Draft.Core.Entities.ArcTeam")
                        .WithMany("Players")
                        .HasForeignKey("ArcTeamId");

                    b.HasOne("Draft.Core.Entities.ArcTeam")
                        .WithMany("Starters")
                        .HasForeignKey("ArcTeamId1");

                    b.HasOne("Draft.Core.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.HasOne("Draft.Core.Entities.Team")
                        .WithMany("Starters")
                        .HasForeignKey("TeamId1");

                    b.HasOne("Draft.Core.Entities.Waiver")
                        .WithMany("Players")
                        .HasForeignKey("WaiverId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Season", b =>
                {
                    b.HasOne("Draft.Core.Entities.Draft", "Draft")
                        .WithMany()
                        .HasForeignKey("DraftId");

                    b.HasOne("Draft.Core.Entities.Standings", "Standings")
                        .WithMany()
                        .HasForeignKey("StandingsId");

                    b.HasOne("Draft.Core.Entities.Waiver", "Waiver")
                        .WithMany()
                        .HasForeignKey("WaiverId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Standings", b =>
                {
                    b.HasOne("Draft.Core.Entities.ArcTeam", "Champion")
                        .WithMany()
                        .HasForeignKey("ChampionId");

                    b.HasOne("Draft.Core.Entities.ArcTeam", "EastChamp")
                        .WithMany()
                        .HasForeignKey("EastChampId");

                    b.HasOne("Draft.Core.Entities.ArcTeam", "WestChamp")
                        .WithMany()
                        .HasForeignKey("WestChampId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Team", b =>
                {
                    b.HasOne("Draft.Core.Entities.Record", "Record")
                        .WithMany()
                        .HasForeignKey("RecordId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Draft.Inf.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Draft.Inf.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Draft.Inf.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Draft.Inf.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
