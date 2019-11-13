using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDao : ISurveyDao
    {
        private readonly string connectionString;
        public SurveyDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
