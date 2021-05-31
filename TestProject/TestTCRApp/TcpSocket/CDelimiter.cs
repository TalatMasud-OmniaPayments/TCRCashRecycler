using DotNetty.Buffers;

namespace TCRServiceTestClient.TcpSocket
{
    public class CDelimiter
    {
        public static IByteBuffer[] ETXDelimiter() => new[] { Unpooled.WrappedBuffer(new byte[] { 0x03 }) };
    }
}
