using System.Configuration;

namespace Diba.Desktop.Internal
{
    public class DibaServiceConfiguration
    {
        private const string ENDPOINT = "DibaEndPoint";
        private string endpoint { get; set; } = null;

        private static DibaServiceConfiguration instance; 
        public static DibaServiceConfiguration Instance
        {
            get
            {
                if (instance == null)
                    instance = new DibaServiceConfiguration();

                return instance;
            }            
        }

        public string EndPoint
        {
            get
            {
                if (endpoint == null)
                    endpoint = ConfigurationManager.AppSettings[ENDPOINT].ToString();
                return endpoint;
            }
        }
    }
}
