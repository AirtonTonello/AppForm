using System;
using System.Data;

namespace AppForms.Model
{
    class Alarmes
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int TipoAlarme { get; set; }
        public int Status { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataInativacao { get; set; }
        public DataTable ListaAlarmes{ get; set; }
    }
}
