using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models;

public class Keyword
{
    public string KeywordId { get; set; }

    public string? KeywordName { get; set; }
    public virtual ICollection<Article> Articles { get; set; }

}
