using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestLoadingDisplayerEver
{
    public class Loader
    {
        private readonly MessageBuilder _messageBuilder = new MessageBuilder();
        private readonly int _internalTimeout;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private Task _executingTask;

        public bool IsRunning { get; private set; }

        public Loader(uint internalTimeout = 100)
        {
            _internalTimeout = (int)internalTimeout;
        }

        public void Start()
        {
            if (IsRunning) throw new InvalidOperationException("Cannot start the already running loader.");

            Initialize();

            try
            {
                IsRunning = true;
                _executingTask.Start();
            }
            catch (OperationCanceledException)
            {
                Cleanup();
            }
        }

        public void Stop()
        {
            if (!IsRunning) throw new InvalidOperationException("Cannot stop the loader that is not running.");

            _cancellationTokenSource.Cancel();
            IsRunning = false;
        }

        private void Initialize()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _executingTask = new Task(Execute);
        }

        private void Execute()
        {
            while (true)
            {
                Thread.Sleep(_internalTimeout);

                if (_cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                Console.Write(_messageBuilder.CreateMessage());
            }
        }        

        private void Cleanup()
        {
            _executingTask.Wait();
            _executingTask.Dispose();
        }
    }
}
