using System.Text;

namespace AirlineDiscount.FlexRule
{
    public static class StringExtensions
    {
        public static byte[] AsBytes(this string str)
        {
            return Encoding.UTF32.GetBytes(str);
        }
    }
}