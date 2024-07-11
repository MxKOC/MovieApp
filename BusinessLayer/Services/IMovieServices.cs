using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.Models;

namespace BusinessLayer.Services
{
    public interface IArticleServices
    {
        Task<List<Article>> GetAllArticlesAsync();  // Tüm türleri getirme
        Task<Article> GetArticleByIdAsync(int ArticleId);  // Belirli bir türü id'ye göre getirme
        Task<bool> CreateArticleAsync(Article Article);  // Yeni bir tür oluşturma
        Task<bool> UpdateArticleAsync(int ArticleId, Article Article);  // Bir türü güncelleme
        Task<bool> DeleteArticleAsync(int ArticleId);  // Bir türü silmeF
    }
}