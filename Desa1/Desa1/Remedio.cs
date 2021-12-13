using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Timers;

namespace Desa1
{
    class Remedio
    {

        public string nomeRemedio { get; set; }
        public string horaRemedio { get; set; }


        string[] name = new string[] { };

        string[] hour = new string[] { };


        public DataTable selectSemID()
        {
            //array recebendo todo o banco
            //for percorrendo todo array e comparando, se achar algum igual guarda no array b
            //retornar array b
            Banco bd = new Banco();
            string sql = "select nomeRemedio,horario from Remedio";
            DataTable dt = new DataTable();
            dt = bd.executarConsultaGenerica(sql);
        
            return dt;
           
        }

        public string mostraHora()
        {
            string datetime = DateTime.Now.ToString("hh:mm");
            return datetime;
        }

    }
}
