using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DatabaseLayer.Models;

namespace BusinessLayer.Manager
{
    public class ArticleManager : IArticleServices
{
    private readonly IArticleDal _articleDal;

    public ArticleManager(IArticleDal articleDal)
    {
        _articleDal = articleDal;
    }

    public async Task<string> CreateArticleAsync(Article article)
    {
        var addArticle = await _articleDal.AddAsync(article);

        return addArticle.ArticleId; // Assuming Id is set after addition
    }

    public async Task<bool> DeleteArticleAsync(string articleId)
    {
        var article = await _articleDal.GetByIdAsync(articleId);
        if (article != null)
        {
            await _articleDal.DeleteAsync(articleId);
            return true;
        }
        return false;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        return (await _articleDal.GetAllAsync()).ToList();
    }

    public Task<Article> GetArticleByIdAsync(string articleId)
    {
        return _articleDal.GetByIdAsync(articleId);
    }

    public async Task<Article> UpdateArticleAsync(string articleId, Article article)
    {
        var existingArticle = await _articleDal.GetByIdAsync(articleId);
        if (existingArticle == null)
    {
        return null; // Makale bulunamazsa null döndür
    }

        existingArticle.Title = article.Title;
        existingArticle.WordNumber = article.WordNumber;


        await _articleDal.UpdateAsync(existingArticle);

        return existingArticle;
    }
}

}