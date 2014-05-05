using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{
    public class CDVisitas
    {
        string Conn;
        SqlConnection cn;

        public CDVisitas()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        private const string spSPI_VISITAS = "SPI_VISITAS";
        private const string spSPS_LISTA_VISITAS = "SPS_LISTA_VISITAS";
        private const string spSPS_BUSQUEDA_VISITAS_A = "SPS_BUSQUEDA_VISITAS_A";
        private const string spSPS_BUSQUEDA_VISITAS_S = "SPS_BUSQUEDA_VISITAS_S";
        private const string spSPU_ESTADO_VISITA = "SPU_ESTADO_VISITA";
        private const string spSPS_CARGA_VISITA_X_PROYECTO = "SPS_CARGA_VISITA_X_PROYECTO";
        private const string spSPS_VISITA_X_ID_PROYECTO = "SPS_VISITA_X_ID_PROYECTO";
        private const string spSPI_VISITA = "SPI_VISITA";
        private const string spSPU_VISITA = "SPU_VISITA";
        private const string spSPI_KARDEX_HC = "SPI_KARDEX_HC";
        private const string spSPU_KARDEX_HC = "SPU_KARDEX_HC";
        private const string spSPI_ERRORES = "SPI_ERRORES";
        private const string spSPU_ERRORES = "SPU_ERRORES";
        private const string spSPS_LISTA_ERRORES = "SPS_LISTA_ERRORES";
        private const string spSPS_CABECERA = "SPS_CABECERA";
        private const string spSPI_ID_TAM = "SPI_ID_TAM";
        private const string spSPI_ID_TAM_AUTO = "SPI_ID_TAM_AUTO";
        private const string spSPI_ID_ENR = "SPI_ID_ENR";
        private const string spSPI_ID_ENR_AUTO = "SPI_ID_ENR_AUTO";
        private const string spSPI_VISITAS_AUTO = "SPI_VISITAS_AUTO";
        private const string spSPU_ESTADO_VISITA_ADMIN = "SPU_ESTADO_VISITA_ADMIN";
        private const string spSPU_FECHA_VISITA_ADMIN = "SPU_FECHA_VISITA_ADMIN";
        private const string spSPI_ID_TAM_REG = "SPI_ID_TAM_REG";
        private const string spSPI_ID_ENR_REG = "SPI_ID_ENR_REG";
        private const string spSPS_CARGA_GRUPO_VISITA_X_PROYECTO = "SPS_CARGA_GRUPO_VISITA_X_PROYECTO";

        #endregion

        #region metodos
        public DataTable CargarGrupoVisitaxProy(int CodigoProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_CARGA_GRUPO_VISITA_X_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.Fill(dt);
            return dt;
        }

        public int RegID_ENR(int CodigoLocal, int CodigoProyecto, string IdENR)
        {
            SqlCommand cmd = new SqlCommand(spSPI_ID_ENR_REG, cn);
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
                cmd.Parameters.Add(new SqlParameter("@IdENR", SqlDbType.VarChar, 30)).Value = IdENR;
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

        public int RegID_TAM(int CodigoLocal, int CodigoProyecto, string IdTAM)
        {
            SqlCommand cmd = new SqlCommand(spSPI_ID_TAM_REG, cn);
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
                cmd.Parameters.Add(new SqlParameter("@IdTAM", SqlDbType.VarChar, 30)).Value = IdTAM;
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

        public int ActualizarFechaVAdmin(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, string Fecha)
        {
            SqlCommand cmd = new SqlCommand(spSPU_FECHA_VISITA_ADMIN, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitas", SqlDbType.Int)).Value = CodigoVisitas;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@FechaVisita", SqlDbType.DateTime)).Value = Fecha;
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

        public int ActualizarEstadoVAdmin(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, int CodigoEstadoVisita)
        {
            SqlCommand cmd = new SqlCommand(spSPU_ESTADO_VISITA_ADMIN, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitas", SqlDbType.Int)).Value = CodigoVisitas;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoEstadoVisita", SqlDbType.Int)).Value = CodigoEstadoVisita;
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

        public DataTable InsertarVisitasAuto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int IdUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_VISITAS_AUTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", IdUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable RegistrarIdENRauto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int IdUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_ID_ENR_AUTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", IdUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable RegistrarIdENR(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, string IdENR, int IdUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_ID_ENR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@IdENR", IdENR);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", IdUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable RegistrarIdTAMauto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int IdUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_ID_TAM_AUTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", IdUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable RegistrarIdTAM(int CodigoLocal, int CodigoProyecto, string CodigoPaciente,string IdTAM, int IdUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_ID_TAM, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@IdTAM", IdTAM);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", IdUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarDatosxPaciente(int CodigoLocal, int CodigoProyecto, string CodigoPaciente)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_CABECERA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarErroresxPaciente(int CodigoLocal, int CodigoProyecto, string CodigoUsuarioError, string CodigoPaciente, string FechaError)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTA_ERRORES, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuarioError", CodigoUsuarioError);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@FechaError", FechaError);
            dap.Fill(dt);
            return dt;
        }

        public int EditarErrores(int CodigoError,string CodigoPaciente, int CodigoLocal, int CodigoProyecto, int CodigoDocumento, int CodigoTipoError, int CodigoUsuarioError, string FechaError, string NomDoc, int Cantidad, int A72, int CodigoUsuario)
        {
            SqlCommand cmd = new SqlCommand(spSPU_ERRORES, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoError", SqlDbType.Int)).Value = CodigoError;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoDocumento", SqlDbType.Int)).Value = CodigoDocumento;
                cmd.Parameters.Add(new SqlParameter("@CodigoTipoError", SqlDbType.Int)).Value = CodigoTipoError;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioError", SqlDbType.Int)).Value = CodigoUsuarioError;
                cmd.Parameters.Add(new SqlParameter("@FechaError", SqlDbType.VarChar, 10)).Value = FechaError;
                cmd.Parameters.Add(new SqlParameter("@NomDoc", SqlDbType.VarChar, 40)).Value = NomDoc;
                cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int)).Value = Cantidad;
                cmd.Parameters.Add(new SqlParameter("@A72", SqlDbType.Int)).Value = A72;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = CodigoUsuario;
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

        public int RegistraErrores(string CodigoPaciente, int CodigoLocal, int CodigoProyecto, int CodigoDocumento, int CodigoTipoError, int CodigoUsuarioError, string FechaError, string NomDoc, int Cantidad, int A72, int CodigoUsuario)
        {
            SqlCommand cmd = new SqlCommand(spSPI_ERRORES, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoLocal", SqlDbType.Int)).Value = CodigoLocal;
                cmd.Parameters.Add(new SqlParameter("@CodigoProyecto", SqlDbType.Int)).Value = CodigoProyecto;
                cmd.Parameters.Add(new SqlParameter("@CodigoDocumento", SqlDbType.Int)).Value = CodigoDocumento;
                cmd.Parameters.Add(new SqlParameter("@CodigoTipoError", SqlDbType.Int)).Value = CodigoTipoError;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioError", SqlDbType.Int)).Value = CodigoUsuarioError;
                cmd.Parameters.Add(new SqlParameter("@FechaError", SqlDbType.VarChar,10)).Value = FechaError;
                cmd.Parameters.Add(new SqlParameter("@NomDoc", SqlDbType.VarChar, 40)).Value = NomDoc;
                cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int)).Value = Cantidad;
                cmd.Parameters.Add(new SqlParameter("@A72", SqlDbType.Int)).Value = A72;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = CodigoUsuario;
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

        public int EditarKardex(int CodigoKardex, string CodigoPaciente, int CodigoUsuarioD)
        {
            SqlCommand cmd = new SqlCommand(spSPU_KARDEX_HC, cn);
            SqlTransaction trx;
            int intretorno;
            string strRespuesta;

            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoKardex", SqlDbType.Int)).Value = CodigoKardex;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioD", SqlDbType.Int)).Value = CodigoUsuarioD;
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

        public int RegistraKardex(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, string FechaVisita, int CodigoUsuarioE)
        {
            SqlCommand cmd = new SqlCommand(spSPI_KARDEX_HC, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitas", SqlDbType.Int)).Value = CodigoVisitas;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@FechaVisita", SqlDbType.VarChar, 10)).Value = FechaVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioE", SqlDbType.Int)).Value = CodigoUsuarioE;
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

        public int EditarVisita(int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita, string Nombre, string Descripcion, int Auto, int DiasVisitaProx, int CodigoGrupoVisitaProx, int CodigoVisitaProx, int DiasAntes, int DiasDespues, int Orden, int Estado)
        {
            SqlCommand cmd = new SqlCommand(spSPU_VISITA, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisita", SqlDbType.Int)).Value = CodigoGrupoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Auto", SqlDbType.Int)).Value = Auto;
                cmd.Parameters.Add(new SqlParameter("@DiasVisitaProx", SqlDbType.Int)).Value = DiasVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisitaProx", SqlDbType.Int)).Value = CodigoGrupoVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitaProx", SqlDbType.Int)).Value = CodigoVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@DiasAntes", SqlDbType.Int)).Value = DiasAntes;
                cmd.Parameters.Add(new SqlParameter("@DiasDespues", SqlDbType.Int)).Value = DiasDespues;
                cmd.Parameters.Add(new SqlParameter("@Orden", SqlDbType.Int)).Value = Orden;
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

        public int RegistraVisita(int CodigoProyecto, int CodigoGrupoVisita, string Nombre, string Descripcion, int Auto, int DiasVisitaProx, int CodigoGrupoVisitaProx, int CodigoVisitaProx, int DiasAntes, int DiasDespues)
        {
            SqlCommand cmd = new SqlCommand(spSPI_VISITA, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisita", SqlDbType.Int)).Value = CodigoGrupoVisita;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250)).Value = Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Auto", SqlDbType.Int)).Value = Auto;
                cmd.Parameters.Add(new SqlParameter("@DiasVisitaProx", SqlDbType.Int)).Value = DiasVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisitaProx", SqlDbType.Int)).Value = CodigoGrupoVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitaProx", SqlDbType.Int)).Value = CodigoVisitaProx;
                cmd.Parameters.Add(new SqlParameter("@DiasAntes", SqlDbType.Int)).Value = DiasAntes;
                cmd.Parameters.Add(new SqlParameter("@DiasDespues", SqlDbType.Int)).Value = DiasDespues;
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

        public DataTable ListarVisitaxIdxProy(int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_VISITA_X_ID_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoGrupoVisita", CodigoGrupoVisita);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoVisita", CodigoVisita);
            dap.Fill(dt);
            return dt;
        }

        public DataTable CargarVisitaxProy(int CodigoProyecto, int CodigoGrupoVisita)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_CARGA_VISITA_X_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoGrupoVisita", CodigoGrupoVisita);
            dap.Fill(dt);
            return dt;
        }

        public int ActualizarEstadoV(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, int CodigoEstadoVisita, int CodigoEstatusPaciente, int CodigoUsuario)
        {
            SqlCommand cmd = new SqlCommand(spSPU_ESTADO_VISITA, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisitas", SqlDbType.Int)).Value = CodigoVisitas;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoEstadoVisita", SqlDbType.Int)).Value = CodigoEstadoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoEstatusPaciente", SqlDbType.Int)).Value = CodigoEstatusPaciente;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = CodigoUsuario;
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

        public DataTable GetBusquedaVisitasA(int intLocal, int intProyecto, int intEstCita, string FechaD, string FechaH, string Nom)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_BUSQUEDA_VISITAS_A, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", intLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", intProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoEstadoVisita", intEstCita);
            dap.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaD);
            dap.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaH);
            dap.SelectCommand.Parameters.AddWithValue("@Nombre", Nom);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetBusquedaVisitasS(int intLocal, int intProyecto, int intEstCita, string FechaD)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_BUSQUEDA_VISITAS_S, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", intLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", intProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoEstadoVisita", intEstCita);
            dap.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaD);
            dap.Fill(dt);
            return dt;
        }

        public DataTable ListarVisitasxPaciente(string CodigoPaciente)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTA_VISITAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.Fill(dt);
            return dt;
        }

        public int InsertarVisitas(int CodigoLocal, int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita, string CodigoPaciente, string FechaVisita, string HoraCita, int CodigoUsuario)
        {
            SqlCommand cmd = new SqlCommand(spSPI_VISITAS, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoGrupoVisita", SqlDbType.Int)).Value = CodigoGrupoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoVisita", SqlDbType.Int)).Value = CodigoVisita;
                cmd.Parameters.Add(new SqlParameter("@CodigoPaciente", SqlDbType.VarChar, 50)).Value = CodigoPaciente;
                cmd.Parameters.Add(new SqlParameter("@FechaVisita", SqlDbType.VarChar, 10)).Value = FechaVisita;
                cmd.Parameters.Add(new SqlParameter("@HoraCita", SqlDbType.VarChar, 5)).Value = HoraCita;
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int)).Value = CodigoUsuario;
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


        #endregion
    }
}
