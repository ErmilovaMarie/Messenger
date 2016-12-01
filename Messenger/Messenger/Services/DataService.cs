using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    class DataService
    {
        private static readonly DataService _dataservice = new DataService();

        protected DataService()
        {

        }

        public static DataService GetInstance ()
        {
            return _dataservice;
        }
    }
}
