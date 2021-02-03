using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Helpers
{
    public class Base64
    {
        public static String b64decode(String data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }
        public static String b64encode(String data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }
    }
}
