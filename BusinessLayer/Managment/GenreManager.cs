using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DatabaseLayer.Models;

namespace BusinessLayer.Manager
{
    public class GenreManager : IGenreServices
    {
        public Task<string> CreateGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGenreAsync(string genreId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreByIdAsync(string genreId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGenreAsync(string genreId, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}