﻿// <auto-generated />
using System;
using Galaxy.Storage.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Galaxy.Storage.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241112164334_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Galaxy.Storage.Models.Feedback", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("feedBackText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("forPublic")
                        .HasColumnType("boolean");

                    b.HasKey("IsnNode");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Galaxy.Storage.Models.Order", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IsnUser")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("IsnNode");

                    b.HasIndex("IsnUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Galaxy.Storage.Models.User", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("ClientPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("ClientSurname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("IsnNode");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Galaxy.Storage.Models.Order", b =>
                {
                    b.HasOne("Galaxy.Storage.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("IsnUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Galaxy.Storage.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
