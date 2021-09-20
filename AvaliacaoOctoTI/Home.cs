using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvaliacaoOctoTI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarClienteToolStripMenuItem_Click(object sender, EventArgs e) {
            CadastroCliente cc = new CadastroCliente();
            cc.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
