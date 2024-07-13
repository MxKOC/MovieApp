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
    public class EFGenreRepo : GenericRepo<Genre>, IGenreDal
    {
        public EFGenreRepo(ArticlesContext context) : base(context)
        {



            
        }

    }
}
