using UnityEngine;

namespace Dythervin.Callbacks.Inner
{
    internal abstract class CallbacksBase : MonoBehaviour
    {
        protected virtual void Reset()
        {
            hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInInspector;
        }
    }
}