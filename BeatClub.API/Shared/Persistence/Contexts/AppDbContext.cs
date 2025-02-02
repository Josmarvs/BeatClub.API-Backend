﻿using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Nickname).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Usertype).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.UrlToImage).IsRequired().HasMaxLength(200);
            builder.Entity<User>().Property(p => p.Location).IsRequired().HasMaxLength(150);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);
            //builder.Entity<User>().Property(p => p.MembershipId).IsRequired();
            //builder.Entity<User>().Property(p => p.CreateAt).IsRequired();
            
            //Payments
            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Payment>().Property(p => p.Amount).IsRequired();
            builder.Entity<Payment>().Property(p => p.PayMethod).IsRequired().HasMaxLength(50);
            builder.Entity<Payment>().Property(p => p.UserId).IsRequired();
            builder.Entity<Payment>().Property(p => p.CreateAt).IsRequired();

            //Messages
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Content).IsRequired().HasMaxLength(120);
            builder.Entity<Message>().Property(p => p.UserIdTo).IsRequired();
            builder.Entity<Message>().Property(p => p.UserIdFrom).IsRequired();
            builder.Entity<Message>().Property(p => p.MessageDate).IsRequired();
            
            //Track
            builder.Entity<Track>().ToTable("Tracks");
            builder.Entity<Track>().HasKey(p => p.Id);
            builder.Entity<Track>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Track>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.Privacy).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.Artist).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.Genre).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.Cover).IsRequired().HasMaxLength(200);
            builder.Entity<Track>().Property(p => p.Source).IsRequired().HasMaxLength(200);
            builder.Entity<Track>().Property(p => p.PublishDate).IsRequired();

            //Publication
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Publication>().Property(p => p.CreateAt).IsRequired();
           
            //Membership
            builder.Entity<Membership>().ToTable("Memberships");
            builder.Entity<Membership>().HasKey(p => p.Id);
            builder.Entity<Membership>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Membership>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Membership>().Property(p => p.Price).IsRequired();
            builder.Entity<Membership>().Property(p => p.Feature).IsRequired().HasMaxLength(120);
            builder.Entity<Membership>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Membership>().Property(p => p.UrlToImage).IsRequired().HasMaxLength(200);
            
            //Reviews
            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Review>().Property(p => p.Qualification).IsRequired();
            builder.Entity<Review>().Property(p => p.UserArtistId).IsRequired();
            builder.Entity<Review>().Property(p => p.UserProducerId).IsRequired();
            builder.Entity<Review>().Property(p => p.CreateAt).IsRequired();
            
            // Apply Snake Case Naming Conventions
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}