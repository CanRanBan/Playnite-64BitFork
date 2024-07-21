using System.Threading;
using System.Threading.Tasks;

namespace Playnite
{
    public static class GlobalTaskHandler
    {
        private static CancellationTokenSource cancelToken = new CancellationTokenSource();
        public static CancellationTokenSource CancelToken
        {
            get => cancelToken;
            set
            {
                cancelToken?.Dispose();
                cancelToken = value;
            }
        }

        public static Task ProgressTask;

        public static bool IsActive
        {
            get => ProgressTask?.Status == TaskStatus.Running || ProgressTask?.Status == TaskStatus.WaitingForActivation;
        }

        public static void CancelAndWait()
        {
            if (IsActive)
            {
                CancelToken?.Cancel();
                ProgressTask?.Wait();
            }
        }

        public static bool? CancelAndWait(int millisecondsTimeout)
        {
            if (IsActive)
            {
                CancelToken?.Cancel();
                return ProgressTask?.Wait(millisecondsTimeout);
            }

            return null;
        }

        public static async Task CancelAndWaitAsync()
        {
            if (IsActive)
            {
                CancelToken?.Cancel();
                await ProgressTask;
            }
        }
    }
}
