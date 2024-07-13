using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;

namespace BusinessLayer.Services
{
    public interface IReaderServices
    {
        Task<List<Reader>> GetAllReadersAsync();  // Tüm türleri getirme
        Task<Reader> GetReaderByIdAsync(string readerId);  // Belirli bir türü id'ye göre getirme
        Task<string> CreateReaderAsync(Reader reader);  // Yeni bir tür oluşturma
        Task<bool> UpdateReaderAsync(string readerId, Reader reader);  // Bir türü güncelleme
        Task<bool> DeleteReaderAsync(string readerId);  // Bir türü silme
    }
}