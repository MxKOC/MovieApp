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
        Task<Article> GetArticleByIdAsync(string ArticleId);  // Belirli bir türü id'ye göre getirme
        Task<string> CreateArticleAsync(Article Article);  // Yeni bir tür oluşturma
        Task<bool> UpdateArticleAsync(string ArticleId, Article Article);  // Bir türü güncelleme
        Task<bool> DeleteArticleAsync(string ArticleId);  // Bir türü silmeF
    }
}