using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;


namespace Desa1
{
    public partial class Form2 : Form
    {
  
        public Form2()
        {
            InitializeComponent();
        }

         

        private void button2_Click(object sender, EventArgs e)
        {
            
            Banco bd = new Banco();
            DataTable dt = new DataTable();
            Remedio rem = new Remedio();

            dt = rem.selectSemID();

            dataGridView1.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Remedio rem = new Remedio();
            DataTable dt = new DataTable();
            dt = rem.selectSemID();

            try
            {
                foreach (DataRow linha in dt.Rows)
                {
                    rem.nomeRemedio = linha[0].ToString();
                    rem.horaRemedio = linha[1].ToString();
                    DateTime date = DateTime.Parse(rem.horaRemedio);
                    rem.horaRemedio = date.ToString("HH:mm");
                   

                    if (rem.horaRemedio == DateTime.Now.ToString("HH:mm"))
                    {                     
                       MessageBox.Show("Está na hora do remedio: " + rem.nomeRemedio +" referente ao horario: "+rem.horaRemedio);
                    }                 
                }             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ex);
            }
            
        }
  
    }
}
