using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GroupLab.Networking;

namespace TableTopCommunicator
{
    // NOTE: Communicator is not thread-safe
    // Multiple threads simultaneously setting points using the communicator can severely mess things up
    // The problem comes from the fact that the dictionary will be overwritten each time
    public class Communicator
    {
        SharedDictionary _dictionary = new SharedDictionary();
        Subscription _subscriber = new Subscription();
        String _key = "/pointOne";
        TouchInfo _lastPoint = new TouchInfo(Int32.MinValue, Int32.MinValue);

        public delegate void TouchReceivedHandler(object sender, TouchEventArgs e);
        public event TouchReceivedHandler TouchReceived;

        //public delegate void TouchResolvedHandler(object sender, TouchEventArgs e);
        //public event TouchResolvedHandler TouchResolved;

        private ManualResetEvent resetEvent = new ManualResetEvent(false);

        public Communicator()
        {
            // shared dictionary's url
            _dictionary.Url = "tcp://localhost:shareD";
            // connect the shared dictionary to some default server, it will spawn a server or client
            _dictionary.Open();
            // set the subscriber to listen to the dictionary
            _subscriber.Dictionary = _dictionary;
            // signal beginning of initialization for subscriber
            _subscriber.BeginInit();
            // register the pattern with the shared dictionary server
            _subscriber.Pattern = _key;
            // register the event handler
            _subscriber.Notified += new SubscriptionEventHandler(subscriber_Notified);
            // signal the end of initialization
            _subscriber.EndInit();
        }

        // Should only be called by the program asking for resolution, not the resolved
        // Resolving program should call "UpdateTouchInfo" instead
        public void EvalPoint(TouchInfo value)
        {
            // If the last point was the default or it was resolved
            if (_lastPoint.X == Int32.MinValue || _lastPoint.isResolved())
            {
                // Unset the wait
                resetEvent.Reset();
                
                // Set current point as last point
                _lastPoint = value;
                
                // CHECK: I hope this triggers the notifier in the other thread as well!
                Action updateDictionary = new Action(delegate() { _dictionary[_key] = value; });
                updateDictionary.BeginInvoke(null, null);
                // In the other thread, the notitifier sets the resent event to set

                // Wait till this gets set - gets set, when resolved
                resetEvent.WaitOne(5000);
            }
            else
            {
                throw new Exception("Last point not resolved yet. Must be resolved, before processing next point");
            }
        }

        // Returns the current point being held by the communicator for processing
        public TouchInfo GetPoint()
        {
            return (TouchInfo)_dictionary[_key];
        }

        private void subscriber_Notified(object sender, SubscriptionEventArgs e)
        {
            // The change in the dictionary was one of the relevant keys
            if (e.Path == _key)
            {
                TouchInfo t = ((TouchInfo)_dictionary[_key]);
                // If the touch received is ready to be resolved (i.e. has not already been resolved yet)
                if (t.canResolve())
                {
                    // If an event handler is registered...
                    if (this.TouchReceived != null)
                    {
                        // ...fire it
                        this.TouchReceived(this, new TouchEventArgs(t));
                    }
                }
                else if (t.isResolved())
                {
                    //if (this.TouchResolved != null)
                    //{
                        resetEvent.Set();
                        //this.TouchResolved(this, new TouchEventArgs(t));
                    //}
                }
            }
        }

        public void UpdateTouchInfo(TouchInfo t)
        {
            _dictionary[_key] = t;
        }
    }
}
