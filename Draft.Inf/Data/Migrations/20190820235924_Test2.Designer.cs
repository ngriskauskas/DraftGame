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
    [Migration("20190820235924_Test2")]
    partial class Test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("PositionId");

                    b.Property<int>("RookieRating");

                    b.Property<int?>("TeamId");

                    b.Property<int>("VeteranRating");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Draft.Core.Entities.PlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("PlayerPosition");
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

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Draft.Core.Entities.Injury", b =>
                {
                    b.HasOne("Draft.Core.Entities.Player")
                        .WithMany("Injuries")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Draft.Core.Entities.Player", b =>
                {
                    b.HasOne("Draft.Core.Entities.PlayerPosition", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("Draft.Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
