using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanucFocasTutorial
{
    public class Fanuc
    {
        static ushort _handle = 0;  // Handle to communicate with Fanuc
        static short _ret = 0;  // Stores our return value


        private double _scale = 10000;

        public string GetMode()
        {
            // Check we have a valid handle
            if (_handle == 0)
                return "UNAVAILABLE";

            // Creat an instance of our stucture
            Focas1.ODBST mode = new Focas1.ODBST();

            // Ask Fanuc for the status information
            _ret = Focas1.cnc_statinfo(_handle, mode);

            // Check to make sure the call was successfull
            // and convert the mode to a string and return it.
            if (_ret == Focas1.EW_OK)
                return GetModeString(mode.aut);
            return "UNAVAILABLE";
        }

        public string GetStatus()
        {
            if (_handle == 0)
                return "UNAVAILABLE";

            Focas1.ODBST status = new Focas1.ODBST();

            _ret = Focas1.cnc_statinfo(_handle, status);

            if (_ret == Focas1.EW_OK)
                return GetModeString(status.aut);
            return "UNAVAILABLE";
        }

        public double AbsolutePosition()
        {
            if (_handle == 0)
                return 0;

            Focas1.ODBAXIS _axisPositionAbsolute = new Focas1.ODBAXIS();
            _ret = Focas1.cnc_absolute2(_handle, 88, 8, _axisPositionAbsolute);

            if (_ret != Focas1.EW_OK)
                return _ret;

            return _axisPositionAbsolute.data[0] / _scale;
        }

        public double RelativePosition()
        {
            if (_handle == 0)
                return 0;

            Focas1.ODBAXIS _axisPositionRelative = new Focas1.ODBAXIS();
            _ret = Focas1.cnc_relative2(_handle, 88, 8, _axisPositionRelative);

            if (_ret != Focas1.EW_OK)
                return _ret;

            return _axisPositionRelative.data[0] / _scale;
        }

        public double MachinePosition()
        {
            if (_handle == 0)
                return 0;

            Focas1.ODBAXIS _axisPositionMachine = new Focas1.ODBAXIS();
            _ret = Focas1.cnc_machine(_handle, 88, 8, _axisPositionMachine);

            if (_ret != Focas1.EW_OK)
                return _ret;

            return _axisPositionMachine.data[0] / _scale;
        }

        // I used a switch function to demonstrate, but
        // there are better methods out there. 
        private string GetModeString(short mode)
        {
            switch (mode)
            {
                case 0:
                    {
                        return "MDI";
                    }
                case 1:
                    {
                        return "MEM";
                    }
                case 2:
                    {
                        return "****";
                    }
                case 3:
                    {
                        return "EDIT";
                    }
                case 4:
                    {
                        return "HND";
                    }
                case 5:
                    {
                        return "JOG";
                    }
                case 6:
                    {
                        return "T-JOG";
                    }
                case 7:
                    {
                        return "T-HND";
                    }
                case 8:
                    {
                        return "INC";
                    }
                case 9:
                    {
                        return "REF";
                    }
                case 10:
                    {
                        return "RMT";
                    }
                default:
                    {
                        return "UNAVAILABLE";
                    }
            }
        }
    }
}
