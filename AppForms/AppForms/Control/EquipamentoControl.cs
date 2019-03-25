using AppForms.Dao;
using AppForms.Model;
using System.Collections.Generic;
using System.Data;

namespace AppForms.Control
{
    class EquipamentoControl
    {
        #region Todos os Tipos de Equipamentos
        public List<TipoEquipamento> GetTipoEquipamentos()
        {
            EquipamentoDao dao = new EquipamentoDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Tipos de Equipamentos");

            return dao.GetTipoEquipamentos();
        }
        #endregion

        #region Todos os Equipamentos
        public DataTable GetEquipamentos()
        {
            EquipamentoDao dao = new EquipamentoDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Equipamentos");

            return dao.GetEquipamentos();
        }
        #endregion

        #region Alarmes Ativos
        public List<Alarmes> GetAlarmesAtivos()
        {
            AlarmeDao dao = new AlarmeDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Alarmes Ativos");

            return dao.GetAlarmesAtivos();
        }
        #endregion

        #region Inserir
        public bool InserirEquipamento(Equipamentos equip)
        {
            EquipamentoDao dao = new EquipamentoDao();

            bool result = dao.InserirEquipamento(equip);

            if (result)
            {
                Log log = new Log();
                log.RegistrarLog("Inserido Novo Equipamento com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Inserir Novo Equipamento");
            }

            return result;
        }
        #endregion

        #region Editar
        public bool EditarEquipamento(Equipamentos equip)
        {
            EquipamentoDao dao = new EquipamentoDao();

            bool result = dao.EditarEquipamento(equip);

            if (result)
            {
                Log log = new Log();
                log.RegistrarLog("Editado Equipamento com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Editar Equipamento");
            }

            return result;
        }
        #endregion

        #region Excluír
        public bool ExcluirEquipamento(Equipamentos equip)
        {
            EquipamentoDao dao = new EquipamentoDao();

            bool result = dao.ExcluirEquipamento(equip);

            if (result)
            {
                Log log = new Log();
                log.RegistrarLog("Excluído Equipamento com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Excluír Equipamento");
            }

            return result;
        }
        #endregion

    }
}
