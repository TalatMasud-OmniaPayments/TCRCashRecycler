using DotNetty.Transport.Channels;
using NLog;
using System;
using System.Timers;

namespace TCRServiceTestClient.TcpSocket
{
    public class SocketClientHandler : SimpleChannelInboundHandler<string>
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private SocketClient socketClient;


        public SocketClientHandler(SocketClient socketClient)
        {
            this.socketClient = socketClient;
        }

        protected override void ChannelRead0(IChannelHandlerContext context, string msg)
        {
            string message = msg.ToString();
            
            if (message == null)
            {
                return;
            }
            
            
            log.Debug("Received Message: {0}", message);

            socketClient.ResponseMessage(message);

            context.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext contex, Exception e)
        {
            log.Error("Error Caught at {0}", DateTime.Now.Millisecond);
            log.Error("Error at {0}", e.StackTrace);
            contex.CloseAsync();
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            log.Info("Connection Inactive!");
            
            socketClient = null;
            
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            log.Info("Connection Active!");
            
         
        }

    }
}
        