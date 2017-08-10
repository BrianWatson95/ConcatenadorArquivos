using System;
using System.Configuration;

namespace Concatenador.Util
{
    class Settings
    {
        private string caminhoBase;
        public static string CaminhoBase
        {
            get
            {
                string caminhoBase = "";
                string caminhoBaseAux = ConfigurationManager.AppSettings["caminhoBase"];

                if (!String.IsNullOrEmpty(caminhoBaseAux))
                    caminhoBase = caminhoBaseAux;

                return caminhoBase;
            }
        }

        private string empresaUm;
        public static string EmpresaUm
        {
            get
            {
                string empresaUm = "";
                string empresaUmAux = ConfigurationManager.AppSettings["empresaUm"];

                if (!String.IsNullOrEmpty(empresaUmAux))
                    empresaUm = empresaUmAux;

                return empresaUm;
            }
        }

        private string empresaDois;
        public static string EmpresaDois
        {
            get
            {
                string empresaDois = "";
                string empresaDoisAux = ConfigurationManager.AppSettings["empresaDois"];

                if (!String.IsNullOrEmpty(empresaDoisAux))
                    empresaDois = empresaDoisAux;

                return empresaDois;
            }
        }

    }
}
