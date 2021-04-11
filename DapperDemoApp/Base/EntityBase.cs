using DapperDemoApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Base
{
    public class EntityBase<T> : IEntityBase<T> where T : class
    {
        protected ApplicationDBContext _context;
        public EntityBase(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
