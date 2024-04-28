﻿// <auto-generated />
using LABB_3_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LABB_3_API.Migrations
{
    [DbContext(typeof(Labb3ApiDbContext))]
    [Migration("20240426101932_correct database name")]
    partial class correctdatabasename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LABB_3_API_Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HobbyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Links")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            HobbyId = 1,
                            Description = "Pleasant trips out in nature on horseback",
                            HobbyName = "Horseback riding",
                            Links = "[\"https://www.visitvarberg.se/ovrigt/outdoor/outdoorsidor/rida.html\"]"
                        },
                        new
                        {
                            HobbyId = 2,
                            Description = "Hitting ball over net with racket",
                            HobbyName = "Tennis",
                            Links = "[\"https://www.tennis.se/\"]"
                        },
                        new
                        {
                            HobbyId = 3,
                            Description = "Miniature strategy war game",
                            HobbyName = "Warhammer",
                            Links = "[\"https://www.warhammer.com/\"]"
                        });
                });

            modelBuilder.Entity("LABB_3_API_Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            PersonName = "Georgette",
                            Phone = "+468712049"
                        },
                        new
                        {
                            PersonId = 2,
                            PersonName = "Gunnhild",
                            Phone = "00000001"
                        },
                        new
                        {
                            PersonId = 3,
                            PersonName = "Greger",
                            Phone = "0704561237"
                        });
                });

            modelBuilder.Entity("LABB_3_API_Models.PersonHobbyConnection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConnectionId"));

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonHobbyConnections");

                    b.HasData(
                        new
                        {
                            ConnectionId = 1,
                            HobbyId = 1,
                            PersonId = 1
                        },
                        new
                        {
                            ConnectionId = 2,
                            HobbyId = 1,
                            PersonId = 2
                        },
                        new
                        {
                            ConnectionId = 3,
                            HobbyId = 2,
                            PersonId = 2
                        },
                        new
                        {
                            ConnectionId = 4,
                            HobbyId = 2,
                            PersonId = 3
                        },
                        new
                        {
                            ConnectionId = 5,
                            HobbyId = 3,
                            PersonId = 3
                        },
                        new
                        {
                            ConnectionId = 6,
                            HobbyId = 3,
                            PersonId = 1
                        });
                });

            modelBuilder.Entity("LABB_3_API_Models.PersonHobbyConnection", b =>
                {
                    b.HasOne("LABB_3_API_Models.Hobby", "Hobby")
                        .WithMany()
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LABB_3_API_Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
