using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicalLayer
{
   public class CodsegurancaBLL
    {
        CodsegurancaDAL dal = new CodsegurancaDAL();

        public bool EnviaEMAIL(string email)
        {
            return dal.EnviaEmail(email);
        }
        public bool VerificaCodigo(string codigo,string email)
        {
            if (Convert.ToString(dal.GetCODByEmail(email)) == codigo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void DeletaByEmail(string email)
        {
            dal.DeleteByEmail(email);
        }

    }
}
