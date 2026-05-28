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

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == id);
        }

        private async Task<int> GetMaxIdMax()
        {
            return await this.context.Series.MaxAsync(x => x.IdSerie);
        }

        public async Task InsertSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie
            {
                IdSerie = await this.GetMaxIdMax() + 1,
                Nombre = nombre,
                Imagen = imagen,
                Anyo = anyo
            };
            await this.context.Series.AddAsync(serie);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateSerieAsync(int id, string nombre, string imagen, int anyo)
        {
            Serie serie = await this.FindSerieAsync(id);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            Serie serie = await this.FindSerieAsync(id);
            this.context.Series.Remove(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
