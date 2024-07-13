using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework

{
    public class EFWriterRepo : GenericRepo<Writer>, IWriterDal
    {
        public EFWriterRepo(ArticlesContext context) : base(context)
        {



            
        }

    }
}
