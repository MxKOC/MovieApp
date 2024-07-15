using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;

namespace BusinessLayer.Services
{
    public interface IWriterServices
    {
        Task<List<Writer>> GetAllWritersAsync();  // Tüm türleri getirme
        Task<Writer> GetWriterByIdAsync(string writerId);  // Belirli bir türü id'ye göre getirme
        Task<string> CreateWriterAsync(Writer writer);  // Yeni bir tür oluşturma
        Task<Writer> UpdateWriterAsync(string writerId, Writer writer);  // Bir türü güncelleme
        Task<bool> DeleteWriterAsync(string writerId);  // Bir türü silme
    }
}