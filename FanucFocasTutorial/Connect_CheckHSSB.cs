using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FanucFocasTutorial
{
    class Connect_CheckHSSB
    {
        private static ushort _handle = 0;
        private static short _ret = 0;

        public static void Connect(string[] args)
        {
            // If we didn't provide an IP address, use HSSB, otherwise use Ethernet
            if (CNCHardware.HasHSSB())
            {
                _ret = Focas1.cnc_allclibhndl(out _handle);
            }
            else
            {
                string ipaddr = "";

                // If we specified an ip address, get it from the args
                if (args.Length > 0)
                    ipaddr = args[0];

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
