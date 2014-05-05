using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{

    public class CDLocal
    {
        string Conn;
        SqlConnection cn;

        public CDLocal()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        private const string spSPS_LOCAL_ACTIVAS = "SPS_LOCAL_ACTIVAS";
        private const string spSPS_EMPRESA_ACTIVAS = "SPS_EMPRESA_ACTIVAS";
        private const string spSPS_LOCALES = "SPS_LOCALES";
        private const string spSPS_LOCALES_ID = "SPS_LOCALES_ID";
        private const string spSPI_LOCALES = "SPI_LOCALES";
        private const string spSPU_LOCALES = "SPU_LOCALES";
        private const string spSPS_PROYECTOS_X_LOCAL = "SPS_PROYECTOS_X_LOCAL";
        private const string spSPS_LOCAL_X_USUARIO = "SPS_LOCAL_X_USUARIO";
        private const string spSPS_PROYECTOS_X_LOCAL_X_USUARIO = "SPS_PROYECTOS_X_LOCAL_X_USUARIO";


        #endregion

        #region metodos

        public DataTable ListarProyectoxLocalxUser(int CodigoLocal, int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PROYECTOS_X_LOCAL_X_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarLocalesxUser(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCAL_X_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarProyectoxLocal(int CodigoLocal)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PROYECTOS_X_LOCAL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.Fill(dt);
            return dt;
        }

        public int ModificarLocales(int CodigoLocal, int CodigoEmpresa, string Nombre, string Descripcion, string Direccion, string Distrito, string Telefono, int Estatus, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPU_LOCALES, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoEmpresa", SqlDbType.Int)).Value = CodigoEmpresa;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 200)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 500)).Value = Direccion;
                cmd.Parameters.Add(new SqlParameter("@Distrito", SqlDbType.VarChar, 200)).Value = Distrito;
                cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20)).Value = Telefono;
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

        public int InsertarLocales(int IdEmpresa, string Nombre, string Descripcion, string Direccion, string Distrito, string Telefono, int Estatus, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_LOCALES, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoEmpresa", SqlDbType.Int)).Value = IdEmpresa;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 200)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 500)).Value = Direccion;
                cmd.Parameters.Add(new SqlParameter("@Distrito", SqlDbType.VarChar, 200)).Value = Distrito;
                cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20)).Value = Telefono;
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

        public DataTable ListarLocalesxID(int CodigoLocal)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCALES_ID, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarLocalesAll()
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCALES, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarEmpresasAct()
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_EMPRESA_ACTIVAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarLocales()
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCAL_ACTIVAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        }

        #endregion
    }
}
