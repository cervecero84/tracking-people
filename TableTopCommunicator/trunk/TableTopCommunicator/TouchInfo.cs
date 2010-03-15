﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableTopCommunicator
{
    [Serializable]
    public class TouchInfo
    {
        enum State { Uninitialized, Received, Resolved };

        // Screen coordinates
        private int _X;
        private int _Y;
        // Color or unique-id representing person
        private Colors color;
        // Orientation of the hand that made the touch: angle in degrees relative to 0,0:1024,0 baseline
        private double orientation;
        // Current state
        private State state = State.Uninitialized;

        public TouchInfo(int x, int y)
        {
            _X = x;
            _Y = y;
            state = State.Received;
        }

        public int X { get { return _X; } }
        public int Y { get { return _Y; } }
        public Colors Color { get { return color; } }
        public double Orientation { get { return orientation; } }

        // Has it been resolved?
        public bool isResolved()
        {
            return (state == State.Resolved);
        }

        // Is it ready to be processed?
        public bool canResolve()
        {
            return (state == State.Received);
        }

        public void setInfo(Colors colr, int orientatin)
        {
            color = colr;
            orientation = orientatin;
            state = State.Resolved;
        }
    }
}
