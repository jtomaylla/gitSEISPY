using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBProyecto
    {
        #region Atributos
        CDProyecto objCDProyecto;
        #endregion

        #region Constructor
        public CBProyecto()
        { objCDProyecto = new CDProyecto(); }
        #endregion

        #region metodos
        public int EditCodENR(int CodigoLocal, int CodigoProyecto, int CodigoENR, string Numero)
        { return objCDProyecto.EditCodENR(CodigoLocal, CodigoProyecto, CodigoENR, Numero); }

        public int LimiarCodENR(int CodigoLocal, int CodigoProyecto, int CodigoENR)
        { return objCDProyecto.LimiarCodENR(CodigoLocal, CodigoProyecto, CodigoENR); }

        public DataTable ListarCodEnrolamiento(int CodigoLocal, int idProyecto, string numero)
        { return objCDProyecto.ListarCodEnrolamiento(CodigoLocal, idProyecto, numero); }

        public int EditCodTAM(int CodigoLocal, int CodigoProyecto, int CodigoTAM, string Numero)
        { return objCDProyecto.EditCodTAM(CodigoLocal, CodigoProyecto, CodigoTAM, Numero); }

        public int LimiarCodTAM(int CodigoLocal, int CodigoProyecto, int CodigoTAM)
        { return objCDProyecto.LimiarCodTAM(CodigoLocal, CodigoProyecto, CodigoTAM); }

        public DataTable ListarCodTamizaje(int CodigoLocal, int idProyecto, string numero)
        { return objCDProyecto.ListarCodTamizaje(CodigoLocal, idProyecto, numero); }

        public DataTable ListarVisitasxProyecto(int CodigoProyecto)
        { return objCDProyecto.ListarVisitasxProyecto(CodigoProyecto); }

        public int InsertarLocalesxProyecto(int CodigoLocal, int CodigoProyecto, int Estado)
        { return objCDProyecto.InsertarLocalesxProyecto(CodigoLocal, CodigoProyecto, Estado); }

        public DataTable ListarLocalesxProyecto(int CodigoProyecto)
        { return objCDProyecto.ListarLocalesxProyecto(CodigoProyecto); }

        public int ModificarGrupo(int CodigoGrupoVisita, int CodigoProyecto, string Nombre, int orden, int Estado)
        { return objCDProyecto.ModificarGrupo(CodigoGrupoVisita,CodigoProyecto, Nombre, orden, Estado); }

        public int InsertarGrupo(int CodigoProyecto, string Nombre, int orden, int Estado)
        { return objCDProyecto.InsertarGrupo(CodigoProyecto, Nombre, orden, Estado); }

        public DataTable ListarGrupoxId(int CodigoGrupoVisita)
        { return objCDProyecto.ListarGrupoxId(CodigoGrupoVisita); }

        public DataTable ListarGrupoxProyecto(int CodigoProyecto)
        { return objCDProyecto.ListarGrupoxProyecto(CodigoProyecto); }

        public DataTable ListarProyectosxID(int CodigoProyecto)
        { return objCDProyecto.ListarProyectosxID(CodigoProyecto); }

        public int ModificarProyecto(int CodigoProyecto, int CodigoRedes, string Nombre, string Descripcion, string FechaInicio, string FechaFin, int TAM, int ENR, int tipoTAM, int tipoENR, int Estatus, int Estado)
        { return objCDProyecto.ModificarProyecto(CodigoProyecto, CodigoRedes, Nombre, Descripcion, FechaInicio, FechaFin, TAM, ENR, tipoTAM, tipoENR, Estatus, Estado); }

        public int InsertarProyecto(int CodigoRedes, string Nombre, string Descripcion, string FechaInicio, string FechaFin, int TAM, int ENR, int tipoTAM, int tipoENR, int Estatus, int Estado)
        { return objCDProyecto.InsertarProyecto(CodigoRedes, Nombre, Descripcion, FechaInicio, FechaFin, TAM, ENR, tipoTAM, tipoENR, Estatus, Estado); }

        public DataTable ListarProyectosxRed(int idRed)
        { return objCDProyecto.ListarProyectosxRed(idRed); }

        public DataTable ListarProyectos()
        { return objCDProyecto.ListarProyectos(); }

        public DataTable ListarRedes()
        { return objCDProyecto.ListarRedes(); }

        #endregion
    }
}
