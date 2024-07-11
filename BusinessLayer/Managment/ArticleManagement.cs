using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using DatabaseLayer.Models;

namespace BusinessLayer.Managment
{
    public class ArticleManagement : IArticleServices
{
    private readonly EFArticleRepo _articleRepo;

    public ArticleManagement(EFArticleRepo articleRepo)
    {
        _articleRepo = articleRepo;
    }

    public async Task<bool> CreateArticleAsync(Article article)
    {
        await _articleRepo.AddAsync(article);
        return true; // Assuming Id is set after addition
    }

    public async Task<bool> DeleteArticleAsync(int articleId)
    {
        var article = await _articleRepo.GetByIdAsync(articleId);
        if (article != null)
        {
            await _articleRepo.DeleteAsync(articleId);
            return true;
        }
        return false;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        return (await _articleRepo.GetAllAsync()).ToList();
    }

    public Task<Article> GetArticleByIdAsync(int articleId)
    {
        return _articleRepo.GetByIdAsync(articleId);
    }

    public async Task<bool> UpdateArticleAsync(int articleId, Article article)
    {
        var existingArticle = await _articleRepo.GetByIdAsync(articleId);
        if (existingArticle == null)
            return false;

        existingArticle.Title = article.Title;
        existingArticle.ReleaseDate = article.ReleaseDate;


        await _articleRepo.UpdateAsync(existingArticle);
        return true;
    }
}

}