using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{
    public class CDPaciente
    {
        string Conn;
        SqlConnection cn;

        public CDPaciente()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        private const string spSPS_PARAMETROS = "SPS_PARAMETROS";
        private const string spSPI_PACIENTE = "SPI_PACIENTE";
        private const string spSPS_PACIENTE_ID = "SPS_PACIENTE_ID";
        private const string spSPS_UBIGEO_X_PAIS = "SPS_UBIGEO_X_PAIS";
        private const string spSPS_UBIGEO_X_DEPARTAMENTO = "SPS_UBIGEO_X_DEPARTAMENTO";
        private const string spSPS_UBIGEO_X_PROVINCIA = "SPS_UBIGEO_X_PROVINCIA";
        private const string spSPS_PACIENTE_CONTACTO_ID = "SPS_PACIENTE_CONTACTO_ID";
        private const string spSPI_PACIENTE_CONTACTO = "SPI_PACIENTE_CONTACTO";
        private const string spSPS_PACIENTE_BS = "SPS_PACIENTE_BS";
        private const string spSPS_PACIENTE_BA = "SPS_PACIENTE_BA";
        private const string spSPS_DATOS_SEDE_PROY = "SPS_DATOS_SEDE_PROY";
        private const string spSPU_PACIENTE = "SPU_PACIENTE";
        private const string spSPS_ESTADO_VISITA_PACIENTE = "SPS_ESTADO_VISITA_PACIENTE";


        #endregion

        #region metodos

        public DataTable EstatusPacientexId(int Codigo)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_ESTADO_VISITA_PACIENTE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codigoestadovisita", Codigo);
            dap.Fill(dt);
            return dt;
        }

        public DataTable EditarPacientes(string IdPaciente,string Nombres, string ApellidoP, string ApellidoM, int CodigoTipoDocumento, string DocumentoIdentidad, string FechaNacimiento, int Sexo)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPU_PACIENTE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", IdPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@Nombres", Nombres);
            dap.SelectCommand.Parameters.AddWithValue("@ApellidoP", ApellidoP);
            dap.SelectCommand.Parameters.AddWithValue("@ApellidoM", ApellidoM);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoTipoDocumento", CodigoTipoDocumento);
            dap.SelectCommand.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
            dap.SelectCommand.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            dap.SelectCommand.Parameters.AddWithValue("@Sexo", Sexo);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetMostrarDatosLocalProy(string CodigoPaciente, int CodigoLocal, int CodigoProyecto)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_DATOS_SEDE_PROY, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", CodigoLocal);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoProyecto", CodigoProyecto);
            dap.Fill(dt);
            return dt;
        }

        public DataTable BuscarPacxDatos(string ApeP, string ApeM, string Nom,string FN)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PACIENTE_BA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@ApeP", ApeP);
            dap.SelectCommand.Parameters.AddWithValue("@ApeM", ApeM);
            dap.SelectCommand.Parameters.AddWithValue("@Nom", Nom);
            dap.SelectCommand.Parameters.AddWithValue("@FN", FN);
            dap.Fill(dt);
            return dt;
        }

        public DataTable BuscarPacxDocumento(string Documento)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PACIENTE_BS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Documento", Documento);
            dap.Fill(dt);
            return dt;
        }

        public int InsertarContacto(string CodigoPaciente, string CodigoUbigeo, string Direccion, string Referencia, string Telefono1, string Telefono2, string Celular)
        {
            SqlCommand cmd = new SqlCommand(spSPI_PACIENTE_CONTACTO, cn);
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
                cmd.Parameters.Add(new SqlParameter("@CodigoUbigeo", SqlDbType.VarChar, 9)).Value = CodigoUbigeo;
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 1000)).Value = Direccion;
                cmd.Parameters.Add(new SqlParameter("@Referencia", SqlDbType.VarChar, 200)).Value = Referencia;
                cmd.Parameters.Add(new SqlParameter("@Telefono1", SqlDbType.VarChar, 20)).Value = Telefono1;
                cmd.Parameters.Add(new SqlParameter("@Telefono2", SqlDbType.VarChar,20)).Value = Telefono2;
                cmd.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 15)).Value = Celular;
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

        public DataTable DatosPacienteContactoxId(string CodigoPaciente)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PACIENTE_CONTACTO_ID, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetUbigeoProv(int Codigoprovincia)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_UBIGEO_X_PROVINCIA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Codigoprovincia", Codigoprovincia);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetUbigeoDep(int CodigoDepartamento)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_UBIGEO_X_DEPARTAMENTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoDepartamento", CodigoDepartamento);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetUbigeoPais(int CodigoPais)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_UBIGEO_X_PAIS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPais", CodigoPais);
            dap.Fill(dt);
            return dt;
        }

        public DataTable DatosPacientexId(string CodigoPaciente)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PACIENTE_ID, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
            dap.Fill(dt);
            return dt;
        }

        public DataTable RegistrarPacientes(string Nombres, string ApellidoP, string ApellidoM, int CodigoTipoDocumento, string DocumentoIdentidad, string FechaNacimiento,int Sexo)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPI_PACIENTE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Nombres", Nombres);
            dap.SelectCommand.Parameters.AddWithValue("@ApellidoP", ApellidoP);
            dap.SelectCommand.Parameters.AddWithValue("@ApellidoM", ApellidoM);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoTipoDocumento", CodigoTipoDocumento);
            dap.SelectCommand.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
            dap.SelectCommand.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            dap.SelectCommand.Parameters.AddWithValue("@Sexo", Sexo);
            dap.Fill(dt);
            return dt;
        }

        public DataTable MostrarParametrosxId(int Codigo)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PARAMETROS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Codigo", Codigo);
            dap.Fill(dt);
            return dt;
        }

        #endregion
    }
}
