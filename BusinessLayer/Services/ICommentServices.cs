using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;

namespace BusinessLayer.Services
{
    public interface ICommentServices
    {
        public Task<Comment> GetCommentByIdAsync(string commentId);
        Task<IEnumerable<Comment>> GetAllCommentByReaderIdAsync(string ReaderId);  // Belirli bir türü id'ye göre getirme
        Task<string> CreateCommentAsync(Comment comment);  // Yeni bir tür oluşturma
        Task<Comment> UpdateCommentAsync(string commentId, Comment comment);  // Bir türü güncelleme
        Task<bool> DeleteCommentAsync(string commentId);  // Bir türü silme
    }
}