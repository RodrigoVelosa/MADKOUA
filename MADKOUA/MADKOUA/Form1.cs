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


            dataGridView1.DataSource = Autor.ListaAutores();

            MessageBox.Show(Requisitante.Verifica("2020112", "qwerty").ToString());
            MessageBox.Show(Requisitante.Verifica("2020112", "qwety").ToString());
        }

    }
}
