using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderProject.BusinessLogic
{
    public interface IDataFormatting
    {
        public void PrintSeperatorLine();

        public void PrintRow(params string[] columns);
    }
}
