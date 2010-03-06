using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableCamCommunicator
{
    [Serializable]
    public struct TouchInfo
    {
        public int X;
        public int Y;
        public bool Exists;
        public string UID;
        public int timeIn;
        public int timeOut;
        public int orientation;
        public int handPlacement;
    }
}
