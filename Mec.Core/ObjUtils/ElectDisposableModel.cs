using System;

namespace Mec.Core.ObjUtils
{
    /// <inheritdoc />
    public abstract class MecDisposableModel : IDisposable
    {
        private bool IsDisposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                DisposeUnmanagedResources();
            }
            
            IsDisposed = true;
        }
        
        
        protected virtual void DisposeUnmanagedResources() { }

        ~MecDisposableModel()
        {
            Dispose(false);
        }
    }
}