using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;

namespace DatabaseLayer.Models
{
public class FavoriteArticle
{
    public int FavoriteArticleId { get; set; }
    public string ReaderId { get; set; }
    public Reader Reader { get; set; }

    public int ArticleId { get; set; }
    public Article Article { get; set; }
}
}