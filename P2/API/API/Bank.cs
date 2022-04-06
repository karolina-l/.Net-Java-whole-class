using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace API
{
    public class Bank : DbContext
    {
        public virtual DbSet<Currency> Currencies { get; set; }
    }
}
