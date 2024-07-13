using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models;

public class Language
{
    public string LanguageId { get; set; }


    public string? LanguageCode { get; set; }

    public string? LanguageName { get; set; }
    public virtual ICollection<Article> Articles { get; set; }

}
