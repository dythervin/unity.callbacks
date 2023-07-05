﻿using UnityEngine;

namespace Dythervin.Callbacks.Inner
{
    [AddComponentMenu("")]
    internal class TriggerCallbacks : CallbacksBase, ITriggerCallbacks
    {
        public event TriggerHandler OnEnter;
        public event TriggerHandler OnExit;

        private void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke(this, other);
        }
    }
}