using Dythervin.Callbacks.Inner;
using UnityEngine;

namespace Dythervin.Callbacks
{
    public static class CallbacksHelper
    {
        public static ICallbacks GetCallbacks(this Component component)
        {
            return GetCallbacks(component.gameObject);
        }

        public static ICallbacks GetCallbacks(this GameObject gameObject)
        {
            return GetCallbacks<ICallbacks, Inner.Callbacks>(gameObject);
        }

        public static ITriggerCallbacks GetTriggerCallbacks(this Component component)
        {
            return GetTriggerCallbacks(component.gameObject);
        }

        public static ITriggerCallbacks GetTriggerCallbacks(this GameObject gameObject)
        {
            return GetCallbacks<ITriggerCallbacks, TriggerCallbacks>(gameObject);
        }

        public static ITriggerStayCallback GetTriggerStayCallback(this Component component)
        {
            return GetTriggerStayCallback(component.gameObject);
        }

        public static ITriggerStayCallback GetTriggerStayCallback(this GameObject gameObject)
        {
            return GetCallbacks<ITriggerStayCallback, TriggerStayCallback>(gameObject);
        }

        private static TInterface GetCallbacks<TInterface, TComponent>(GameObject gameObject)
            where TComponent : Component, TInterface
        {
            return gameObject.TryGetComponent(out TInterface disableListener) ? disableListener : gameObject.AddComponent<TComponent>();
        }
    }
}