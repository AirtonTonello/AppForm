using AppForms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppForms.Dao
{
    class EquipamentoDao
    {
        #region Todos os Tipos de Equipamentos
        public List<TipoEquipamento> GetTipoEquipamentos()
        {
            List<TipoEquipamento> Lista = new List<TipoEquipamento>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = "SELECT * FROM TIPO_EQUIPAMENTO";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoEquipamento tipo = new TipoEquipamento();
                                tipo.ID = reader.GetInt32(0);
                                tipo.Tipo = reader.GetString(1);
                                Lista.Add(tipo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Lista;
        }
        #endregion

        #region Todos os Equipamentos
        public DataTable GetEquipamentos()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @"SELECT 
                                            A.ID,
	                                        A.DESCRICAO,
	                                        A.NM_SERIE,
	                                        B.TIPO,
	                                        C.DESCRICAO AS ALARME,
                                            CASE
		                                        WHEN C.STATUS = 1 THEN 'ON'
		                                        WHEN C.STATUS = 0 THEN 'OFF'
	                                        ELSE '' END AS STATUS,
	                                        Convert(date, A.DT_CADASTRO, 103) as DT_CADASTRO
                                        FROM EQUIPAMENTOS A
                                        INNER JOIN TIPO_EQUIPAMENTO B ON B.ID = A.TP_EQUIPAMENTO
                                        INNER JOIN ALARMES C ON C.ID = A.ALARME_ID";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        #endregion

        #region Inserir
        public bool InserirEquipamento(Equipamentos equip)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" INSERT INTO EQUIPAMENTOS (DESCRICAO, NM_SERIE, TP_EQUIPAMENTO, DT_CADASTRO, ALARME_ID)
                                            VALUES(@NOME, @NUM_SERIE, @TIPO, GETDATE(), @ALARMES_ID) ";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {

                        SqlParameter pNome = new SqlParameter
                        {
                            DbType = DbType.String,
                            ParameterName = "@NOME",
                            Value = equip.Descricao.ToUpper()
                        };
                        cmd.Parameters.Add(pNome);

                        SqlParameter pNumeroSerie = new SqlParameter
                        {
                            ParameterName = "@NUM_SERIE",
                            DbType = DbType.Int32,
                            Value = equip.NumeroSerie
                        };
                        cmd.Parameters.Add(pNumeroSerie);

                        SqlParameter pTipo = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@TIPO",
                            Value = equip.TipoEquipamento
                        };
                        cmd.Parameters.Add(pTipo);

                        SqlParameter pAlarmeID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ALARMES_ID",
                            Value = equip.AlarmeID
                        };
                        cmd.Parameters.Add(pAlarmeID);

                        cmd.ExecuteNonQuery();

                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region Editar
        public bool EditarEquipamento(Equipamentos equip)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" UPDATE EQUIPAMENTOS 
                                            SET DESCRICAO = @NOME, 
                                            NM_SERIE = @NUM_SERIE, 
                                            TP_EQUIPAMENTO = @TIPO,
                                            ALARME_ID = @ALARME_ID
                                            WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {

                        SqlParameter pNome = new SqlParameter
                        {
                            DbType = DbType.String,
                            ParameterName = "@NOME",
                            Value = equip.Descricao.ToUpper()
                        };
                        cmd.Parameters.Add(pNome);

                        SqlParameter pNumeroSerie = new SqlParameter
                        {
                            ParameterName = "@NUM_SERIE",
                            DbType = DbType.Int32,
                            Value = equip.NumeroSerie

                        };
                        cmd.Parameters.Add(pNumeroSerie);

                        SqlParameter pTipo = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@TIPO",
                            Value = equip.TipoEquipamento
                        };
                        cmd.Parameters.Add(pTipo);

                        SqlParameter pAlarmeID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ALARME_ID",
                            Value = equip.AlarmeID
                        };
                        cmd.Parameters.Add(pAlarmeID);

                        SqlParameter pID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ID",
                            Value = equip.ID
                        };
                        cmd.Parameters.Add(pID);

                        cmd.ExecuteNonQuery();

                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region Excluír
        public bool ExcluirEquipamento(Equipamentos equip)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" DELETE FROM EQUIPAMENTOS WHERE ID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        SqlParameter pID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ID",
                            Value = equip.ID
                        };
                        cmd.Parameters.Add(pID);

                        cmd.ExecuteNonQuery();

                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
        #endregion
    }
}
