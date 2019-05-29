using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.DataAccess.EntityFramework
{
    public class BaseRepository
    {
        protected static DatabaseContext context;
        protected static object _lock = new object();

        public BaseRepository()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (context ==null)
            {
                lock (_lock)
                {
                    if (context==null)
                    {
                        context = new DatabaseContext();

                    }
                }

            }
        }
    }
}
