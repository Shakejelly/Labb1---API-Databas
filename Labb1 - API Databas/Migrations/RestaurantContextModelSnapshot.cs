﻿// <auto-generated />
using System;
using Labb1___API_Databas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb1___API_Databas.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb1___API_Databas.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FK_TableNumber")
                        .HasColumnType("int");

                    b.Property<int>("TableAmount")
                        .HasColumnType("int");

                    b.Property<string>("TimeToArrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("FK_CustomerId");

                    b.HasIndex("FK_TableNumber");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("BookingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            BookingName = "John Doe",
                            PhoneNumber = "(555) 123 - 4567"
                        },
                        new
                        {
                            CustomerId = 2,
                            BookingName = "Jane Smith",
                            PhoneNumber = "(555) 234-5678"
                        },
                        new
                        {
                            CustomerId = 3,
                            BookingName = "Michael Johnson",
                            PhoneNumber = "(555) 345-6789"
                        });
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Menu", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DishAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("DishInStock")
                        .HasColumnType("int");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DishPrice")
                        .HasColumnType("float");

                    b.HasKey("DishId");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            Description = "Classic Italian pasta with a creamy egg and pancetta sauce.",
                            DishAvailable = false,
                            DishName = "Spaghetti Carbonara",
                            DishPrice = 14.99
                        },
                        new
                        {
                            DishId = 2,
                            Description = "A simple pizza topped with fresh tomatoes, mozzarella, and basil.",
                            DishAvailable = false,
                            DishName = "Margherita Pizza",
                            DishPrice = 12.5
                        },
                        new
                        {
                            DishId = 3,
                            Description = "Tender chicken in a spiced tomato and cream sauce, served with rice.",
                            DishAvailable = false,
                            DishName = "Chicken Tikka Masala",
                            DishPrice = 16.989999999999998
                        },
                        new
                        {
                            DishId = 4,
                            Description = "An assortment of fresh sushi rolls with wasabi and soy sauce.",
                            DishAvailable = false,
                            DishName = "Sushi Platter",
                            DishPrice = 22.0
                        },
                        new
                        {
                            DishId = 5,
                            Description = "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan.",
                            DishAvailable = false,
                            DishName = "Caesar Salad",
                            DishPrice = 10.5
                        },
                        new
                        {
                            DishId = 6,
                            Description = "Soft tortillas filled with seasoned beef, lettuce, and cheddar cheese.",
                            DishAvailable = false,
                            DishName = "Beef Tacos",
                            DishPrice = 11.25
                        },
                        new
                        {
                            DishId = 7,
                            Description = "Stir-fried rice noodles with shrimp, peanuts, and tangy tamarind sauce.",
                            DishAvailable = false,
                            DishName = "Pad Thai",
                            DishPrice = 13.75
                        },
                        new
                        {
                            DishId = 8,
                            Description = "Rich and creamy soup made from fresh lobster and a touch of sherry.",
                            DishAvailable = false,
                            DishName = "Lobster Bisque",
                            DishPrice = 18.5
                        },
                        new
                        {
                            DishId = 9,
                            Description = "A colorful mix of vegetables sautéed in a savory soy-ginger sauce.",
                            DishAvailable = false,
                            DishName = "Veggie Stir-Fry",
                            DishPrice = 12.0
                        },
                        new
                        {
                            DishId = 10,
                            Description = "Warm, molten-centered chocolate cake served with vanilla ice cream.",
                            DishAvailable = false,
                            DishName = "Chocolate Lava Cake",
                            DishPrice = 8.9900000000000002
                        });
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Table", b =>
                {
                    b.Property<int>("TableNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableNumber"));

                    b.Property<int?>("Seatings")
                        .HasColumnType("int");

                    b.HasKey("TableNumber");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableNumber = 1,
                            Seatings = 2
                        },
                        new
                        {
                            TableNumber = 2,
                            Seatings = 2
                        },
                        new
                        {
                            TableNumber = 3,
                            Seatings = 2
                        },
                        new
                        {
                            TableNumber = 4,
                            Seatings = 4
                        },
                        new
                        {
                            TableNumber = 5,
                            Seatings = 4
                        },
                        new
                        {
                            TableNumber = 6,
                            Seatings = 4
                        },
                        new
                        {
                            TableNumber = 7,
                            Seatings = 4
                        },
                        new
                        {
                            TableNumber = 8,
                            Seatings = 6
                        },
                        new
                        {
                            TableNumber = 9,
                            Seatings = 6
                        },
                        new
                        {
                            TableNumber = 10,
                            Seatings = 6
                        },
                        new
                        {
                            TableNumber = 11,
                            Seatings = 6
                        },
                        new
                        {
                            TableNumber = 12,
                            Seatings = 10
                        },
                        new
                        {
                            TableNumber = 13,
                            Seatings = 10
                        });
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Booking", b =>
                {
                    b.HasOne("Labb1___API_Databas.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("FK_CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb1___API_Databas.Models.Table", "Table")
                        .WithMany("Bookings")
                        .HasForeignKey("FK_TableNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Labb1___API_Databas.Models.Table", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
