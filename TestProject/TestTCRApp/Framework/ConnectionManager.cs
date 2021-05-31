using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCRServiceTestClient.FrameworkInterface;
using TCRServiceTestClient.Models;

namespace TCRServiceTestClient.Framework
{
    public sealed class ConnectionManager : IConnectionManager
    {
        Logger log = LogManager.GetCurrentClassLogger();
        
        private static ConnectionManager INSTANCE = null;
        private static readonly object padlock = new object();

        private ConcurrentDictionary<String, IConnectionClient> dict = null;

        private ConnectionManager()
        {
            dict = new ConcurrentDictionary<String, IConnectionClient>();
        }

        public static IConnectionManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new ConnectionManager();
                    }
                    return INSTANCE;
                }
            }
        }

        public IConnectionClient GetConnectionClient(Tcr tcr)
        {
            IConnectionClient clientInstance;
            log.Debug("Retrieving TCR Connection Client: {0} ", tcr.TcrId);
            dict.TryGetValue(tcr.TcrId, out clientInstance);
            log.Debug("Returning TCR Connection Client: {0}. Found? {1}", tcr.TcrId, (clientInstance == null ? "No" : "Yes"));

            return clientInstance;
        }

        public IConnectionClient Register(Tcr tcr)
        {
            IConnectionClient clientInstance;
            
            if (dict.TryGetValue(tcr.TcrId, out clientInstance))
            {
                log.Debug("TCR Connection Client {0} already registered.", tcr.TcrId);
            }
            else
            {
                log.Debug("Registering TCR Connection Client: {0}", tcr.TcrId);
                clientInstance = new ConnectionClient(tcr);
                dict.TryAdd(tcr.TcrId, clientInstance);
            }

            return clientInstance;
        }

        public IConnectionClient Unregister(Tcr tcr)
        {
            IConnectionClient clientInstance;
            dict.TryRemove(tcr.TcrId, out clientInstance);

            return clientInstance;
        }
    }
}
