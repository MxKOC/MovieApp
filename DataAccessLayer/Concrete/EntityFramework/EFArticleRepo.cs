using DataAccessLayer.Context;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public class EFArticleRepo : GenericRepo<Article>, IArticleDal
    {
        public EFArticleRepo(ArticlesContext context) : base(context)
        {
        }



        public async Task UpdateAuthorAndFeeAsync(int articleId, string newAuthor, int additionalFee)
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
