using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    interface ItemBD
    {
        public void AdicionaBD();
        public void EliminaBD(int id);
        public DataTable ListaDB();
    }
}
