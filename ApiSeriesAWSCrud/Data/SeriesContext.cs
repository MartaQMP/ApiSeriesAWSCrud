using ApiSeriesAWSCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSeriesAWSCrud.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options){}

        public DbSet<Serie> Series { get; set; }
    }
}
