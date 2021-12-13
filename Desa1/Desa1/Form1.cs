using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desa1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.GravaPessoa();
            MessageBox.Show("Foram criados "+p.contadorAluno+" Alunos e "+p.contadorPessoa+" Pessoas");
            Aluno al = new Aluno();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from AlunoCurso";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Banco bd = new Banco();

            string sql = "select AlunoCurso.nome as Aluno, AlunoCurso.nome_curso as Curso from AlunoCurso where matricula != ''";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }
    }
}
