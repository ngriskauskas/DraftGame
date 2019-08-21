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
    [Migration("20190821191207_Init2")]
    partial class Init2
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

                    b.HasKey("Id");

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

                    b.Property<int>("HomeScore");

                    b.Property<bool>("IsCompleted");

                    b.HasKey("Id");

                    b.ToTable("Games");
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

            modelBuilder.Entity("Draft.Core.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Experience");

                    b.Property<bool>("IsRetired");

                    b.Property<int>("Position");

                    b.Property<int>("RookieRating");

                    b.Property<int?>("TeamId");

                    b.Property<int>("VeteranRating");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

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

                    b.Property<int?>("DraftId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCompleted");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

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

                    b.Property<int?>("StandingsId");

                    b.Property<int?>("StandingsId1");

                    b.HasKey("Id");

                    b.HasIndex("StandingsId");

                    b.HasIndex("StandingsId1");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Draft.Core.Entities.Injury", b =>
                {
                    b.HasOne("Draft.Core.Entities.Player")
                        .WithMany("Injuries")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Player", b =>
                {
                    b.HasOne("Draft.Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Season", b =>
                {
                    b.HasOne("Draft.Core.Entities.Draft", "Draft")
                        .WithMany()
                        .HasForeignKey("DraftId");
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
                    b.HasOne("Draft.Core.Entities.Standings")
                        .WithMany("EastStandings")
                        .HasForeignKey("StandingsId");

                    b.HasOne("Draft.Core.Entities.Standings")
                        .WithMany("WestStandings")
                        .HasForeignKey("StandingsId1");
                });
#pragma warning restore 612, 618
        }
    }
}
