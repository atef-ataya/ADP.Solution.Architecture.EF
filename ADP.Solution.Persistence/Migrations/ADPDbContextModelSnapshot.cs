﻿// <auto-generated />
using System;
using ADP.Solution.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADP.Solution.Persistence.Migrations
{
    [DbContext(typeof(ADPDbContext))]
    partial class ADPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADP.Solution.Domain.Entities.AdaaTask", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AdaaTasks");

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2022, 5, 18, 12, 21, 9, 852, DateTimeKind.Local).AddTicks(2815),
                            Description = "Creating ADP Solution Architect",
                            Name = "Solution Architect"
                        },
                        new
                        {
                            TaskId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2022, 1, 18, 12, 21, 9, 853, DateTimeKind.Local).AddTicks(3177),
                            Description = "Creating ADP Solution Architect",
                            Name = "Exception Middleware"
                        },
                        new
                        {
                            TaskId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2022, 8, 18, 12, 21, 9, 853, DateTimeKind.Local).AddTicks(3246),
                            Description = "Creating ADP Solution Architect",
                            Name = "Exception Middleware"
                        },
                        new
                        {
                            TaskId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2022, 4, 18, 12, 21, 9, 853, DateTimeKind.Local).AddTicks(3286),
                            Description = "Creating ADP Solution Architect",
                            Name = "Exception Middleware"
                        },
                        new
                        {
                            TaskId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2021, 12, 18, 12, 21, 9, 853, DateTimeKind.Local).AddTicks(3443),
                            Description = "Creating ADP Solution Architect",
                            Name = "Exception Middleware"
                        },
                        new
                        {
                            TaskId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2022, 7, 18, 12, 21, 9, 853, DateTimeKind.Local).AddTicks(3494),
                            Description = "Creating ADP Solution Architect",
                            Name = "Exception Middleware"
                        });
                });

            modelBuilder.Entity("ADP.Solution.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "frontEnd"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "backEnd"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "microFrontEnd"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "microBackEnd"
                        });
                });

            modelBuilder.Entity("ADP.Solution.Domain.Entities.AdaaTask", b =>
                {
                    b.HasOne("ADP.Solution.Domain.Entities.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ADP.Solution.Domain.Entities.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
