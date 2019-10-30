using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_DB_XML_PR
{
    static class DisplayConsole
    {
        public static void ResultOnConsole<T>(IEnumerable<T> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
