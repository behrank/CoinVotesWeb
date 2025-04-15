using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Poll> Polls { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<RssFeed> RssFeeds { get; set; }

    public virtual DbSet<ServiceLog> ServiceLogs { get; set; }

    public virtual DbSet<Signal> Signals { get; set; }

    public virtual DbSet<SignalSubscription> SignalSubscriptions { get; set; }

    public virtual DbSet<Symbol> Symbols { get; set; }

    public virtual DbSet<UpDownVote> UpDownVotes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=167.86.104.25;Database=coinvoteproddb;Username=postgres;Password=5DJit6fWHdj47");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Devices_UserId");

            entity.Property(e => e.DeviceId).HasMaxLength(50);
            entity.Property(e => e.DeviceLanguage).HasMaxLength(10);
            entity.Property(e => e.DeviceModel).HasMaxLength(80);
            entity.Property(e => e.DeviceType).HasMaxLength(10);
            entity.Property(e => e.FcmToken).HasMaxLength(200);
            entity.Property(e => e.OsVersion).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'-infinity'::timestamp with time zone");

            entity.HasOne(d => d.User).WithMany(p => p.Devices).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Poll>(entity =>
        {
            entity.HasIndex(e => e.Symbol_Id, "IX_Polls_Symbol_Id");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasIndex(e => e.SymbolId, "IX_Prices_SymbolId");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.Property(e => e.Environment).HasDefaultValueSql("''::text");
            entity.Property(e => e.EventTime).HasDefaultValue(0L);
            entity.Property(e => e.ProductId).HasDefaultValueSql("''::text");
            entity.Property(e => e.Store).HasDefaultValueSql("''::text");
            entity.Property(e => e.Type).HasDefaultValueSql("''::text");
        });

        modelBuilder.Entity<RssFeed>(entity =>
        {
            entity.Property(e => e.ImageUrl).HasDefaultValueSql("''::text");
        });

        modelBuilder.Entity<Signal>(entity =>
        {
            entity.Property(e => e.TrackType).HasDefaultValue(0);
            entity.Property(e => e.TypeId).HasDefaultValue(0);
        });

        modelBuilder.Entity<Symbol>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Symbols_Name");

            entity.HasIndex(e => e.SymbolUsdt, "IX_Symbols_SymbolUsdt");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<UpDownVote>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("UpDownVotes_pkey");

            entity.HasIndex(e => e.SymbolID, "IX_UpDownVotes_SymbolID");

            entity.Property(e => e.PollId).HasDefaultValue(0);
            entity.Property(e => e.UserId).HasDefaultValue(0);

            entity.HasOne(d => d.Poll).WithMany(p => p.UpDownVotes).HasForeignKey(d => d.PollId);
            
            entity.HasOne(d => d.User).WithMany(p => p.UpDownVotes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.ID, "IX_Users_ID").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
