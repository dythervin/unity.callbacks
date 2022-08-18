using System;
using UnityEngine;

namespace Dythervin.Callbacks.Inner
{
    [AddComponentMenu("")]
    internal sealed class Callbacks : CallbacksBase, ICallbacks
    {
        public event Action<ICallbacks> OnDisabled;
        public event Action<ICallbacks> OnEnabled;
        public event Action<ICallbacks> OnDestroyed;

        private void OnEnable()
        {
            OnEnabled?.Invoke(this);
        }

        private void OnDisable()
        {
            OnDisabled?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}