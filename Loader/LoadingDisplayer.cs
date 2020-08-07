using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BestLoadingDisplayerEver
{
    public class LoadingDisplayer
    {
        private readonly MessageBuilder _messageBuilder;
        private readonly uint _pauseInMilliseconds;

        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken ct;
        private Task executingTask;

        public LoadingDisplayer(string message, uint pauseInMilliseconds)
        {
            _messageBuilder = new MessageBuilder(message);
            _pauseInMilliseconds = pauseInMilliseconds;
        }

        public void Start()
        {
            ct = tokenSource.Token;
            executingTask = new Task(Execute);
            try
            {
                executingTask.Start();
            }
            catch (OperationCanceledException e)
            {
                Dispose();
            }
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }

        private void Execute()
        {
            while (!ct.IsCancellationRequested)
            {
                Thread.Sleep((int)_pauseInMilliseconds);
                Stream stdOut = Console.OpenStandardOutput();
                byte[] bytes = Encoding.UTF8.GetBytes(_messageBuilder.CreateMessage());
                IAsyncResult result = stdOut.BeginWrite(bytes, 0, bytes.Length, callbackResult => stdOut.EndWrite(callbackResult), null);
            }
        }        

        private void Dispose()
        {
            executingTask.Wait();
            executingTask.Dispose();
        }
    }
}
