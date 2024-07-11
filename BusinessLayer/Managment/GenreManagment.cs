using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DatabaseLayer.Models;

namespace BusinessLayer.Managment
{
    public class GenreManagment : IGenreServices
    {
        public Task<int> CreateGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreByIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGenreAsync(int genreId, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}