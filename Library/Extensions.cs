using System.Text;

namespace Library
{
    public class Extensions
    {
        public static string RemoveSpecialCharacters(ref string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    sb.Append(c);

            return sb.ToString();
        }
    }
}
