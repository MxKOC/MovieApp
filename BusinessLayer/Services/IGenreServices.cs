using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.Models;

namespace BusinessLayer.Services
{
    public interface IGenreServices
    {
        Task<List<Genre>> GetAllGenresAsync();  // Tüm türleri getirme
        Task<Genre> GetGenreByIdAsync(int genreId);  // Belirli bir türü id'ye göre getirme
        Task<int> CreateGenreAsync(Genre genre);  // Yeni bir tür oluşturma
        Task<bool> UpdateGenreAsync(int genreId, Genre genre);  // Bir türü güncelleme
        Task<bool> DeleteGenreAsync(int genreId);  // Bir türü silme
    }
}