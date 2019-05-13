using System;
using System.IO;
using System.Reflection;

namespace CDK.System.IO
{
    /// <summary>
    /// Clase de ayuda para funciones de manejo de carpetas
    /// </summary>
    public static class FolderHelper
    {
        /// <summary>
        /// Obtiene la ubicación absoluta de una carpeta y/o archivo usando como referencia la ubicación local del Assembly activo.
        /// </summary>
        /// <param name="folder">Ruta local o absoluta a la carpeta</param>
        /// <param name="filename">Nombre del archivo</param>
        /// <returns>Ruta absoluta de la carpeta y/o archivo</returns>
        public static string ObtenerRutaAbsoluta(string folder, string filename = "")
        {
            if (string.IsNullOrWhiteSpace(folder))
            {
                throw new ArgumentNullException("folder");
            }

            string directorioAplicacion = ObtenerDirectorioAplicacion();

            if (string.IsNullOrWhiteSpace(filename))
            {
                return Path.IsPathRooted(folder) ? folder : Path.GetFullPath(Path.Combine(directorioAplicacion, folder));
            }
            return Path.IsPathRooted(folder) ? Path.Combine(folder, filename) : Path.GetFullPath(Path.Combine(directorioAplicacion, folder, filename));
        }

        /// <summary>
        /// Obtiene la ubicación absoluta de un archivo local respecto a un archivo base
        /// </summary>
        /// <param name="rutaRelativa">Ruta relativa o absoluta</param>
        /// <param name="archivoBase">Archivo base para obtener la ruta absoluta</param>
        /// <returns>Ruta absoluta del archivo</returns>
        public static string ObtenerRutaAbsolutaRelativaArchivo(string rutaRelativa, string archivoBase)
        {
            if (string.IsNullOrWhiteSpace(rutaRelativa))
            {
                throw new ArgumentNullException("rutaRelativa");
            }

            if (!Path.IsPathRooted(archivoBase))
            {
                throw new IOException("Parametro '" + archivoBase + "' no corresponde a una ruta absoluta válida");
            }

            if (Path.IsPathRooted(rutaRelativa))
            {
                return rutaRelativa;
            }

            string carpetaArchivoBase = Path.GetDirectoryName(archivoBase) ?? ObtenerDirectorioAplicacion();

            return Path.GetFullPath(Path.Combine(carpetaArchivoBase, rutaRelativa));
        }

        /// <summary>
        /// Recupera el directorio de la aplicación
        /// </summary>
        /// <returns>Carpeta absouta de la aplicación</returns>
        public static string ObtenerDirectorioAplicacion()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                return Path.GetDirectoryName(assembly.Location) ?? Directory.GetCurrentDirectory();
            }
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Crea un directorio si y solo sí no existe
        /// </summary>
        /// <param name="folder">Ruta local o absoluta a la carpeta.</param>
        /// <param name="esAbsoluta">Dejar en <c>true</c> para indicar si la carpeta es ruta absoluta o es necesario calcularla usando <see cref="ObtenerRutaAbsoluta"/>.</param>
        public static void CrearDirectorio(string folder, bool esAbsoluta = true)
        {
            string carpetaAbsoluta = esAbsoluta ? folder : ObtenerRutaAbsoluta(folder);

            if (!Directory.Exists(carpetaAbsoluta))
            {
                Directory.CreateDirectory(carpetaAbsoluta);
            }
        }
    }
}
