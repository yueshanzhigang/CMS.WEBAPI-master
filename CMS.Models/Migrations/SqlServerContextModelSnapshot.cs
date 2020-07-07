﻿// <auto-generated />
using System;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Models.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.Models.System.SysModule", b =>
                {
                    b.Property<string>("ModuleID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("ModuleState")
                        .HasColumnType("int");

                    b.Property<string>("ModuleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("ParentID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("ModuleID");

                    b.ToTable("SysModule");
                });

            modelBuilder.Entity("CMS.Models.System.SysRole", b =>
                {
                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("RoleState")
                        .HasColumnType("int");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnName("RoleTitle")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleID");

                    b.ToTable("SysRole");
                });

            modelBuilder.Entity("CMS.Models.System.SysRoleRight", b =>
                {
                    b.Property<int>("RoleRightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleRightID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("ModuleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.HasKey("RoleRightID");

                    b.ToTable("SysRoleRight");
                });

            modelBuilder.Entity("CMS.Models.System.SysUserInfo", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnName("Account")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastLoginIP")
                        .HasColumnName("LastLoginIP")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnName("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnName("RoleID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("UserState")
                        .HasColumnName("UserState")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("SysUserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
