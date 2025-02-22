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
        Task<Genre> GetGenreByIdAsync(string genreId);  // Belirli bir türü id'ye göre getirme
        Task<string> CreateGenreAsync(Genre genre);  // Yeni bir tür oluşturma
        Task<bool> UpdateGenreAsync(string genreId, Genre genre);  // Bir türü güncelleme
        Task<bool> DeleteGenreAsync(string genreId);  // Bir türü silme
    }
}