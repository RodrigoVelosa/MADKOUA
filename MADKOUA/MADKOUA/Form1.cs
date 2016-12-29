using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MADKOUA_BD;

namespace MADKOUA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Livro.DecrementaNLivrosDisp(3);
            dataGridView1.DataSource = Requisicao.ListaRequisicao();


        }

    }
}
