using ApiSeriesAWSCrud.Data;
using ApiSeriesAWSCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSeriesAWSCrud.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeries()
        {
            return await this.context.Series.ToListAsync();
        }
    }
}
