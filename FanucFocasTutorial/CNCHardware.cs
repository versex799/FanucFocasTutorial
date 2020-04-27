using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FanucFocasTutorial
{
    public class CNCHardware
    {
        public static bool HasHSSB()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPSignedDriver");

            foreach (var obj in searcher.Get())
            {
                string device = obj.GetPropertyValue("DeviceName")?.ToString() ?? "";

                if (device.Contains("HSSB"))
                    return true;
            }

            return false;
        }
    }
}
