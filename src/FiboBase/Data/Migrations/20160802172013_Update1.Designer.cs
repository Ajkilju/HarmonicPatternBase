using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HarmonicPatternsBase.Data;

namespace FiboBase.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160802172013_Update1")]
    partial class Update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HarmonicPatternsBase.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<byte[]>("Avatar");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.HarmonicPattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("ABtoXAratio");

                    b.Property<double?>("ADtoXAratio");

                    b.Property<DateTime>("AddDate");

                    b.Property<double?>("BCtoABratio");

                    b.Property<double?>("CDtoABratio");

                    b.Property<double?>("CDtoBCratio");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discription");

                    b.Property<byte[]>("Image");

                    b.Property<int?>("InstrumentId");

                    b.Property<int?>("IntervalId");

                    b.Property<int?>("NumberOfWaves");

                    b.Property<int?>("PatternDirectId");

                    b.Property<int?>("PatternTypeId");

                    b.Property<int?>("ReactionAfter10CandlesId");

                    b.Property<int?>("ReactionAfter20CandlesId");

                    b.Property<int?>("ReactionAfter5CandlesId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentId");

                    b.HasIndex("IntervalId");

                    b.HasIndex("PatternDirectId");

                    b.HasIndex("PatternTypeId");

                    b.HasIndex("ReactionAfter10CandlesId");

                    b.HasIndex("ReactionAfter20CandlesId");

                    b.HasIndex("ReactionAfter5CandlesId");

                    b.HasIndex("UserId");

                    b.ToTable("HarmonicPatterns");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.Interval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Intervals");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.Pattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ABtoXAratio");

                    b.Property<double>("ADtoXAratio");

                    b.Property<double>("BCtoABratio");

                    b.Property<double>("CDtoABratio");

                    b.Property<double>("CDtoBCratio");

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageString");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfWaves");

                    b.HasKey("Id");

                    b.ToTable("Patterns");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.PatternDirect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PatternDirects");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.ReactionLvl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ReactionLvls");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HarmonicPatternsBase.Models.HarmonicPattern", b =>
                {
                    b.HasOne("HarmonicPatternsBase.Models.Instrument", "Instrument")
                        .WithMany("HarmonicPatterns")
                        .HasForeignKey("InstrumentId");

                    b.HasOne("HarmonicPatternsBase.Models.Interval", "Interval")
                        .WithMany("HarmonicPatterns")
                        .HasForeignKey("IntervalId");

                    b.HasOne("HarmonicPatternsBase.Models.PatternDirect", "PatternDirect")
                        .WithMany("HarmonicPatterns")
                        .HasForeignKey("PatternDirectId");

                    b.HasOne("HarmonicPatternsBase.Models.Pattern", "PatternType")
                        .WithMany("HarmonicPatterns")
                        .HasForeignKey("PatternTypeId");

                    b.HasOne("HarmonicPatternsBase.Models.ReactionLvl", "ReactionAfter10Candles")
                        .WithMany("PatternReaction10Candles")
                        .HasForeignKey("ReactionAfter10CandlesId");

                    b.HasOne("HarmonicPatternsBase.Models.ReactionLvl", "ReactionAfter20Candles")
                        .WithMany("PatternReaction20Candles")
                        .HasForeignKey("ReactionAfter20CandlesId");

                    b.HasOne("HarmonicPatternsBase.Models.ReactionLvl", "ReactionAfter5Candles")
                        .WithMany("PatternReaction5Candles")
                        .HasForeignKey("ReactionAfter5CandlesId");

                    b.HasOne("HarmonicPatternsBase.Models.ApplicationUser", "User")
                        .WithMany("HarmonicPatterns")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HarmonicPatternsBase.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HarmonicPatternsBase.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HarmonicPatternsBase.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
