using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBLocal
    {
        #region Atributos
        CDLocal objCDLocal;
        #endregion

        #region Constructor
        public CBLocal()
        { objCDLocal = new CDLocal(); }
        #endregion

        #region metodos
        public DataTable ListarProyectoxLocalxUser(int CodigoLocal, int CodigoUsuario)
        { return objCDLocal.ListarProyectoxLocalxUser(CodigoLocal, CodigoUsuario); }

        public DataTable ListarLocalesxUser(int CodigoUsuario)
        { return objCDLocal.ListarLocalesxUser(CodigoUsuario); }

        public DataTable ListarProyectoxLocal(int CodigoLocal)
        { return objCDLocal.ListarProyectoxLocal(CodigoLocal); }

        public int ModificarLocales(int CodigoLocal, int IdEmpresa, string Nombre, string Descripcion, string Direccion, string Distrito, string Telefono, int Estatus, int Estado)
        { return objCDLocal.ModificarLocales(CodigoLocal,IdEmpresa, Nombre, Descripcion, Direccion, Distrito, Telefono, Estatus, Estado); }

        public int InsertarLocales(int IdEmpresa, string Nombre, string Descripcion, string Direccion, string Distrito, string Telefono, int Estatus, int Estado)
        { return objCDLocal.InsertarLocales(IdEmpresa, Nombre, Descripcion, Direccion, Distrito, Telefono, Estatus, Estado); }

        public DataTable ListarLocalesxID(int CodigoLocal)
        { return objCDLocal.ListarLocalesxID(CodigoLocal); }

        public DataTable ListarLocalesAll()
        { return objCDLocal.ListarLocalesAll(); }

        public DataTable ListarEmpresasAct()
        { return objCDLocal.ListarEmpresasAct(); }

        public DataTable ListarLocales()
        { return objCDLocal.ListarLocales(); }


        #endregion
    }
}
