using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;

namespace MADKOUA_LOG
{
    class BDRecorder : Recorder
    {

        private static ComunicaBD BD = new ComunicaBD();

        public void Regista(string mensagem)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Logs(RegistoLog, Data) VALUES ('" + mensagem + "', CURRENT_TIMESTAMP)");
        }
    }
}
