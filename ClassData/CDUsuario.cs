using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{
    public class CDUsuario
    {
        string Conn;
        SqlConnection cn;

        public CDUsuario()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        private const string spSPU_CAMBIAR_CLAVE = "SPU_CAMBIAR_CLAVE";
        private const string spSPS_VALIDAR_USUARIO = "SPS_VALIDAR_USUARIO";
        private const string spSPS_LISTAR_MENU_OPCIONES_USUARIO = "SPS_LISTAR_MENU_OPCIONES_USUARIO";
        private const string spSPS_USUARIO_LOCAL = "SPS_USUARIO_LOCAL";
        private const string spSPU_RESET_PASSWORD = "SPU_RESET_PASSWORD";
        private const string spSPI_USUARIOS = "SPI_USUARIOS";
        private const string spSPU_USUARIOS = "SPU_USUARIOS";
        private const string spSPS_USUARIOS = "SPS_USUARIOS";
        private const string spSPS_ROLES_USUARIO = "SPS_ROLES_USUARIO";
        private const string spSPI_ROLES_USUARIO = "SPI_ROLES_USUARIO";
        private const string spSPS_USUARIOS_X_LOCAL_ROL = "SPS_USUARIOS_X_LOCAL_ROL";
        private const string spSPS_USUARIOS_PROYECTO = "SPS_USUARIOS_PROYECTO";
        private const string spSPI_USUARIOS_PROYECTO = "SPI_USUARIOS_PROYECTO";


        #endregion

        #region metodos

        public int InsertarProyectosxUser(int IdUser, int CodigoProyecto, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_USUARIOS_PROYECTO, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = IdUser;
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

        public DataTable GetListarProyectosxUser(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIOS_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarUsuariosxLocalRol(int IdLocal)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIOS_X_LOCAL_ROL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", IdLocal);
            dap.Fill(dt);
            return dt;
        }

        public int InsertarRolesxUser(int IdUser, int CodigoRol, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_ROLES_USUARIO, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = IdUser;
                cmd.Parameters.Add(new SqlParameter("@CodigoRol", SqlDbType.Int)).Value = CodigoRol;
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

        public DataTable GetListarRolesxUser(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_ROLES_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public int EditarUsuario(int CodigoUsuario,int IdLocal, string LoginUsuario, string NombreUsuario, string Iniciales, string correo, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPU_USUARIOS, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = CodigoUsuario;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = IdLocal;
                cmd.Parameters.Add(new SqlParameter("@LoginUsuario", SqlDbType.VarChar, 50)).Value = LoginUsuario;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar, 500)).Value = NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@Iniciales", SqlDbType.VarChar, 5)).Value = Iniciales;
                cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 150)).Value = correo;
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

        public DataTable GetUsuario(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public int InsertarUsuario(int IdLocal, string LoginUsuario, string NombreUsuario, string Iniciales, string correo, int Estatus, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPI_USUARIOS, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = IdLocal;
                cmd.Parameters.Add(new SqlParameter("@LoginUsuario", SqlDbType.VarChar,50)).Value = LoginUsuario;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar,500)).Value = NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@Iniciales", SqlDbType.VarChar,5)).Value = Iniciales;
                cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar,150)).Value = correo;
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

        public int ResetearPassword(int IdUser)
        {
            SqlCommand cmd = new SqlCommand(spSPU_RESET_PASSWORD, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = IdUser;
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

        public DataTable ListarUsuariosxLocal(int IdLocal)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIO_LOCAL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", IdLocal);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetMenuData(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_MENU_OPCIONES_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetValidarUsuario(string strUsu, string strCont, int intIdLocal)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_VALIDAR_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@LoginUsuario", strUsu);
            dap.SelectCommand.Parameters.AddWithValue("@ContrasenaUsuario", strCont);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", intIdLocal);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetCambiarClave(int strUsu, string ClaveA, string ClaveN)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPU_CAMBIAR_CLAVE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", strUsu);
            dap.SelectCommand.Parameters.AddWithValue("@ContrasenaAnterior", ClaveA);
            dap.SelectCommand.Parameters.AddWithValue("@NuevaContrasena", ClaveN);
            dap.Fill(dt);
            return dt;
        }

        #endregion
    }
}
