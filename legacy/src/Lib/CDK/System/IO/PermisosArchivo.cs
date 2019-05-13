using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CDK.System.IO
{
    /// <summary>
    /// Configuring a Web site through a Web interface can be tricky. 
    /// If one is to read and write various files, it is useful to know 
    /// in advance if you have the authority to do so.
    /// 
    /// This class contains a simple answer to a 
    /// potentially complicated question 
    /// "Can I read this file or can I write to this file?"
    /// 
    /// Using the "rule of least privilege", 
    /// one must check not only is access granted but 
    /// is it denied at any point including a possibly recursive check of groups.
    /// 
    /// For this simple check, a look at the user and immediate groups are only checked.
    /// 
    /// This class could be expanded to identify if the applicable allow/deny rule
    /// was explicit or inherited
    /// 
    /// </summary>
    public class PermisosArchivo
    {

        private readonly string _path;
        private readonly WindowsIdentity _principal;

        private readonly bool _denyAppendData;
        private readonly bool _denyChangePermissions;
        private readonly bool _denyCreateDirectories;
        private readonly bool _denyCreateFiles;
        private readonly bool _denyDelete;
        private readonly bool _denyDeleteSubdirectoriesAndFiles;
        private readonly bool _denyExecuteFile;
        private readonly bool _denyFullControl;
        private readonly bool _denyListDirectory;
        private readonly bool _denyModify;
        private readonly bool _denyRead;
        private readonly bool _denyReadAndExecute;
        private readonly bool _denyReadAttributes;
        private readonly bool _denyReadData;
        private readonly bool _denyReadExtendedAttributes;
        private readonly bool _denyReadPermissions;
        private readonly bool _denySynchronize;
        private readonly bool _denyTakeOwnership;
        private readonly bool _denyTraverse;
        private readonly bool _denyWrite;
        private readonly bool _denyWriteAttributes;
        private readonly bool _denyWriteData;
        private readonly bool _denyWriteExtendedAttributes;

        private readonly bool _allowAppendData;
        private readonly bool _allowChangePermissions;
        private readonly bool _allowCreateDirectories;
        private readonly bool _allowCreateFiles;
        private readonly bool _allowDelete;
        private readonly bool _allowDeleteSubdirectoriesAndFiles;
        private readonly bool _allowExecuteFile;
        private readonly bool _allowFullControl;
        private readonly bool _allowListDirectory;
        private readonly bool _allowModify;
        private readonly bool _allowRead;
        private readonly bool _allowReadAndExecute;
        private readonly bool _allowReadAttributes;
        private readonly bool _allowReadData;
        private readonly bool _allowReadExtendedAttributes;
        private readonly bool _allowReadPermissions;
        private readonly bool _allowSynchronize;
        private readonly bool _allowTakeOwnership;
        private readonly bool _allowTraverse;
        private readonly bool _allowWrite;
        private readonly bool _allowWriteAttributes;
        private readonly bool _allowWriteData;
        private readonly bool _allowWriteExtendedAttributes;

        /// <summary>
        /// Determines whether this instance [can append data].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can append data]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeAnexarDatos()
        {
            return !_denyAppendData && _allowAppendData;
        }

        /// <summary>
        /// Determines whether this instance [can change permissions].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can change permissions]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeCambiarPermisos()
        {
            return !_denyChangePermissions && _allowChangePermissions;
        }

        /// <summary>
        /// Determines whether this instance [can create directories].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can create directories]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeCrearDirectorios()
        {
            return !_denyCreateDirectories && _allowCreateDirectories;
        }

        /// <summary>
        /// Determines whether this instance [can create files].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can create files]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeCrearArchivos()
        {
            return !_denyCreateFiles && _allowCreateFiles;
        }

        /// <summary>
        /// Determines whether this instance can delete.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can delete; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEliminar()
        {
            return !_denyDelete && _allowDelete;
        }

        /// <summary>
        /// Determines whether this instance [can delete subdirectories and files].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can delete subdirectories and files]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEliminarSubdirectoriosYArchivos()
        {
            return !_denyDeleteSubdirectoriesAndFiles &&
                   _allowDeleteSubdirectoriesAndFiles;
        }

        /// <summary>
        /// Determines whether this instance [can execute file].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can execute file]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEjecutarArchivos()
        {
            return !_denyExecuteFile && _allowExecuteFile;
        }

        /// <summary>
        /// Determines whether this instance [can full control].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can full control]; otherwise, <c>false</c>.
        /// </returns>
        public bool TieneControlTotal()
        {
            return !_denyFullControl && _allowFullControl;
        }

        /// <summary>
        /// Determines whether this instance [can list directory].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can list directory]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeListarDirectorio()
        {
            return !_denyListDirectory && _allowListDirectory;
        }

        /// <summary>
        /// Determines whether this instance can modify.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can modify; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeModificar()
        {
            return !_denyModify && _allowModify;
        }

        /// <summary>
        /// Determines whether this instance can read.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can read; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeer()
        {
            return !_denyRead && _allowRead;
        }

        /// <summary>
        /// Determines whether this instance [can read and execute].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can read and execute]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeerYEjecutar()
        {
            return !_denyReadAndExecute && _allowReadAndExecute;
        }

        /// <summary>
        /// Determines whether this instance [can read attributes].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can read attributes]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeerAtributos()
        {
            return !_denyReadAttributes && _allowReadAttributes;
        }

        /// <summary>
        /// Determines whether this instance [can read data].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can read data]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeerDatos()
        {
            return !_denyReadData && _allowReadData;
        }

        /// <summary>
        /// Determines whether this instance [can read extended attributes].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can read extended attributes]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeerAtributosExtendidos()
        {
            return !_denyReadExtendedAttributes &&
                   _allowReadExtendedAttributes;
        }

        /// <summary>
        /// Determines whether this instance [can read permissions].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can read permissions]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeLeerPermisos()
        {
            return !_denyReadPermissions && _allowReadPermissions;
        }

        /// <summary>
        /// Determines whether this instance can synchronize.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can synchronize; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeSincronizar()
        {
            return !_denySynchronize && _allowSynchronize;
        }

        /// <summary>
        /// Determines whether this instance [can take ownership].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can take ownership]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeSerPropietario()
        {
            return !_denyTakeOwnership && _allowTakeOwnership;
        }

        /// <summary>
        /// Determines whether this instance can traverse.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can traverse; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeAtravesar()
        {
            return !_denyTraverse && _allowTraverse;
        }

        /// <summary>
        /// Determines whether this instance can write.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can write; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEscribir()
        {
            return !_denyWrite && _allowWrite;
        }

        /// <summary>
        /// Determines whether this instance [can write attributes].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can write attributes]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEscribirAtributos()
        {
            return !_denyWriteAttributes && _allowWriteAttributes;
        }

        /// <summary>
        /// Determines whether this instance [can write data].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can write data]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEscribirDatos()
        {
            return !_denyWriteData && _allowWriteData;
        }

        /// <summary>
        /// Determines whether this instance [can write extended attributes].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can write extended attributes]; otherwise, <c>false</c>.
        /// </returns>
        public bool PuedeEscribirAtributosExtendidos()
        {
            return !_denyWriteExtendedAttributes &&
                   _allowWriteExtendedAttributes;
        }

        /// <summary>
        /// Simple accessor
        /// </summary>
        /// <returns></returns>
        public WindowsIdentity ObtenerIdentidadWindows()
        {
            return _principal;
        }

        /// <summary>
        /// Simple accessor
        /// </summary>
        /// <returns></returns>
        public String ObtenerRuta()
        {
            return _path;
        }

        /// <summary>
        /// Convenience constructor assumes the current user
        /// </summary>
        /// <param name="path"></param>
        public PermisosArchivo(string path) :
            this(path, WindowsIdentity.GetCurrent())
        {
        }


        /// <summary>
        /// Supply the path to the file or directory and a user or group. 
        /// Access checks are done
        /// during instantiation to ensure we always have a valid object
        /// </summary>
        /// <param name="path"></param>
        /// <param name="principal"></param>
        public PermisosArchivo(string path, WindowsIdentity principal)
        {
            _path = path;
            _principal = principal;

            try
            {
                FileInfo fi = new FileInfo(_path);
                AuthorizationRuleCollection acl = fi.GetAccessControl().GetAccessRules(true, true, typeof (SecurityIdentifier));

                for (int i = 0; i < acl.Count; i++)
                {
                    FileSystemAccessRule rule = (FileSystemAccessRule) acl[i];
                    if (rule != null && (_principal.User != null && _principal.User.Equals(rule.IdentityReference)))
                    {
                        if (AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            if (Contiene(FileSystemRights.AppendData, rule))
                                _denyAppendData = true;
                            if (Contiene(FileSystemRights.ChangePermissions, rule))
                                _denyChangePermissions = true;
                            if (Contiene(FileSystemRights.CreateDirectories, rule))
                                _denyCreateDirectories = true;
                            if (Contiene(FileSystemRights.CreateFiles, rule))
                                _denyCreateFiles = true;
                            if (Contiene(FileSystemRights.Delete, rule))
                                _denyDelete = true;
                            if (Contiene(FileSystemRights.DeleteSubdirectoriesAndFiles, rule))
                                _denyDeleteSubdirectoriesAndFiles = true;
                            if (Contiene(FileSystemRights.ExecuteFile, rule))
                                _denyExecuteFile = true;
                            if (Contiene(FileSystemRights.FullControl, rule))
                                _denyFullControl = true;
                            if (Contiene(FileSystemRights.ListDirectory, rule))
                                _denyListDirectory = true;
                            if (Contiene(FileSystemRights.Modify, rule))
                                _denyModify = true;
                            if (Contiene(FileSystemRights.Read, rule))
                                _denyRead = true;
                            if (Contiene(FileSystemRights.ReadAndExecute, rule))
                                _denyReadAndExecute = true;
                            if (Contiene(FileSystemRights.ReadAttributes, rule))
                                _denyReadAttributes = true;
                            if (Contiene(FileSystemRights.ReadData, rule))
                                _denyReadData = true;
                            if (Contiene(FileSystemRights.ReadExtendedAttributes, rule))
                                _denyReadExtendedAttributes = true;
                            if (Contiene(FileSystemRights.ReadPermissions, rule))
                                _denyReadPermissions = true;
                            if (Contiene(FileSystemRights.Synchronize, rule))
                                _denySynchronize = true;
                            if (Contiene(FileSystemRights.TakeOwnership, rule))
                                _denyTakeOwnership = true;
                            if (Contiene(FileSystemRights.Traverse, rule))
                                _denyTraverse = true;
                            if (Contiene(FileSystemRights.Write, rule))
                                _denyWrite = true;
                            if (Contiene(FileSystemRights.WriteAttributes, rule))
                                _denyWriteAttributes = true;
                            if (Contiene(FileSystemRights.WriteData, rule))
                                _denyWriteData = true;
                            if (Contiene(FileSystemRights.WriteExtendedAttributes, rule))
                                _denyWriteExtendedAttributes = true;
                        }
                        else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (Contiene(FileSystemRights.AppendData, rule))
                                _allowAppendData = true;
                            if (Contiene(FileSystemRights.ChangePermissions, rule))
                                _allowChangePermissions = true;
                            if (Contiene(FileSystemRights.CreateDirectories, rule))
                                _allowCreateDirectories = true;
                            if (Contiene(FileSystemRights.CreateFiles, rule))
                                _allowCreateFiles = true;
                            if (Contiene(FileSystemRights.Delete, rule))
                                _allowDelete = true;
                            if (Contiene(FileSystemRights.DeleteSubdirectoriesAndFiles, rule))
                                _allowDeleteSubdirectoriesAndFiles = true;
                            if (Contiene(FileSystemRights.ExecuteFile, rule))
                                _allowExecuteFile = true;
                            if (Contiene(FileSystemRights.FullControl, rule))
                                _allowFullControl = true;
                            if (Contiene(FileSystemRights.ListDirectory, rule))
                                _allowListDirectory = true;
                            if (Contiene(FileSystemRights.Modify, rule))
                                _allowModify = true;
                            if (Contiene(FileSystemRights.Read, rule))
                                _allowRead = true;
                            if (Contiene(FileSystemRights.ReadAndExecute, rule))
                                _allowReadAndExecute = true;
                            if (Contiene(FileSystemRights.ReadAttributes, rule))
                                _allowReadAttributes = true;
                            if (Contiene(FileSystemRights.ReadData, rule))
                                _allowReadData = true;
                            if (Contiene(FileSystemRights.ReadExtendedAttributes, rule))
                                _allowReadExtendedAttributes = true;
                            if (Contiene(FileSystemRights.ReadPermissions, rule))
                                _allowReadPermissions = true;
                            if (Contiene(FileSystemRights.Synchronize, rule))
                                _allowSynchronize = true;
                            if (Contiene(FileSystemRights.TakeOwnership, rule))
                                _allowTakeOwnership = true;
                            if (Contiene(FileSystemRights.Traverse, rule))
                                _allowTraverse = true;
                            if (Contiene(FileSystemRights.Write, rule))
                                _allowWrite = true;
                            if (Contiene(FileSystemRights.WriteAttributes, rule))
                                _allowWriteAttributes = true;
                            if (Contiene(FileSystemRights.WriteData, rule))
                                _allowWriteData = true;
                            if (Contiene(FileSystemRights.WriteExtendedAttributes, rule))
                                _allowWriteExtendedAttributes = true;
                        }
                    }
                }

                IdentityReferenceCollection groups = _principal.Groups;
                if (groups != null)
                {
                    foreach (IdentityReference identity in groups)
                    {
                        for (int i = 0; i < acl.Count; i++)
                        {
                            FileSystemAccessRule rule = (FileSystemAccessRule) acl[i];
                            if (rule != null && identity.Equals(rule.IdentityReference))
                            {
                                if (AccessControlType.Deny.Equals(rule.AccessControlType))
                                {
                                    if (Contiene(FileSystemRights.AppendData, rule))
                                        _denyAppendData = true;
                                    if (Contiene(FileSystemRights.ChangePermissions, rule))
                                        _denyChangePermissions = true;
                                    if (Contiene(FileSystemRights.CreateDirectories, rule))
                                        _denyCreateDirectories = true;
                                    if (Contiene(FileSystemRights.CreateFiles, rule))
                                        _denyCreateFiles = true;
                                    if (Contiene(FileSystemRights.Delete, rule))
                                        _denyDelete = true;
                                    if (Contiene(FileSystemRights.DeleteSubdirectoriesAndFiles, rule))
                                        _denyDeleteSubdirectoriesAndFiles = true;
                                    if (Contiene(FileSystemRights.ExecuteFile, rule))
                                        _denyExecuteFile = true;
                                    if (Contiene(FileSystemRights.FullControl, rule))
                                        _denyFullControl = true;
                                    if (Contiene(FileSystemRights.ListDirectory, rule))
                                        _denyListDirectory = true;
                                    if (Contiene(FileSystemRights.Modify, rule))
                                        _denyModify = true;
                                    if (Contiene(FileSystemRights.Read, rule))
                                        _denyRead = true;
                                    if (Contiene(FileSystemRights.ReadAndExecute, rule))
                                        _denyReadAndExecute = true;
                                    if (Contiene(FileSystemRights.ReadAttributes, rule))
                                        _denyReadAttributes = true;
                                    if (Contiene(FileSystemRights.ReadData, rule))
                                        _denyReadData = true;
                                    if (Contiene(FileSystemRights.ReadExtendedAttributes, rule))
                                        _denyReadExtendedAttributes = true;
                                    if (Contiene(FileSystemRights.ReadPermissions, rule))
                                        _denyReadPermissions = true;
                                    if (Contiene(FileSystemRights.Synchronize, rule))
                                        _denySynchronize = true;
                                    if (Contiene(FileSystemRights.TakeOwnership, rule))
                                        _denyTakeOwnership = true;
                                    if (Contiene(FileSystemRights.Traverse, rule))
                                        _denyTraverse = true;
                                    if (Contiene(FileSystemRights.Write, rule))
                                        _denyWrite = true;
                                    if (Contiene(FileSystemRights.WriteAttributes, rule))
                                        _denyWriteAttributes = true;
                                    if (Contiene(FileSystemRights.WriteData, rule))
                                        _denyWriteData = true;
                                    if (Contiene(FileSystemRights.WriteExtendedAttributes, rule))
                                        _denyWriteExtendedAttributes = true;
                                }
                                else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                                {
                                    if (Contiene(FileSystemRights.AppendData, rule))
                                        _allowAppendData = true;
                                    if (Contiene(FileSystemRights.ChangePermissions, rule))
                                        _allowChangePermissions = true;
                                    if (Contiene(FileSystemRights.CreateDirectories, rule))
                                        _allowCreateDirectories = true;
                                    if (Contiene(FileSystemRights.CreateFiles, rule))
                                        _allowCreateFiles = true;
                                    if (Contiene(FileSystemRights.Delete, rule))
                                        _allowDelete = true;
                                    if (Contiene(FileSystemRights.DeleteSubdirectoriesAndFiles, rule))
                                        _allowDeleteSubdirectoriesAndFiles = true;
                                    if (Contiene(FileSystemRights.ExecuteFile, rule))
                                        _allowExecuteFile = true;
                                    if (Contiene(FileSystemRights.FullControl, rule))
                                        _allowFullControl = true;
                                    if (Contiene(FileSystemRights.ListDirectory, rule))
                                        _allowListDirectory = true;
                                    if (Contiene(FileSystemRights.Modify, rule))
                                        _allowModify = true;
                                    if (Contiene(FileSystemRights.Read, rule))
                                        _allowRead = true;
                                    if (Contiene(FileSystemRights.ReadAndExecute, rule))
                                        _allowReadAndExecute = true;
                                    if (Contiene(FileSystemRights.ReadAttributes, rule))
                                        _allowReadAttributes = true;
                                    if (Contiene(FileSystemRights.ReadData, rule))
                                        _allowReadData = true;
                                    if (Contiene(FileSystemRights.ReadExtendedAttributes, rule))
                                        _allowReadExtendedAttributes = true;
                                    if (Contiene(FileSystemRights.ReadPermissions, rule))
                                        _allowReadPermissions = true;
                                    if (Contiene(FileSystemRights.Synchronize, rule))
                                        _allowSynchronize = true;
                                    if (Contiene(FileSystemRights.TakeOwnership, rule))
                                        _allowTakeOwnership = true;
                                    if (Contiene(FileSystemRights.Traverse, rule))
                                        _allowTraverse = true;
                                    if (Contiene(FileSystemRights.Write, rule))
                                        _allowWrite = true;
                                    if (Contiene(FileSystemRights.WriteAttributes, rule))
                                        _allowWriteAttributes = true;
                                    if (Contiene(FileSystemRights.WriteData, rule))
                                        _allowWriteData = true;
                                    if (Contiene(FileSystemRights.WriteExtendedAttributes, rule))
                                        _allowWriteExtendedAttributes = true;
                                }
                            }
                        }
                    }
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
                //Deal with IO exceptions if you want
            }
        }

        /// <summary>
        /// Simply displays all allowed rights
        /// Useful if say you want to test for write access and find
        /// it is false;
        /// </summary>
        /// <example>
        /// UserFileAccessRights rights = new UserFileAccessRights(txtLogPath.Text);
        /// System.IO.FileInfo fi = new System.IO.FileInfo(txtLogPath.Text);
        /// if (rights.PuedeEscribir() &amp;&amp; rights.PuedeLeer()) {
        ///     lblLogMsg.Text = "R/W access";
        /// } else {
        ///     if (rights.PuedeEscribir()) {
        ///        lblLogMsg.Text = "Only Write access";
        ///     } else if (rights.canRead()) {
        ///         lblLogMsg.Text = "Only Read access";
        ///     } else {
        ///         lblLogMsg.CssClass = "error";
        ///         lblLogMsg.Text = rights.ToString()
        ///     }
        /// }
        /// 
        /// </example>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override String ToString()
        {
            string str = "";

            if (PuedeAnexarDatos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str +=
                        ",";
                str += "AppendData";
            }
            if (PuedeCambiarPermisos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str +=
                        ",";
                str += "ChangePermissions";
            }
            if (PuedeCrearDirectorios())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str +=
                        ",";
                str += "CreateDirectories";
            }
            if (PuedeCrearArchivos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str +=
                        ",";
                str += "CreateFiles";
            }
            if (PuedeEliminar())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str +=
                        ",";
                str += "Delete";
            }
            if (PuedeEliminarSubdirectoriosYArchivos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "DeleteSubdirectoriesAndFiles";
            }
            if (PuedeEjecutarArchivos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ExecuteFile";
            }
            if (TieneControlTotal())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "FullControl";
            }
            if (PuedeListarDirectorio())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ListDirectory";
            }
            if (PuedeModificar())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "Modify";
            }
            if (PuedeLeer())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "Read";
            }
            if (PuedeLeerYEjecutar())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ReadAndExecute";
            }
            if (PuedeLeerAtributos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ReadAttributes";
            }
            if (PuedeLeerDatos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ReadData";
            }
            if (PuedeLeerAtributosExtendidos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ReadExtendedAttributes";
            }
            if (PuedeLeerPermisos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "ReadPermissions";
            }
            if (PuedeSincronizar())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "Synchronize";
            }
            if (PuedeSerPropietario())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "TakeOwnership";
            }
            if (PuedeAtravesar())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "Traverse";
            }
            if (PuedeEscribir())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "Write";
            }
            if (PuedeEscribirAtributos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "WriteAttributes";
            }
            if (PuedeEscribirDatos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "WriteData";
            }
            if (PuedeEscribirAtributosExtendidos())
            {
                if (!string.IsNullOrWhiteSpace(str))
                    str += ",";
                str += "WriteExtendedAttributes";
            }
            if (string.IsNullOrWhiteSpace(str))
                str = "None";
            return str;
        }

        /// <summary>
        /// Convenience method to test if the right exists within the given rights
        /// </summary>
        /// <param name="right"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public bool Contiene(FileSystemRights right, FileSystemAccessRule rule)
        {
            return (((int) right & (int) rule.FileSystemRights) == (int) right);
        }
    }
}
