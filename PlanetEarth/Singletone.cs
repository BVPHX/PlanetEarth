using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetEarth
{
    partial class DbEntities : DbContext
    {
        public static DbEntities _context;
        public static DbEntities GetContext()
        {
            if (_context == null) _context = new DbEntities();
            return _context;
        }
    }
}
