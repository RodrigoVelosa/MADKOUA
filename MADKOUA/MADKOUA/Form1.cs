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

            AdicionaBD add = new MADKOUA.AdicionaBD();
            Livro liv = new MADKOUA.Livro(1);
            Requisitante req = new MADKOUA.Requisitante(1);

            add.AdicionaRequisicao(liv, req, DateTime.Now, DateTime.Now.AddDays(10), "O Canha é tonto!");
        }

    }
}
