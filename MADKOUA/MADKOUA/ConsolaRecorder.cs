using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA_LOG
{
    class ConsolaRecorder : Recorder
    {
        public void Regista(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
