using System;
using System.IO;
using System.Text;

namespace CDK.System.IO
{
    /// <summary>
    /// FileHelper
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Obtiene la ubicación absoluta de un archivo usando como referencia la ubicación local del Assembly activo.
        /// </summary>
        /// <param name="filename">Nombre del archivo</param>
        /// <returns>Ruta absoluta de la carpeta y/o archivo</returns>
        public static string ObtenerRutaAbsolutaRelativaAplicacion(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename");
            }

            return FolderHelper.ObtenerRutaAbsoluta(".", filename);
        }

        /// <summary>
        /// BorrarArchivo
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        public static void BorrarArchivo(string fileLocation)
        {
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }
        }

        /// <summary>
        /// Validars the ruta archivo.
        /// </summary>
        /// <param name="rutaArchivo">The ruta archivo.</param>
        /// <returns></returns>
        public static bool ValidarRutaArchivo(string rutaArchivo)
        {
            Uri uri = new Uri(rutaArchivo);

            return uri.IsWellFormedOriginalString();
        }

        /// <summary>
        /// ObtenerContenido
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        public static string ObtenerContenido(string fileLocation)
        {
            return File.Exists(fileLocation) ? File.ReadAllText(fileLocation, Encoding.UTF8) : string.Empty;
        }
    }
}
