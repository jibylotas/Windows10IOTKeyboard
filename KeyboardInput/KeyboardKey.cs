using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIT.Windows10.IOT.Input.KeyboardInput
{
    public class KeyboardKey
    {
        public string GetKeyStroke(bool isShiftPressed)
        {
            if (isShiftPressed)
                return ShiftValue;
            else
                return DefaultValue;
        }
        internal bool IsShiftKey { get; set; }
        internal bool IsCapsKey { get; set; }
        public string DefaultValue { get; set; }
        public string ShiftValue{ get; set; }
        public string Display { get; set; }
        public double Width { get; set; }
        public bool IsBackspace { get; set; }
        public KeyboardKey()
        {
            IsBackspace = false;
            IsShiftKey = false;
            IsCapsKey = false;
            Width = 75;
        }
    }
}
