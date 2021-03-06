﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Migrations
{
    [DbContext(typeof(GummiBearKingdomContext))]
    partial class GummiBearKingdomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GummiBearKingdom.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost");

                    b.Property<string>("Country");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int>("TasteId");

                    b.HasKey("ProductId");

                    b.HasIndex("TasteId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GummiBearKingdom.Models.Taste", b =>
                {
                    b.Property<int>("TasteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TasteId");

                    b.ToTable("Tastes");
                });

            modelBuilder.Entity("GummiBearKingdom.Models.Product", b =>
                {
                    b.HasOne("GummiBearKingdom.Models.Taste", "Taste")
                        .WithMany("Products")
                        .HasForeignKey("TasteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
