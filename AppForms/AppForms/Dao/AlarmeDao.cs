using AppForms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppForms.Dao
{
    class AlarmeDao
    {
        #region Todos os Tipos de Alarmes
        public List<TipoAlarme> GetTipoAlarmes()
        {
            List<TipoAlarme> Lista = new List<TipoAlarme>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = "SELECT * FROM ALARME_CLASSIFICACAO";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoAlarme tipo = new TipoAlarme()
                                {
                                    ID = reader.GetInt32(0),
                                    Tipo = reader.GetString(1)
                                };
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

        #region Todos os Alarmes
        public DataTable GetAlarmes()
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
	                                        B.TIPO,
	                                        CASE
		                                        WHEN STATUS = 1 THEN 'ON'
		                                        WHEN STATUS = 0 THEN 'OFF'
	                                        ELSE '' END AS STATUS,
	                                        Convert(date, A.DT_CADASTRO, 103) as DT_CADASTRO,
	                                        Convert(date, A.DT_SAIDA, 103) as DT_SAIDA
                                        FROM ALARMES A
                                        INNER JOIN ALARME_CLASSIFICACAO B ON B.ID = A.TP_ALARME";

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

        #region Todos os Alarmes Ativos
        public List<Alarmes> GetAlarmesAtivos()
        {
            List<Alarmes> Lista = new List<Alarmes>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @"SELECT 
	                                        A.ID,
	                                        A.DESCRICAO 
                                        FROM ALARMES A
                                        WHERE A.STATUS = 1";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alarmes a = new Alarmes()
                                {
                                    ID = reader.GetInt32(0),
                                    Descricao = reader.GetString(1)
                                };
                                Lista.Add(a);
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

        #region Todos os Alarmes Por Equipamento
        public DataTable GetAlarmesPorEquipamento()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @"SELECT 
	                                        A.ID,
	                                        A.DESCRICAO AS ALARME,
	                                        C.TIPO AS TIPO_ALARME,
	                                        B.DESCRICAO AS EQUIPAMENTO,
	                                        D.TIPO AS TIPO_EQUIPAMENTO,
	                                        CASE
		                                        WHEN A.STATUS = 1 THEN 'ON'
		                                        WHEN A.STATUS = 0 THEN 'OFF'
	                                        ELSE '' END AS STATUS,
	                                        CONVERT(DATE, A.DT_CADASTRO, 103) AS DATA_CADASTRO,
	                                        CONVERT(DATE, A.DT_SAIDA, 103) AS DATA_INATIVACAO
                                        FROM ALARMES A
                                        LEFT JOIN EQUIPAMENTOS B ON B.ALARME_ID = A.ID
                                        INNER JOIN ALARME_CLASSIFICACAO C ON C.ID = A.TP_ALARME
                                        LEFT JOIN TIPO_EQUIPAMENTO D ON D.ID = B.TP_EQUIPAMENTO";

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

        #region Alarmes Mais Utilizados
        public DataTable GetAlarmesMaisUtilizados()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @"SELECT 
	                                        A.ALARME_ID,
	                                        B.DESCRICAO,
	                                        COUNT(A.ALARME_ID) AS QUANTIDADE
                                        FROM EQUIPAMENTOS A
                                        INNER JOIN ALARMES B ON B.ID = A.ALARME_ID
                                        WHERE B.STATUS = 1
                                        GROUP BY A.ALARME_ID, A.ALARME_ID, B.DESCRICAO
                                        ORDER BY QUANTIDADE DESC";

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
        public bool InserirAlarme(Alarmes alarmes)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" INSERT INTO ALARMES (DESCRICAO, TP_ALARME, STATUS, DT_CADASTRO)
	                                        VALUES (@DESCRICAO, @TP_ALARME, @STATUS, GETDATE()) ";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {

                        SqlParameter pDescricao = new SqlParameter
                        {
                            DbType = DbType.String,
                            ParameterName = "@DESCRICAO",
                            Value = alarmes.Descricao.ToUpper()
                        };
                        cmd.Parameters.Add(pDescricao);

                        SqlParameter pTipoAlarme = new SqlParameter
                        {
                            ParameterName = "@TP_ALARME",
                            DbType = DbType.Int32,
                            Value = alarmes.TipoAlarme
                        };
                        cmd.Parameters.Add(pTipoAlarme);

                        SqlParameter pStatus = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@STATUS",
                            Value = alarmes.Status
                        };
                        cmd.Parameters.Add(pStatus);

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
        public bool EditarAlarme(Alarmes alarmes)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" UPDATE ALARMES 
	                                        SET DESCRICAO = @DESCRICAO,
		                                        TP_ALARME = @TP_ALARME,
		                                        STATUS = @STATUS,
		                                        DT_SAIDA = @DT_SAIDA
                                        WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {

                        SqlParameter pDescricao = new SqlParameter
                        {
                            DbType = DbType.String,
                            ParameterName = "@DESCRICAO",
                            Value = alarmes.Descricao.ToUpper()
                        };
                        cmd.Parameters.Add(pDescricao);

                        SqlParameter pTipoAlarme = new SqlParameter
                        {
                            ParameterName = "@TP_ALARME",
                            DbType = DbType.Int32,
                            Value = alarmes.TipoAlarme

                        };
                        cmd.Parameters.Add(pTipoAlarme);

                        SqlParameter pStatus = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@STATUS",
                            Value = alarmes.Status
                        };
                        cmd.Parameters.Add(pStatus);

                        SqlParameter pDataInativacao = new SqlParameter
                        {
                            ParameterName = "@DT_SAIDA"
                        };

                        if(alarmes.Status == 0)
                        {
                            pDataInativacao.DbType = DbType.Date;
                            pDataInativacao.Value = DateTime.Today.ToShortDateString();
                        }
                        else
                        {
                            pDataInativacao.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(pDataInativacao);

                        SqlParameter pID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ID",
                            Value = alarmes.ID
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
        public bool ExcluirAlarme(Alarmes alarmes)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
                {
                    con.Open();

                    string cmdString = @" DELETE FROM ALARMES WHERE ID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        SqlParameter pID = new SqlParameter
                        {
                            DbType = DbType.Int32,
                            ParameterName = "@ID",
                            Value = alarmes.ID
                        };
                        cmd.Parameters.Add(pID);

                        cmd.ExecuteNonQuery();

                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK__EQUIPAMEN"))
                {
                    MessageBox.Show("Não é possível excluír Alarme que já tenha Equipamentos vinculados!");
                }
                else
                {
                    throw ex;
                }
            }

            return result;
        }
        #endregion
    }
}
