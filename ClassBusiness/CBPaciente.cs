using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBPaciente
    {
        #region Atributos
        CDPaciente objCDPaciente;
        #endregion

        #region Constructor
        public CBPaciente()
        { objCDPaciente= new CDPaciente(); }
        #endregion

        #region metodos

        public DataTable EstatusPacientexId(int Codigo)
        { return objCDPaciente.EstatusPacientexId(Codigo); }

        public DataTable EditarPacientes(string IdPaciente, string Nombres, string ApellidoP, string ApellidoM, int CodigoTipoDocumento, string DocumentoIdentidad, string FechaNacimiento, int Sexo)
        { return objCDPaciente.EditarPacientes(IdPaciente,Nombres, ApellidoP, ApellidoM, CodigoTipoDocumento, DocumentoIdentidad, FechaNacimiento, Sexo); }

        public DataTable GetMostrarDatosLocalProy(string CodigoPaciente, int CodigoLocal, int CodigoProyecto)
        { return objCDPaciente.GetMostrarDatosLocalProy(CodigoPaciente, CodigoLocal, CodigoProyecto); }

        public DataTable BuscarPacxDatos(string ApeP, string ApeM, string Nom, string FN)
        { return objCDPaciente.BuscarPacxDatos(ApeP,ApeM,Nom,FN); }

        public DataTable BuscarPacxDocumento(string Documento)
        { return objCDPaciente.BuscarPacxDocumento(Documento); }

        public int InsertarContacto(string CodigoPaciente, string CodigoUbigeo, string Direccion, string Referencia, string Telefono1, string Telefono2, string Celular)
        { return objCDPaciente.InsertarContacto(CodigoPaciente, CodigoUbigeo, Direccion, Referencia, Telefono1, Telefono2, Celular); }

        public DataTable DatosPacienteContactoxId(string CodigoPaciente)
        { return objCDPaciente.DatosPacienteContactoxId(CodigoPaciente); }

        public DataTable GetUbigeoPais(int CodigoPais)
        { return objCDPaciente.GetUbigeoPais(CodigoPais); }

        public DataTable GetUbigeoDep(int CodigoDepartamento)
        { return objCDPaciente.GetUbigeoDep(CodigoDepartamento); }

        public DataTable GetUbigeoProv(int Codigoprovincia)
        { return objCDPaciente.GetUbigeoProv(Codigoprovincia); }

        public DataTable DatosPacientexId(string CodigoPaciente)
        { return objCDPaciente.DatosPacientexId(CodigoPaciente); }

        public DataTable RegistrarPacientes(string Nombres, string ApellidoP, string ApellidoM, int CodigoTipoDocumento, string DocumentoIdentidad, string FechaNacimiento, int Sexo)
        { return objCDPaciente.RegistrarPacientes(Nombres, ApellidoP, ApellidoM, CodigoTipoDocumento, DocumentoIdentidad, FechaNacimiento, Sexo); }

        public DataTable MostrarParametrosxId(int Codigo)
        { return objCDPaciente.MostrarParametrosxId(Codigo); }

        #endregion
    }
}
