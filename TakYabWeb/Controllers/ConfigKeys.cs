using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TakYab.Controllers
{
    public class ConfigKeys
    {
        public const string DEFAULT_CONNECTION_STRING = "DefaultConnectionString";
        public const string ADMIN_USER_ROLE = "administratorUserRole";
        public const string USER_USER_ROLE = "userUserRole";
        public const string IMAGES_FOLDER_NAME = "ImagesFolderName";

  
        public static string GetConfigValues(string configKey)
        {
            if (WebConfigurationManager.AppSettings[configKey] != null)
                return WebConfigurationManager.AppSettings[configKey];

            return String.Empty;
        }


        public static string GetConnectionString(string configKey)
        {
            if (WebConfigurationManager.ConnectionStrings[configKey] != null)
                return WebConfigurationManager.ConnectionStrings[configKey].ConnectionString;

            return String.Empty;
        }


        

    }
}