using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Desa1
{
    public class Cliente
    {
        public string cpfPessoa { get; set; }
        public string nomePessoa { get; set; }
        public string telefonePessoa { get; set; }
        public string emailPessoa { get; set; }

        public void selectCliente()
        {
            using (FileStream fs = new FileStream(@"C:\Arquivo\Banco\clientes.txt"
                                     , FileMode.OpenOrCreate
                                     , FileAccess.ReadWrite))
            {
                StreamWriter tw = new StreamWriter(fs);

                Banco bd = new Banco();
                string sql = "select * from clientes";
                DataTable dt = new DataTable();
                dt = bd.executarConsultaGenerica(sql);
                tw.WriteLine("CPF-Nome-Telefone-email");
                foreach (DataRow linha in dt.Rows)
                {
                    if (linha[1].ToString() != "")
                    {
                        tw.WriteLine(linha[0] + "-" + linha[1].ToString() + "-" + linha[2].ToString() + "-" + linha[3].ToString());
                        tw.Flush();
                    }
                }
            }

        }

        public bool GravaCliente()
        {
            Banco banco = new Banco();

            string path = @"C:\\Arquivo\\Banco\\clientes.txt";
            try
            {
                string[] readText = File.ReadAllLines(path);
                for (int i = 1; i < readText.Length; i++)
                {

                    SqlConnection cn = banco.abrirConexao();
                    SqlTransaction tran = cn.BeginTransaction();
                    SqlCommand command = new SqlCommand();

                    command.Connection = cn;
                    command.Transaction = tran;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "insert into clientesNovo " +
                       "values (@cpf, @nome, @telefone, @email);";
                    command.Parameters.Add("@cpf", SqlDbType.VarChar);
                    command.Parameters.Add("@nome", SqlDbType.VarChar);
                    command.Parameters.Add("@telefone", SqlDbType.VarChar);
                    command.Parameters.Add("@email", SqlDbType.VarChar);

                    string[] a;

                    a = readText[i].Split("-");

                    Cliente c = new Cliente
                    {
                        cpfPessoa = a[0],
                        nomePessoa = a[1],
                        telefonePessoa = a[2],
                        emailPessoa = a[3],
                    };

                    command.Parameters[0].Value = c.cpfPessoa;
                    command.Parameters[1].Value = c.nomePessoa;
                    command.Parameters[2].Value = c.telefonePessoa;
                    command.Parameters[3].Value = c.emailPessoa;

                    command.ExecuteNonQuery();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            banco.fecharConexao();
            return true;

        }
    }
}
