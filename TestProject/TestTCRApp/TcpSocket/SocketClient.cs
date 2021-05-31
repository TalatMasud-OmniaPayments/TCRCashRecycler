using DotNetty.Codecs;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TCRServiceTestClient.Models;

namespace TCRServiceTestClient.TcpSocket
{
    public sealed class SocketClient : ISocketClient
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static ReturnMessage DelegateReturnMessage = null;
        private MultithreadEventLoopGroup group = new MultithreadEventLoopGroup();
        private ConcurrentDictionary<String, IChannel> channelDictionary = new ConcurrentDictionary<string, IChannel>();
        private static char TERMINATOR = Convert.ToChar(0x03);
        private static SocketClient Instance;

        public static SocketClient GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SocketClient();
            }

            return Instance;
        }
        

        public async Task<bool> Connect(Tcr tcr)
        {
            log.Info("Initializing Socket Client");


            X509Certificate2 cert = null;
            string targetHost = null;
            if (tcr.UseSSL)
            {
                X509Store computerCaStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                computerCaStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certificatesInStore = computerCaStore.Certificates;
                X509Certificate2Collection certs = certificatesInStore.Find(X509FindType.FindBySubjectName, tcr.Certificate, false);
                if (certs.Count > 0)
                {
                    cert = certs[0];
                    log.Debug("Will use Certificate: {0}", cert.Subject);
                }
                targetHost = cert.GetNameInfo(X509NameType.DnsName, false);

                log.Debug("Host Name: {0} ", targetHost);
            }
            
            var bootstrap = new Bootstrap();
            bootstrap
                .Group(group)
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.AutoRead, true)
                .Option(ChannelOption.TcpNodelay, true)
                .Option(ChannelOption.SoKeepalive, true)
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;

                    if (cert != null)
                    {
                        pipeline.AddLast(new TlsHandler(stream => new SslStream(stream, true, (sender, certificate, chain, errors) => true), new ClientTlsSettings(targetHost)));
                    }

                    pipeline.AddLast(new DelimiterBasedFrameDecoder(10240, CDelimiter.ETXDelimiter()));
                    pipeline.AddLast(new StringEncoder());
                    pipeline.AddLast(new StringDecoder());
                    pipeline.AddLast(new SocketClientHandler(this));
                }));

            log.Info("Connecting to IP={0} and Port={1}", tcr.Ip, tcr.Port);
            var bootstrapChannel = await bootstrap.ConnectAsync (new IPEndPoint(IPAddress.Parse(tcr.Ip), tcr.Port));
            channelDictionary.TryAdd(tcr.TcrId, bootstrapChannel);
            log.Info("Connect Active? {0}", bootstrapChannel.Active);
            return bootstrapChannel.Active;
        }


        public void Disconnect(Tcr tcr)
        {
            //Send(tcr, mi.ComposeDisconnectMessage());
            Terminate(tcr);
        }

        public void Terminate(Tcr tcr)
        {
            var channel = GetChannel(tcr);
            if (channel != null)
                channel.CloseAsync().Wait(2000);
            
            
            log.Debug("Disconnected from Channel Management Server");
        }
        

        public bool IsConnected(Tcr tcr)
        {
            var channel = GetChannel(tcr);
            if (channel != null)
                return channel.Active;
            else
                return false;

        }

        public void Send(Tcr tcr, string message)
        {
            log.Trace("Send Message triggered");
            try
            {
                log.Trace("Sending Message: {0}", message);
                var channel = GetChannel(tcr);
                channel.WriteAndFlushAsync(message + TERMINATOR);
            }
            catch (Exception ex)
            {
                log.Error("Error: {0}", ex.Message);
                log.Debug(ex.StackTrace);
            }
        }

        public void ResponseMessage(string message)
        {
            log.Debug("Received Message: {0}", message);

            if (DelegateReturnMessage != null)
                DelegateReturnMessage.Invoke(message);
        }
        
        private IChannel GetChannel(Tcr tcr)
        {
            IChannel channel = null;
            channelDictionary.TryGetValue(tcr.TcrId, out channel);
            return channel;
        }
    }

}
