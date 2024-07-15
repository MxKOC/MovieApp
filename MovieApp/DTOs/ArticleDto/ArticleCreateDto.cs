using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.DTOs.ArticleDto
{
    public class ArticleCreateDto
    {
        
    public bool IsPublic { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Revenue { get; set; }
    public int WordNumber { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
    public string WriterId { get; set; }

        
    }
}