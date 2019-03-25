using System.Data;

namespace AppForms.Model
{
    class Equipamentos
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int NumeroSerie { get; set; }
        public int TipoEquipamento { get; set; }
        public int AlarmeID { get; set; }
        public DataTable ListaEquipamentos { get; set; }
    }
}
