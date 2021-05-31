using Geidea.TCR.Service.Configuration;
using System;
using TCRServiceTestClient.Models;

namespace TCRServiceTestClient.Framework
{
    public sealed class TCRFactory
    {
        
        private static readonly Lazy<TCRFactory> lazy = new Lazy<TCRFactory>(() => new TCRFactory());
        private Tcr tcr1;
        private Tcr tcr2;

        private TCRFactory() {}

        public static TCRFactory Instance { get { return lazy.Value; } }

        public Tcr getTcr1
        {
            get
            {
                if (tcr1 == null)
                {
                    var config = AppConfiguration.Instance;
                    tcr1 = new Tcr();
                    tcr1.TcrId = AppConfiguration.TcrId;
                    tcr1.Ip = AppConfiguration.Tcr_Ip;
                    tcr1.Port = AppConfiguration.Tcr_Port;
                    tcr1.UseSSL = AppConfiguration.Tcr_UseSSL;
                    tcr1.ReconnectValue = AppConfiguration.ReconnectInterval;
                    tcr1.Certificate = AppConfiguration.Certificate;
                }

                return tcr1;
            }
        }

      
    }
}
