﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Yoshi.VIN.Membership.Data.EF;

namespace Yoshi.VIN.Membership.Data.EF.Migrations
{
    [DbContext(typeof(MemberContext))]
    [Migration("20170819201447_IDToLong")]
    partial class IDToLong
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Yoshi.VIN.Membership.Models.Member", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DOB")
                        .HasColumnName("DOB")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(75);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(10);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasMaxLength(12);

                    b.HasKey("ID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Member","dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
