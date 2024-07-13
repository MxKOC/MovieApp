using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework

{
    public class EFArticleRepo : GenericRepo<Article>, IArticleDal
    {
        public EFArticleRepo(ArticlesContext context) : base(context)
        {
        }



        public async Task UpdateAuthorAndFeeAsync(string articleId, string newAuthor)
        {
            var article = await GetByIdAsync(articleId);
            if (article != null)
            {
                article.Title = newAuthor;
                await UpdateAsync(article);
            }
        }


    }
}
