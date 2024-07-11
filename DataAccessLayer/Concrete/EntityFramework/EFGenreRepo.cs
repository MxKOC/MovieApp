using DataAccessLayer.Context;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public class EFGenreRepo : GenericRepo<Genre>, IGenreDal
    {
        public EFGenreRepo(ArticlesContext context) : base(context)
        {



            
        }

    }
}
