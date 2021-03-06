﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wsKooshDaroo.Data;

namespace wsKooshDaroo.Migrations
{
    [DbContext(typeof(KooshDarooContext))]
    [Migration("20200912074429_Add_Name_Into_Member")]
    partial class Add_Name_Into_Member
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wsKooshDaroo.Models.Member", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.Property<bool>("isInactive");

                    b.HasKey("id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("wsKooshDaroo.Models.Pharmacy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("Title");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.Property<bool>("is24h");

                    b.Property<bool>("isInactive");

                    b.HasKey("id");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("wsKooshDaroo.Models.PharmacyConnection", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfConnectionState");

                    b.Property<int>("PharmacyId");

                    b.Property<int>("StateOf");

                    b.HasKey("id");

                    b.ToTable("PharmacyConnection");
                });

            modelBuilder.Entity("wsKooshDaroo.Models.Prescribe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOf");

                    b.Property<string>("PhoneNo");

                    b.Property<byte[]>("Prescription");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.Property<bool>("isCancelled");

                    b.HasKey("id");

                    b.ToTable("Prescribe");
                });

            modelBuilder.Entity("wsKooshDaroo.Models.PrescribeItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountOf");

                    b.Property<string>("DrugName");

                    b.Property<int>("PrescribeId");

                    b.HasKey("id");

                    b.ToTable("PrescribeItem");
                });

            modelBuilder.Entity("wsKooshDaroo.Models.PrescribeResource", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Item01");

                    b.Property<bool>("Item02");

                    b.Property<bool>("Item03");

                    b.Property<bool>("Item04");

                    b.Property<bool>("Item05");

                    b.Property<bool>("Item06");

                    b.Property<bool>("Item07");

                    b.Property<bool>("Item08");

                    b.Property<bool>("Item09");

                    b.Property<bool>("Item10");

                    b.Property<DateTime>("MemberAcceptDateOf");

                    b.Property<bool>("MemberAccepted");

                    b.Property<bool>("MemberTakesDrugs");

                    b.Property<DateTime>("PharmacyAcceptDateOf");

                    b.Property<bool>("PharmacyAccepted");

                    b.Property<int>("PharmacyId");

                    b.Property<int>("PrescribeId");

                    b.HasKey("id");

                    b.ToTable("PrescribeResource");
                });
#pragma warning restore 612, 618
        }
    }
}
