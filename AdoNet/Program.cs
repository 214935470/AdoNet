using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source=srv2\\pupils;initial catalog=AdoNetManage;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";

            string res = "yes";

            while(res == "yes")
            {
                
                DataAccess da = new DataAccess();
                
                da.readProductData(connectionString);
                res = da.res;
            }

        }
    }
}
