using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Desa1
{
    public class Pessoa
    {
        public int contadorPessoa = 0 , contadorAluno = 0;
            
          
        public string nome { get; set; }
        public string telefone { get; set; }
        public string cidade { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }


        //StreamWriter sw;
        StreamReader sr;

        public void lerArquivo()
        {
            string linha;
            sr = new StreamReader("C:\\Arquivo\\desafio1.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Console.WriteLine(linha);
                linha = sr.ReadLine();

            }
            sr.Close();
        }

        

        public void GravaPessoa()
        {
            Banco banco = new Banco();

           
            StreamReader sr;
            sr = new StreamReader("C:\\Arquivo\\desafio1.txt");

            try
            {
                string path = @"C:\\Arquivo\\desafio1.txt";

                string[] readText = File.ReadAllLines(path);

                for (int i = 0; i < readText.Length; i++)
                {

                    SqlConnection cn = banco.abrirConexao();
                    SqlTransaction tran = cn.BeginTransaction();
                    SqlCommand command = new SqlCommand();

                    command.Connection = cn;
                    command.Transaction = tran;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "insert into AlunoCurso " +
                       "values (@nome, @telefone, @cidade, @RG, @CPF, @matricula, @codCurso, @nomeCurso);";
                    command.Parameters.Add("@nome", SqlDbType.VarChar);
                    command.Parameters.Add("@telefone", SqlDbType.VarChar);
                    command.Parameters.Add("@cidade", SqlDbType.VarChar);
                    command.Parameters.Add("@RG", SqlDbType.VarChar);
                    command.Parameters.Add("@CPF", SqlDbType.VarChar);
                    command.Parameters.Add("@matricula", SqlDbType.VarChar);
                    command.Parameters.Add("@codCurso", SqlDbType.VarChar);
                    command.Parameters.Add("@nomeCurso", SqlDbType.VarChar);
                    string[] a = new string[] { };

                    string[] b = new string[] { };

                    var aux = readText[i].Split("-");

                    //Tratativa da primeira linha
                    if (aux[0] == "X")
                    {
                        i++;
                    }

                    var x = readText.Length;

                    //esse if é para não dar problema na ultima linha, se não vai pegar uma linha que nao existe no final e dar erro no codigo
                    if (x - 1 != i)
                    {
                        a = readText[i].Split("-");
                        b = readText[i + 1].Split("-");
                    }
                    
                    else
                    {
                        a = readText[i].Split("-");
                        b = readText[i].Split("-");
                    }



                    if (a[0] == "Z" && b[0] == "Y")
                    {
                        //auxiliar b da linha abaixo é um curso
                        //entao é um aluno com curso

                        Aluno alu = new Aluno
                        {
                            nome = a[1],
                            telefone = a[2],
                            cidade = a[3],
                            RG = a[4],
                            CPF = a[5],
                            matricula = b[1],
                            codCurso = b[2],
                            nomeCurso = b[3]
                        };

                        command.Parameters[0].Value = alu.nome;
                        command.Parameters[1].Value = alu.telefone;
                        command.Parameters[2].Value = alu.cidade;
                        command.Parameters[3].Value = alu.RG;
                        command.Parameters[4].Value = alu.CPF;
                        command.Parameters[5].Value = alu.matricula;
                        command.Parameters[6].Value = alu.codCurso;
                        command.Parameters[7].Value = alu.nomeCurso;
                        command.ExecuteNonQuery();
                        tran.Commit();
                      
                        contadorAluno++;
                        i++;

                    }

                    else
                    {
                        Pessoa p = new Pessoa
                        {
                            nome = a[1],
                            telefone = a[2],
                            cidade = a[3],
                            RG = a[4],
                            CPF = a[5],

                        };

                        command.Parameters[0].Value = p.nome;
                        command.Parameters[1].Value = p.telefone;
                        command.Parameters[2].Value = p.cidade;
                        command.Parameters[3].Value = p.RG;
                        command.Parameters[4].Value = p.CPF;
                        command.Parameters[5].Value = "";
                        command.Parameters[6].Value = "";
                        command.Parameters[7].Value = "";
                        command.ExecuteNonQuery();
                        tran.Commit();
                  
                        contadorPessoa++;
                    }
                }
            }

            catch (Exception e)
            {
                //tran.Rollback();
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
                banco.fecharConexao();
            }
            sr.Close();
        }

    }

}

