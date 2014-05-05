using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBUsuario
    {
        #region Atributos
        CDUsuario objCDUsuario;
        #endregion

        #region Constructor
        public CBUsuario()
        { objCDUsuario = new CDUsuario(); }
        #endregion

        #region metodos
        public int InsertarProyectosxUser(int IdUser, int CodigoProyecto, int Estado)
        { return objCDUsuario.InsertarProyectosxUser(IdUser, CodigoProyecto, Estado); }

        public DataTable GetListarProyectosxUser(int CodigoUsuario)
        { return objCDUsuario.GetListarProyectosxUser(CodigoUsuario); }

        public DataTable ListarUsuariosxLocalRol(int IdLocal)
        { return objCDUsuario.ListarUsuariosxLocalRol(IdLocal); }

        public int InsertarRolesxUser(int IdUser, int CodigoRol, int Estado)
        { return objCDUsuario.InsertarRolesxUser(IdUser, CodigoRol,Estado); }

        public DataTable GetListarRolesxUser(int CodigoUsuario)
        { return objCDUsuario.GetListarRolesxUser(CodigoUsuario); }

        public int ActualizarUsuario(int CodigoUsuario, int IdLocal, string LoginUsuario, string NombreUsuario, string Iniciales, string correo, int Estado)
        { return objCDUsuario.EditarUsuario(CodigoUsuario,IdLocal, LoginUsuario, NombreUsuario, Iniciales, correo, Estado); }

        public DataTable ObtenerUsuario(int CodigoUsuario)
        { return objCDUsuario.GetUsuario(CodigoUsuario); }

        public int AgregarUsuario(int IdLocal, string LoginUsuario, string NombreUsuario, string Iniciales, string correo)
        { return objCDUsuario.InsertarUsuario(IdLocal, LoginUsuario, NombreUsuario, Iniciales, correo,0,1); }

        public int ResetearPassword(int IdUser)
        { return objCDUsuario.ResetearPassword(IdUser); }

        public DataTable ListarUsuariosxLocal(int IdLocal)
        { return objCDUsuario.ListarUsuariosxLocal(IdLocal); }

        public DataTable GetMenuData(int strUsu)
        { return objCDUsuario.GetMenuData(strUsu); }

        public DataTable GetCambiarClave(int strUsu, string ClaveA, string ClaveN)
        { return objCDUsuario.GetCambiarClave(strUsu, ClaveA, ClaveN); }

        public DataTable GetValidarUsuario(string strUsu, string strCont, int intIdLocal)
        { return objCDUsuario.GetValidarUsuario(strUsu, strCont, intIdLocal); }

        #endregion
    }
}
