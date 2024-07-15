using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;

namespace DatabaseLayer.Models
{
public class FavoriteArticle
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string FavoriteArticleId { get; set; }
    public string ReaderId { get; set; }
    public Reader Reader { get; set; }

    public string ArticleId { get; set; }
    public Article Article { get; set; }
}
}