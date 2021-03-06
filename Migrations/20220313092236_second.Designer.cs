// <auto-generated />
using System;
using CrudR.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudR.Migrations
{
    [DbContext(typeof(DatabaseConn))]
    [Migration("20220313092236_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrudR.Models.Country", b =>
                {
                    b.Property<int>("c_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("c_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_Id");

                    b.ToTable("newcountries");
                });

            modelBuilder.Entity("CrudR.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("c_Id")
                        .HasColumnType("int");

                    b.Property<int?>("s_Id")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("c_Id");

                    b.HasIndex("s_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CrudR.Models.State", b =>
                {
                    b.Property<int>("s_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("countryc_Id")
                        .HasColumnType("int");

                    b.Property<string>("s_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("s_Id");

                    b.HasIndex("countryc_Id");

                    b.ToTable("states");
                });

            modelBuilder.Entity("CrudR.Models.Customer", b =>
                {
                    b.HasOne("CrudR.Models.Country", "c")
                        .WithMany()
                        .HasForeignKey("c_Id");

                    b.HasOne("CrudR.Models.State", "s")
                        .WithMany()
                        .HasForeignKey("s_Id");

                    b.Navigation("c");

                    b.Navigation("s");
                });

            modelBuilder.Entity("CrudR.Models.State", b =>
                {
                    b.HasOne("CrudR.Models.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryc_Id");

                    b.Navigation("country");
                });
#pragma warning restore 612, 618
        }
    }
}
