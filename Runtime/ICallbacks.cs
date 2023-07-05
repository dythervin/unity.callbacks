using System;

namespace Dythervin.Callbacks
{
    public interface ICallbacks : IGameObjectGetter
    {
        public event Action<ICallbacks> OnDisabled;
        public event Action<ICallbacks, bool> OnActiveChanged;
        public event Action<ICallbacks> OnEnabled;
        public event Action<ICallbacks> OnDestroyed;
    }
}