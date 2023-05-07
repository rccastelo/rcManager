using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerDomainBase.Base;
using rcManagerRepositoryBase.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerRepositoryBase.Base
{
    public abstract class DatasBase : DataEF
    {
        public DatasBase(ManagerDbContext context) : base(context) { }
    }
}
