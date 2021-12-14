using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desa1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void exportaAntigo_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Cliente cl = new Cliente();
            Produto pr = new Produto();
            cl.selectCliente();
            pr.selectProduto();

        }

        private void importaNovo_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Produto p = new Produto();
            Cliente c = new Cliente();
            if(p.GravaProduto()==false || c.GravaCliente()==false)
            {
                MessageBox.Show("Primeiro crie o arquivo TXT com o botao 'Exportar BD Antigo'");
            }
            p.GravaProduto();
            c.GravaCliente();
            
        }

        private void consultaAntigo_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            Produto p = new Produto();
            Cliente c = new Cliente();
            string sql = "select * from produtos";
            string sql2 = "select * from clientes";

            dt = bd.executarConsultaGenerica(sql);
            dt2 = bd.executarConsultaGenerica(sql2);
          

            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;

        }

        private void consultaNovo_Click(object sender, EventArgs e)
        {
          
            Banco bd = new Banco();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            Produto p = new Produto();
            Cliente c = new Cliente();
            string sql = "select * from produtosNovo";
            string sql2 = "select * from clientesNovo";

            dt = bd.executarConsultaGenerica(sql);
            dt2 = bd.executarConsultaGenerica(sql2);

            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;


        }
    }
}
