using UnityEngine;

namespace Dythervin.Callbacks
{
    public interface IGameObjectGetter
    {
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }
    }
}