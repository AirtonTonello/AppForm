using AppForms.Dao;
using AppForms.Model;
using System.Collections.Generic;
using System.Data;

namespace AppForms.Control
{
    class AlarmeControl
    {
        #region Todos os Tipos de Alarmes
        public List<TipoAlarme> GetTipoAlarmes()
        {
            AlarmeDao dao = new AlarmeDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Tipos de Alarmes");

            return dao.GetTipoAlarmes();
        }
        #endregion

        #region Todos os Alarmes
        public DataTable GetAlarmes()
        {
            AlarmeDao dao = new AlarmeDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Alarmes");

            return dao.GetAlarmes();
        }
        #endregion

        #region Todos os Alarmes Por Equipamento
        public DataTable GetAlarmesPorEquipamento()
        {
            AlarmeDao dao = new AlarmeDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Alarmes Por Equipamento");

            return dao.GetAlarmesPorEquipamento();
        }
        #endregion

        #region Alarmes Mais Utilizados
        public DataTable GetAlarmesMaisUtilizados()
        {
            AlarmeDao dao = new AlarmeDao();

            Log log = new Log();
            log.RegistrarLog("Consulta Alarmes Mais Utilizados");

            return dao.GetAlarmesMaisUtilizados();
        }
        #endregion

        #region Inserir
        public bool InserirAlarme(Alarmes alarmes)
        {
            AlarmeDao dao = new AlarmeDao();

            bool result = dao.InserirAlarme(alarmes);

            if (result)
            {
                Log log = new Log();

                if (alarmes.TipoAlarme == 1)
                {
                    new Email().EnviarEmail(alarmes);
                    log.RegistrarLog("Alarme Urgente, enviado email");
                }
                
                log.RegistrarLog("Inserido Novo Alarme com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Inserir Novo Alarme");
            }

            return result;
        }
        #endregion

        #region Editar
        public bool EditarAlarme(Alarmes alarmes)
        {
            AlarmeDao dao = new AlarmeDao();

            bool result = dao.EditarAlarme(alarmes);

            if (result)
            {
                Log log = new Log();

                if (alarmes.TipoAlarme == 1)
                {
                    new Email().EnviarEmail(alarmes);
                    log.RegistrarLog("Alterado Alarme para Urgente, enviado email");
                }

                log.RegistrarLog("Editado Alarme com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Editar Alarme");
            }

            return result;
        }
        #endregion
        
        #region Excluír
        public bool ExcluirAlarme(Alarmes alarmes)
        {
            AlarmeDao dao = new AlarmeDao();

            bool result = dao.ExcluirAlarme(alarmes);

            if (result)
            {
                Log log = new Log();
                log.RegistrarLog("Excluído Alarme com Sucesso");
            }
            else
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao Excluír Alarme");
            }

            return result;
        }
        #endregion

    }
}
