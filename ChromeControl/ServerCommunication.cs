using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace ChromeControl
{
    public class ServerCommunication
    {
        private readonly Stream _stream;
        private readonly UnicodeEncoding _streamEncoding;

        public ServerCommunication(Stream stream)
        {
            _stream = stream;
            _streamEncoding = new UnicodeEncoding();
        }

        public string ReadMessage()
        {
            var length = _stream.ReadByte() * 256;
            length += _stream.ReadByte();
            var buffer = new byte[length];
            _stream.Read(buffer, 0, length);

            return _streamEncoding.GetString(buffer);
        }

        public JObject ReadMessageAsJObject()
        {
            var length = _stream.ReadByte() * 256;
            length += _stream.ReadByte();
            var buffer = new byte[length];
            _stream.Read(buffer, 0, length);

            var msg = _streamEncoding.GetString(buffer);

            return JObject.Parse(msg);
        }

        public int SendMessage(string outString)
        {
            var buffer = _streamEncoding.GetBytes(outString);
            var length = buffer.Length;
            if (length > ushort.MaxValue)
            {
                length = ushort.MaxValue;
            }
            _stream.WriteByte((byte)(length / 256));
            _stream.WriteByte((byte)(length & 255));
            _stream.Write(buffer, 0, length);
            _stream.Flush();

            return buffer.Length + 2;
        }
    }
}
