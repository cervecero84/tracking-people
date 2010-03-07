using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableTopCommunicator
{
    public class TouchEventArgs
    {
        private TouchInfo resolvedTouch;

        public TouchEventArgs(TouchInfo touch)
        {
            resolvedTouch = touch;
        }

        public TouchInfo Touch
        {
            get
            {
                return resolvedTouch;
            }
        }
    }
}
