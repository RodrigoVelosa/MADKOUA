using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA_LOG
{
    class Logger
    {
        private Recorder record;
        public Logger(Recorder aRecord)
        {
            record = aRecord;
        }

        public void Log(String mensagem)
        {
            record.Regista(mensagem);
        }
    }
}
