
using System;
using System.Reflection;

namespace CDK.System
{
    /// <summary>
    /// TypeHelper
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Obteners the valor propiedad.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static object ObtenerValorPropiedad(object obj, string name)
        {
            return obj == null ? null : obj.GetType().GetProperty(name).GetValue(obj, null);
        }

        /// <summary>
        /// Asignars the valor propiedad.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void AsignarValorPropiedad(object obj, string name, object value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                var v = Convert.ChangeType(value, prop.PropertyType);
                prop.SetValue(obj, v, null);
            }
        }

        /// <summary>
        /// Genera una nueva clase 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="origen">The origen.</param>
        /// <returns></returns>
        public static K ConvertirTipo<T, K>(T origen)
            where T : new()
            where K : new()
        {
            T claseOrigen = new T();
            K claseDestino = new K();

            Type typeOrigen = claseOrigen.GetType();
            Type typeDestino = claseDestino.GetType();
            PropertyInfo[] propertyInfosOrigen = typeOrigen.GetProperties();

            Action<string, object> asignacion = delegate(string nombre, object valor)
                {
                    PropertyInfo propertyInfo = typeDestino.GetProperty(nombre, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo != null && (valor != null && !string.IsNullOrEmpty(valor.ToString())))
                    {
                        Type propertyType = propertyInfo.PropertyType;
                        propertyInfo.SetValue(claseDestino, Convert.ChangeType(valor, propertyType), null);
                    }
                };

            foreach (PropertyInfo itemOrigen in propertyInfosOrigen)
            {
                object obj = itemOrigen.GetValue(origen, null);
                asignacion(itemOrigen.Name, obj);
            }

            return claseDestino;
        }
    }
}
