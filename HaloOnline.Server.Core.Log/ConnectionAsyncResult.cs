using System;
using System.Threading;

namespace HaloOnline.Server.Core.Log
{
    public class ConnectionAsyncResult : IAsyncResult
    {
        private readonly AsyncCallback _callback;
        private readonly IConnection _connection;
        private readonly object _lock = new object();
        private bool _isCompleted;
        private ManualResetEvent _manualResetEvent;

        public ConnectionAsyncResult(IConnection connection, AsyncCallback callback)
        {
            _connection = connection;
            _callback = callback;
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                lock (_lock)
                {
                    _isCompleted = value;
                    var manualResetEvent = GetManualResetEvent();
                    if (_isCompleted)
                    {
                        manualResetEvent.Set();
                    }
                    else
                    {
                        manualResetEvent.Reset();
                    }
                }
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                lock (_lock)
                {
                    var manualResetEvent = GetManualResetEvent();
                    if (IsCompleted)
                        manualResetEvent.Set();
                    return manualResetEvent;
                }
            }
        }

        public object AsyncState
        {
            get { return _connection; }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        private ManualResetEvent GetManualResetEvent()
        {
            lock (_lock)
            {
                return _manualResetEvent ?? (_manualResetEvent = new ManualResetEvent(false));
            }
        }

        public void InvokeCallback()
        {
            _callback(this);
        }
    }
}
