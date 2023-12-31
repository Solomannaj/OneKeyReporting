﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataExtractionTool.DataLayer.Models;
using DataExtractionTool.Helpers;

namespace DataExtractionTool.DataLayer
{
    public class DataExtractionToolContext : DbContext
    {
        public DataExtractionToolContext(){
            this.Database.SetCommandTimeout(300);
        }
		public DbSet<DataExtractionUsers> DataExtractionUsers { get; set; }
		public DbSet<MatsocResult> FiltersResult { get; set; }
        public DbSet<HCPTypeResult> HCPTypeResult { get; set; }
        public DbSet<ReportResult> TestCase { get; set; }
		
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(AppSettings.DBConnectionStringAU);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<DataExtractionUsers>(entity =>
            {
                entity.HasKey(x => x.UserId);
            });

            modelBuilder.Entity<MatsocResult>(entity =>
            {
				entity.HasNoKey();
            });

            modelBuilder.Entity<HCPTypeResult>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ReportResult>(entity =>
            {
                entity.HasNoKey();
            });
        }
	}
}
