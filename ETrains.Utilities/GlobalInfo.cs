﻿using System;

namespace ETrains.Utilities
{
    public static class GlobalInfo
    {
        public static bool IsDebug 
        {
            get { return Convert.ToBoolean(Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["IsDebugMode"].ToString())); }
        }

        private static string _companyName = "";
        public static string CompanyName
        {

            get
            {
                return _companyName;
            }

            set
            {
                _companyName = value;
            }
        }
    }
}
