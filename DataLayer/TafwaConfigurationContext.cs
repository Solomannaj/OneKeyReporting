using Microsoft.EntityFrameworkCore;
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
		public DbSet<User> User { get; set; }
		public DbSet<TestSuit> TestSuit { get; set; }

		public DbSet<TestCase> TestCase { get; set; }

		public DbSet<TestCaseStep> TestCaseStep { get; set; }

		public DbSet<ActionKey> ActionKey { get; set; }

		public DbSet<LocatorType> LocatorType { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(AppSettings.DBConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
