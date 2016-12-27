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
        public static void EliminaBD(int id);
        public static DataTable ListaDB();
    }
}
