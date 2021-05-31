using Microsoft.Extensions.Configuration;
using System;
using TestTCRApp;

namespace Geidea.TCR.Service.Configuration
{
    public sealed class AppConfiguration
    {

        private IConfiguration _configuration;

        //private static readonly Lazy<AppConfiguration> lazy = new Lazy<AppConfiguration>(() => new AppConfiguration());

        private const string APP_PARAMETER_SECTION = "appParameters";
        private const string COMM_SERVER_SECTION = "commServer";
        private const string DEVICE_STATUS_SECTION = "sendDeviceStatusJob";
        private const string TCR_Machine_SECTION = "TCRMachine";

        public static AppConfiguration Instance;

        
        private AppConfiguration() { }

        #region /* App Parameters */
        /*public static string Terminal
        {
            get { return Startup.StaticConfig[COMM_SERVER_SECTION+":"+"UseSSL"]; }
            set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "UseSSL"] = value; }
        }
        public string Branch
        {
            get { return GetNodeValue(APP_PARAMETER_SECTION, "BRANCH"); }
            set { SetNodeValue(APP_PARAMETER_SECTION, "BRANCH", value); }
        }

        public string Customer
        {
            get { return GetNodeValue(APP_PARAMETER_SECTION, "CUSTOMER"); }
            set { SetNodeValue(APP_PARAMETER_SECTION, "CUSTOMER", value); }
        }

        public string DateFormatFilename
        {
            get { return GetNodeValue(APP_PARAMETER_SECTION, "DATE_FORMAT_FILENAME"); }
            set { SetNodeValue(APP_PARAMETER_SECTION, "DATE_FORMAT_FILENAME", value); }
        }


        public string EJFilePath
        {
            get { return GetNodeValue(APP_PARAMETER_SECTION, "EJ_FILE_PATH"); }
            set { SetNodeValue(APP_PARAMETER_SECTION, "EJ_FILE_PATH", value); }
        }
        
        public string EJFilenameFormat
        {
            get { return GetNodeValue(APP_PARAMETER_SECTION, "EJ_FILENAME_FORMAT"); }
            set { SetNodeValue(APP_PARAMETER_SECTION, "EJ_FILENAME_FORMAT", value); }
        }*/

        #endregion

        #region /* App Parameters */
        public static string TcrId
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":"+ "TcrId"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string IP
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "IP"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static int Port
        {
            get { return int.Parse(Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Port"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static int ReconnectInterval
        {
            get { return int.Parse(Startup.StaticConfig[TCR_Machine_SECTION + ":" + "ReconnectInterval"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string Certificate
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Certificate"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string BranchNo
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "BranchNo"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string DeviceNo
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "DeviceNo"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string Tcr_Ip
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Tcr_Ip"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }

        public static string TellerId
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "TellerId"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }
        public static int Tcr_Port
        {
            get { return int.Parse(Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Tcr_Port"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }
        public static string Passowrd
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Passowrd"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }
        public static string Side
        {
            get { return Startup.StaticConfig[TCR_Machine_SECTION + ":" + "Side"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "TcrId"] = value; }
        }
        public static bool Tcr_UseSSL
        {
            get { return Boolean.Parse(Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "UseSSL"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "UseSSL"] = value.ToString(); }
        }



        #endregion
        #region // comm parameters


        /*public static string IP
        {
            get { return Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "IP"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "IP"] = value; }
        }

        public static int Port
        {
            get { return int.Parse(Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "Port"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "Port"] = value.ToString(); }
        }


        public static bool UseSSL
        {
            get { return Boolean.Parse(Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "UseSSL"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "UseSSL"] = value.ToString(); }
        }

        public static string Certificate
        {
            get { return Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "Certificate"]; }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "Certificate"] = value; }
        }

        public static int ReconnectInterval
        {
            get { return int.Parse(Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "ReconnectInterval"]); }
            //set { Startup.StaticConfig[COMM_SERVER_SECTION + ":" + "ReconnectInterval"] = value.ToString(); }
        }*/


        #endregion

        /*public string DeployNewIcons { get { return DEVICE_STATUS_SECTION; } }

        public string JobKey
        {
            get { return GetNodeValue(DEVICE_STATUS_SECTION, "JobKey"); }
            set { SetNodeValue(DEVICE_STATUS_SECTION, "JobKey", value); }
        }

        public string JobGroup
        {
            get { return GetNodeValue(DEVICE_STATUS_SECTION, "JobGroup"); }
            set { SetNodeValue(DEVICE_STATUS_SECTION, "JobGroup", value); }
        }

        public string Schedule
        {
            get { return GetNodeValue(DEVICE_STATUS_SECTION, "Schedule"); }
            set { SetNodeValue(DEVICE_STATUS_SECTION, "Schedule", value); }
        }

        public bool Recurring
        {
            get { return Boolean.Parse(GetNodeValue(DEVICE_STATUS_SECTION, "Recurring")); }
            set { SetNodeValue(DEVICE_STATUS_SECTION, "Recurring", value.ToString()); }
        }*/
    }
}
