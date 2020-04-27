using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanucFocasTutorial
{
    class Program
    {
        static ushort _handle = 0;  // Handle to communicate with Fanuc
        static short _ret = 0;  // Stores our return value

        static void Main(string[] args)
        {
            string ipaddr = "";

            // If we specified an ip address, get it from the args
            if (args.Length > 0)
                ipaddr = args[0];

            // If we didn't provide an IP address, use HSSB, otherwise use Ethernet
            if (string.IsNullOrEmpty(ipaddr))
            {
                _ret = Focas1.cnc_allclibhndl(out _handle);
            }
            else
            {
                _ret = Focas1.cnc_allclibhndl3(ipaddr, 8193, 6, out _handle);
            }

            // Write the result to the console
            if (_ret == Focas1.EW_OK)
            {
                Console.WriteLine("We are connected!");
            }
            else
            {
                Console.WriteLine("There was an error connecting. Return value: " + _ret);
            }

            // Free the Focas handle
            Focas1.cnc_freelibhndl(_handle);
        }
    }
}
