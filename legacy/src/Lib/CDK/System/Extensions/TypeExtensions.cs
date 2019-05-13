namespace CDK.System.Extensions
{
    /// <summary>
    /// TypeExtensions
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Obteners the valor propiedad.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static object ObtenerValorPropiedad(this object obj, string name)
        {
            return TypeHelper.ObtenerValorPropiedad(obj, name);
        }

        /// <summary>
        /// Asignars the valor propiedad.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void AsignarValorPropiedad(this object obj, string name, object value)
        {
            TypeHelper.AsignarValorPropiedad(obj, name, value);
        }
    }
}
