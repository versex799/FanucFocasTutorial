//using Microsoft.Win32;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace FanucFocasTutorial
//{
//    class Connect_CheckHSSB
//    {
//        private static ushort _handle = 0;
//        private static short _ret = 0;

//        public static void Connect(string[] args)
//        {
//            // If we didn't provide an IP address, use HSSB, otherwise use Ethernet
//            if (CNCHardware.HasHSSB())
//            {
//                _ret = Focas1.cnc_allclibhndl(out _handle);
//            }
//            else
//            {
//                string ipaddr = "";

//                // If we specified an ip address, get it from the args
//                if (args.Length > 0)
//                    ipaddr = args[0];

//                _ret = Focas1.cnc_allclibhndl3(ipaddr, 8193, 6, out _handle);
//            }

//            // Write the result to the console
//            if (_ret == Focas1.EW_OK)
//            {
//                Console.WriteLine("We are connected!");
//            }
//            else
//            {
//                Console.WriteLine("There was an error connecting. Return value: " + _ret);
//            }

//            // Free the Focas handle
//            Focas1.cnc_freelibhndl(_handle);
//        }
//    }

//    private const string baseReg =
//    @"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002bE10318}\";

//    public static bool SetMAC(string nicid, string newmac)
//    {
//        bool ret = false;
//        using (RegistryKey bkey = GetBaseKey())
//        using (RegistryKey key = bkey.OpenSubKey(baseReg + nicid))
//        {
//            if (key != null)
//            {
//                key.SetValue("NetworkAddress", newmac, RegistryValueKind.String);

//                ManagementObjectSearcher mos = new ManagementObjectSearcher(
//                    new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Index = " + nicid));

//                foreach (ManagementObject o in mos.Get().OfType<ManagementObject>())
//                {
//                    o.InvokeMethod("Disable", null);
//                    o.InvokeMethod("Enable", null);
//                    ret = true;
//                }
//            }
//        }

//        return ret;
//    }

//    public static IEnumerable<string> GetNicIds()
//    {
//        using (RegistryKey bkey = GetBaseKey())
//        using (RegistryKey key = bkey.OpenSubKey(baseReg))
//        {
//            if (key != null)
//            {
//                foreach (string name in key.GetSubKeyNames().Where(n => n != "Properties"))
//                {
//                    using (RegistryKey sub = key.OpenSubKey(name))
//                    {
//                        if (sub != null)
//                        {
//                            object busType = sub.GetValue("BusType");
//                            string busStr = busType != null ? busType.ToString() : string.Empty;
//                            if (busStr != string.Empty)
//                            {
//                                yield return name;
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }

//    public static RegistryKey GetBaseKey()
//    {
//        return RegistryKey.OpenBaseKey(
//            RegistryHive.LocalMachine,
//            InternalCheckIsWow64() ? RegistryView.Registry64 : RegistryView.Registry32);
//    }
//}


