using CDK.Data;

namespace CDK.Integration
{
    public class DBHelper
    {
        #region Instancias Privadas

        private static DBHelperBase _instanceBusiness;
        private static DBHelperBase _instanceCampanias;
        private static DBHelperBase _instanceReportes;
        private static DBHelperBase _instanceReportesCRF;
        private static DBHelperBase _instanceEngine;
        private static DBHelperBase _instanceMotorHerramientas;

        #endregion

        #region Instancias Singleton

        public static DBHelperBase InstanceCRM
        {
            get { return (_instanceBusiness = _instanceBusiness ?? new DBHelperBase("CN_CRM")); }
        }


        public static DBHelperBase InstanceSecurity
        {
            get { return (_instanceBusiness = _instanceBusiness ?? new DBHelperBase("CN_CRM")); }
        }

        public static DBHelperBase InstanceReportes
        {
            get { return (_instanceReportes = _instanceReportes ?? new DBHelperBase("CN_Reportes")); }
        }


        public static DBHelperBase InstanceReportesCRF
        {
            get { return (_instanceReportesCRF = _instanceReportesCRF ?? new DBHelperBase("CN_ReportesCRF")); }
        }


        public static DBHelperBase InstanceEngine
        {
            get { return (_instanceEngine = _instanceEngine ?? new DBHelperBase("CN_ENGINE")); }
        }

        public static DBHelperBase InstanceMotorEmail
        {
            get { return (_instanceMotorHerramientas = _instanceMotorHerramientas ?? new DBHelperBase("CN_MotorHerra")); }
        }
        #endregion
    }
}
