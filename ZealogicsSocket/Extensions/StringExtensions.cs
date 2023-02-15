using System.Text;

namespace ZealogicsSocket.Extensions
{
    public static class StringExtensions
    {
        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
