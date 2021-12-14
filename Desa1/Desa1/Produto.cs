using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Desa1
{
    public class Produto
    {
        public string codProduto { get; set; }
        public string nomeProduto { get; set; }
        public string precoProduto { get; set; }
        public string estoqueProduto { get; set; }


        public void selectProduto()
        {
            using (FileStream fs = new FileStream(@"C:\Arquivo\Banco\produtos.txt"
                                     , FileMode.OpenOrCreate
                                     , FileAccess.ReadWrite))
            {
                StreamWriter tw = new StreamWriter(fs);

                Banco bd = new Banco();
                string sql = "select * from produtos";
                DataTable dt = new DataTable();
                dt = bd.executarConsultaGenerica(sql);
                tw.WriteLine("Codigo do Produto-Nome-Preço-Estoque");

                foreach (DataRow linha in dt.Rows)
                {
                    if (linha[1] == "")
                        linha[1] = "Produto sem nome";
                    if (linha[3].ToString() != "")
                    {
                        tw.WriteLine(linha[0].ToString() + "-" + linha[1].ToString() + "-" + linha[2] + "-" + linha[3]);
                        tw.Flush();
                    }
                }
            }
        }

        public bool GravaProduto()
        {
            Banco banco = new Banco();         

            string path = @"C:\\Arquivo\\Banco\\produtos.txt";
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

                    command.CommandText = "insert into produtosNovo " +
                       "values (@cod, @nome, @preco, @estoque);";
                    command.Parameters.Add("@cod", SqlDbType.VarChar);
                    command.Parameters.Add("@nome", SqlDbType.VarChar);
                    command.Parameters.Add("@preco", SqlDbType.VarChar);
                    command.Parameters.Add("@estoque", SqlDbType.VarChar);

                    string[] a;

                    a = readText[i].Split("-");

                    Produto p = new Produto
                    {
                        codProduto = a[0],
                        nomeProduto = a[1],
                        precoProduto = a[2],
                        estoqueProduto = a[3],
                    };

                    command.Parameters[0].Value = p.codProduto;
                    command.Parameters[1].Value = p.nomeProduto;
                    command.Parameters[2].Value = p.precoProduto;
                    command.Parameters[3].Value = p.estoqueProduto;

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



