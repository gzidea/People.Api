﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using People.Api.Data;

namespace People.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("People.Api.Models.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PeopleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("PeopleId");

                    b.HasIndex("PeopleTypeId");

                    b.HasIndex("StateId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("People.Api.Models.PeopleType", b =>
                {
                    b.Property<int>("PeopleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PeopleTypeId");

                    b.ToTable("PeopleTypes");
                });

            modelBuilder.Entity("People.Api.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("People.Api.Models.People", b =>
                {
                    b.HasOne("People.Api.Models.PeopleType", "peopleType")
                        .WithMany("Peoples")
                        .HasForeignKey("PeopleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("People.Api.Models.State", "state")
                        .WithMany("Peoples")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("peopleType");

                    b.Navigation("state");
                });

            modelBuilder.Entity("People.Api.Models.PeopleType", b =>
                {
                    b.Navigation("Peoples");
                });

            modelBuilder.Entity("People.Api.Models.State", b =>
                {
                    b.Navigation("Peoples");
                });
#pragma warning restore 612, 618
        }
    }
}