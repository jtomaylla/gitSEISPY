using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBVisitas
    {
        #region Atributos
        CDVisitas objCDVisitas;
        #endregion

        #region Constructor
        public CBVisitas()
        { objCDVisitas = new CDVisitas(); }
        #endregion

        #region metodos
        public DataTable CargarGrupoVisitaxProy(int CodigoProyecto)
        { return objCDVisitas.CargarGrupoVisitaxProy(CodigoProyecto); }

        public int RegID_ENR(int CodigoLocal, int CodigoProyecto, string IdENR)
        { return objCDVisitas.RegID_ENR(CodigoLocal, CodigoProyecto, IdENR); }

        public int RegID_TAM(int CodigoLocal, int CodigoProyecto, string IdTAM)
        { return objCDVisitas.RegID_TAM(CodigoLocal, CodigoProyecto, IdTAM); }

        public int ActualizarFechaVAdmin(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, string Fecha)
        { return objCDVisitas.ActualizarFechaVAdmin(CodigoLocal, CodigoProyecto, CodigoVisita, CodigoVisitas, CodigoPaciente, Fecha); }

        public int ActualizarEstadoVAdmin(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, int CodigoEstadoVisita)
        { return objCDVisitas.ActualizarEstadoVAdmin(CodigoLocal, CodigoProyecto, CodigoVisita, CodigoVisitas, CodigoPaciente, CodigoEstadoVisita); }

        public DataTable InsertarVisitasAuto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int CodigoUsuario)
        { return objCDVisitas.InsertarVisitasAuto(CodigoLocal, CodigoProyecto, CodigoPaciente,CodigoUsuario); }

        public DataTable RegistrarIdENRauto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int IdUsuario)
        { return objCDVisitas.RegistrarIdENRauto(CodigoLocal, CodigoProyecto, CodigoPaciente, IdUsuario); }

        public DataTable RegistrarIdENR(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, string IdENR, int IdUsuario)
        { return objCDVisitas.RegistrarIdENR(CodigoLocal, CodigoProyecto, CodigoPaciente, IdENR, IdUsuario); }

        public DataTable RegistrarIdTAMauto(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, int IdUsuario)
        { return objCDVisitas.RegistrarIdTAMauto(CodigoLocal, CodigoProyecto, CodigoPaciente, IdUsuario); }

        public DataTable RegistrarIdTAM(int CodigoLocal, int CodigoProyecto, string CodigoPaciente, string IdTAM, int IdUsuario)
        { return objCDVisitas.RegistrarIdTAM(CodigoLocal, CodigoProyecto, CodigoPaciente, IdTAM, IdUsuario); }

        public DataTable ListarDatosxPaciente(int CodigoLocal, int CodigoProyecto, string CodigoPaciente)
        { return objCDVisitas.ListarDatosxPaciente(CodigoLocal, CodigoProyecto, CodigoPaciente); }

        public DataTable ListarErroresxPaciente(int CodigoLocal, int CodigoProyecto, string CodigoUsuarioError, string CodigoPaciente, string FechaError)
        { return objCDVisitas.ListarErroresxPaciente(CodigoLocal, CodigoProyecto, CodigoUsuarioError, CodigoPaciente, FechaError); }

        public int EditarErrores(int CodigoError, string CodigoPaciente, int CodigoLocal, int CodigoProyecto, int CodigoDocumento, int CodigoTipoError, int CodigoUsuarioError, string FechaError, string NomDoc, int Cantidad, int A72, int CodigoUsuario)
        { return objCDVisitas.EditarErrores(CodigoError, CodigoPaciente, CodigoLocal, CodigoProyecto, CodigoDocumento, CodigoTipoError, CodigoUsuarioError, FechaError, NomDoc, Cantidad, A72, CodigoUsuario); }

        public int RegistraErrores(string CodigoPaciente, int CodigoLocal, int CodigoProyecto, int CodigoDocumento, int CodigoTipoError, int CodigoUsuarioError, string FechaError, string NomDoc, int Cantidad, int A72, int CodigoUsuario)
        { return objCDVisitas.RegistraErrores(CodigoPaciente, CodigoLocal, CodigoProyecto, CodigoDocumento, CodigoTipoError, CodigoUsuarioError, FechaError, NomDoc, Cantidad,A72,CodigoUsuario); }

        public int EditarKardex(int CodigoKardex, string CodigoPaciente, int CodigoUsuarioD)
        { return objCDVisitas.EditarKardex(CodigoKardex, CodigoPaciente, CodigoUsuarioD); }

        public int RegistraKardex(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, string FechaVisita, int CodigoUsuarioE)
        { return objCDVisitas.RegistraKardex(CodigoLocal, CodigoProyecto, CodigoVisita, CodigoVisitas, CodigoPaciente, FechaVisita, CodigoUsuarioE); }

        public int EditarVisita(int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita, string Nombre, string Descripcion, int Auto, int DiasVisitaProx, int CodigoGrupoVisitaProx, int CodigoVisitaProx, int DiasAntes, int DiasDespues, int Orden, int Estado)
        { return objCDVisitas.EditarVisita(CodigoProyecto, CodigoGrupoVisita, CodigoVisita, Nombre, Descripcion, Auto, DiasVisitaProx,CodigoGrupoVisitaProx, CodigoVisitaProx, DiasAntes, DiasDespues,Orden, Estado); }

        public int RegistraVisita(int CodigoProyecto, int CodigoGrupoVisita, string Nombre, string Descripcion, int Auto, int DiasVisitaProx, int CodigoGrupoVisitaProx, int CodigoVisitaProx, int DiasAntes, int DiasDespues)
        { return objCDVisitas.RegistraVisita(CodigoProyecto, CodigoGrupoVisita, Nombre, Descripcion, Auto, DiasVisitaProx, CodigoGrupoVisitaProx, CodigoVisitaProx, DiasAntes, DiasDespues); }

        public DataTable ListarVisitaxIdxProy(int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita)
        { return objCDVisitas.ListarVisitaxIdxProy(CodigoProyecto, CodigoGrupoVisita, CodigoVisita); }

        public DataTable CargarVisitaxProy(int CodigoProyecto, int CodigoGrupoVisita)
        { return objCDVisitas.CargarVisitaxProy(CodigoProyecto, CodigoGrupoVisita); }

        public int ActualizarEstadoV(int CodigoLocal, int CodigoProyecto, int CodigoVisita, int CodigoVisitas, string CodigoPaciente, int CodigoEstadoVisita, int CodigoEstatusPaciente, int CodigoUsuario)
        { return objCDVisitas.ActualizarEstadoV(CodigoLocal, CodigoProyecto, CodigoVisita, CodigoVisitas, CodigoPaciente, CodigoEstadoVisita, CodigoEstatusPaciente, CodigoUsuario); }

        public DataTable GetBusquedaVisitasA(int intLocal, int intProyecto, int intEstCita, string FechaD, string FechaH, string Nom)
        { return objCDVisitas.GetBusquedaVisitasA(intLocal, intProyecto, intEstCita, FechaD, FechaH, Nom); }

        public DataTable GetBusquedaVisitasS(int intLocal, int intProyecto, int intEstCita, string FechaD)
        { return objCDVisitas.GetBusquedaVisitasS(intLocal, intProyecto, intEstCita, FechaD); }

        public DataTable ListarVisitasxPaciente(string CodigoPaciente)
        { return objCDVisitas.ListarVisitasxPaciente(CodigoPaciente); }

        public int InsertarVisitas(int CodigoLocal, int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita, string CodigoPaciente, string FechaVisita, string HoraCita, int CodigoUsuario)
        { return objCDVisitas.InsertarVisitas(CodigoLocal, CodigoProyecto, CodigoGrupoVisita, CodigoVisita, CodigoPaciente, FechaVisita, HoraCita, CodigoUsuario); }

        #endregion
    }
}
