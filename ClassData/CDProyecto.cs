using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{
    public class CDProyecto
    {
        string Conn;
        SqlConnection cn;

        public CDProyecto()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        private const string spSPS_RED_ACTIVAS = "SPS_RED_ACTIVAS";
        private const string spSPS_PROYECTOS = "SPS_PROYECTOS";
        private const string spSPS_PROYECTOS_X_RED = "SPS_PROYECTOS_X_RED";
        private const string spSPI_PROYECTO = "SPI_PROYECTO";
        private const string spSPU_PROYECTO = "SPU_PROYECTO";
        private const string spSPS_PROYECTO_ID = "SPS_PROYECTO_ID";
        private const string spSPS_GRUPO_VISITA_X_PROYECTO = "SPS_GRUPO_VISITA_X_PROYECTO";
        private const string spSPS_GRUPO_VISITA_ID = "SPS_GRUPO_VISITA_ID";
        private const string spSPI_GRUPO_VISITA = "SPI_GRUPO_VISITA";
        private const string spSPU_GRUPO_VISITA = "SPU_GRUPO_VISITA";
        private const string spSPS_LOCAL_X_PROYECTO = "SPS_LOCAL_X_PROYECTO";
        private const string spSPI_LOCAL_PROYECTO = "SPI_LOCAL_PROYECTO";
        private const string spSPS_VISITA_X_PROYECTO = "SPS_VISITA_X_PROYECTO";
        private const string spSPS_COD_TAM_TODOS = "SPS_COD_TAM_TODOS";
        private const string spSPU_LIMPIAR_COD_TAM = "SPU_LIMPIAR_COD_TAM";
        private const string spSPU_COD_TAM_EDIT = "SPU_COD_TAM_EDIT";
        private const string spSPS_COD_ENR_TODOS = "SPS_COD_ENR_TODOS";
        private const string spSPU_LIMPIAR_COD_ENR = "SPU_LIMPIAR_COD_ENR";
        private const string spSPU_COD_ENR_EDIT = "SPU_COD_ENR_EDIT";

        #endregion

        #region metodos
        public int EditCodENR(int CodigoLocal, int CodigoProyecto, int CodigoENR, string Numero)
        {
            SqlCommand cmd = new SqlCommand(spSPU_COD_ENR_EDIT, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoENR", SqlDbType.Int)).Value = CodigoENR;
                cmd.Parameters.Add(new SqlParameter("@Numero", SqlDbType.VarChar, 30)).Value = Numero;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public int LimiarCodENR(int CodigoLocal, int CodigoProyecto, int CodigoENR)
        {
            SqlCommand cmd = new SqlCommand(spSPU_LIMPIAR_COD_ENR, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoENR", SqlDbType.Int)).Value = CodigoENR;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public DataTable ListarCodEnrolamiento(int CodigoLocal, int idProyecto, string numero)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_COD_ENR_TODOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", idProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@Numero", numero);
            dap.Fill(dt);
            return dt;
        }

        public int EditCodTAM(int CodigoLocal, int CodigoProyecto, int CodigoTAM,string Numero)
        {
            SqlCommand cmd = new SqlCommand(spSPU_COD_TAM_EDIT, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoTAM", SqlDbType.Int)).Value = CodigoTAM;
                cmd.Parameters.Add(new SqlParameter("@Numero", SqlDbType.VarChar,30)).Value = Numero;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public int LimiarCodTAM(int CodigoLocal, int CodigoProyecto, int CodigoTAM)
        {
            SqlCommand cmd = new SqlCommand(spSPU_LIMPIAR_COD_TAM, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoTAM", SqlDbType.Int)).Value = CodigoTAM;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public DataTable ListarCodTamizaje(int CodigoLocal, int idProyecto, string numero)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_COD_TAM_TODOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", idProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@Numero", numero);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarVisitasxProyecto(int idProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_VISITA_X_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", idProyecto);
            dap.Fill(dt);
            return dt;
        }

        public int InsertarLocalesxProyecto(int CodigoLocal, int CodigoProyecto, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_LOCAL_PROYECTO, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int)).Value = Estado;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public DataTable ListarLocalesxProyecto(int idProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCAL_X_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", idProyecto);
            dap.Fill(dt);
            return dt;
        }

        public int ModificarGrupo(int CodigoGrupoVisita,int CodigoProyecto, string Nombre, int orden, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPU_GRUPO_VISITA, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisita", SqlDbType.Int)).Value = CodigoGrupoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Orden", SqlDbType.Int)).Value = orden;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int)).Value = Estado;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public int InsertarGrupo(int CodigoProyecto, string Nombre, int orden, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_GRUPO_VISITA, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Orden", SqlDbType.Int)).Value = orden;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int)).Value = Estado;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public DataTable ListarGrupoxId(int CodigoGrupoVisita)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_GRUPO_VISITA_ID, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoGrupoVisita", CodigoGrupoVisita);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarGrupoxProyecto(int idProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_GRUPO_VISITA_X_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", idProyecto);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarProyectosxID(int CodigoProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PROYECTO_ID, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.Fill(dt);
            return dt;
        }

        public int ModificarProyecto(int CodigoProyecto, int CodigoRedes, string Nombre, string Descripcion, string FechaInicio, string FechaFin, int TAM, int ENR, int tipoTAM, int tipoENR, int Estatus, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPU_PROYECTO, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoRedes", SqlDbType.Int)).Value = CodigoRedes;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 200)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.DateTime)).Value = FechaInicio;
                cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = FechaFin;
                cmd.Parameters.Add(new SqlParameter("@TAM", SqlDbType.Int)).Value = TAM;
                cmd.Parameters.Add(new SqlParameter("@ENR", SqlDbType.Int)).Value = ENR;
                cmd.Parameters.Add(new SqlParameter("@TipoTAM", SqlDbType.Int)).Value = tipoTAM;
                cmd.Parameters.Add(new SqlParameter("@TipoENR", SqlDbType.Int)).Value = tipoENR;
                cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int)).Value = Estatus;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int)).Value = Estado;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public int InsertarProyecto(int CodigoRedes, string Nombre, string Descripcion, string FechaInicio, string FechaFin, int TAM, int ENR, int tipoTAM, int tipoENR, int Estatus, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_PROYECTO, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoRedes", SqlDbType.Int)).Value = CodigoRedes;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 200)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.DateTime)).Value = FechaInicio;
                cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = FechaFin;
                cmd.Parameters.Add(new SqlParameter("@TAM", SqlDbType.Int)).Value = TAM;
                cmd.Parameters.Add(new SqlParameter("@ENR", SqlDbType.Int)).Value = ENR;
                cmd.Parameters.Add(new SqlParameter("@TipoTAM", SqlDbType.Int)).Value = tipoTAM;
                cmd.Parameters.Add(new SqlParameter("@TipoENR", SqlDbType.Int)).Value = tipoENR;
                cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int)).Value = Estatus;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int)).Value = Estado;
                cmd.Transaction = trx;
                intretorno = cmd.ExecuteNonQuery();
                trx.Commit();
                cn.Close();
                return intretorno;
            }
            catch (SqlException sqlException)
            {
                strRespuesta = sqlException.Message.ToString();
                cn.Close();
                return -1;
            }
            catch (Exception exception)
            {
                strRespuesta = exception.Message.ToString();
                cn.Close();
                return -1;
            }
        }

        public DataTable ListarProyectosxRed(int idRed)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PROYECTOS_X_RED, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoRed", idRed);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarProyectos()
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PROYECTOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarRedes()
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_RED_ACTIVAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        }

        #endregion
    }
}
