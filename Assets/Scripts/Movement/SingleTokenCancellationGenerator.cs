#nullable enable

using System;
using System.Threading;

namespace SteeringBehaviors.Movement
{
    public sealed class SingleTokenCancellationGenerator : IDisposable
    {
        private CancellationTokenSource? _cancellationTokenSource;

        public CancellationToken New()
        {
            Cancel();

            return (_cancellationTokenSource = new CancellationTokenSource()).Token;
        }

        public void Cancel() => _cancellationTokenSource?.Cancel(); 

        public void Dispose() => _cancellationTokenSource?.Dispose();
    }
}
