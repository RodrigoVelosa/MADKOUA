using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA_LOG
{
    class FicheiroRecorder : Recorder
    {
        public void Regista(string mensagem)
        {
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MADKOUA_LOG.txt", true))
            {
                writer.WriteLine(mensagem);
            }
        }
    }
}
