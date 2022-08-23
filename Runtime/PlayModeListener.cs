using System;
using System.Collections.Generic;
using Dythervin.Collections;
using Dythervin.Core;
using Dythervin.Core.Utils;
using Dythervin.Updater.Helpers;
using UnityEngine;

namespace Dythervin.Callbacks
{
    public static class PlayModeListener
    {
        private static readonly LockableHashSet<IPlayModeListener> GameStartListeners = new LockableHashSet<IPlayModeListener>();
        private static readonly HashSet<IPlayModeListener> GameStartListenersDone = new HashSet<IPlayModeListener>();

        private static readonly Updatable Updatable = new Updatable();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            Application.quitting += ApplicationOnQuitting;
            Updatable.enabled = true;
            Updatable.OnUpdate += Enter;

            Enter();
        }

        static PlayModeListener()
        {
            GameStartListeners.OnChangesApplied += Process;
        }

        private static void ApplicationOnQuitting()
        {
            GameStartListenersDone.Clear();
            GameStartListeners.Clear();
        }


        private static void Enter()
        {
            Process();

            Updatable.enabled = false;
        }

        private static void Process()
        {
            GameStartListeners.Lock(true);
            foreach (IPlayModeListener playModeListener in GameStartListeners)
            {
                if (playModeListener is UnityEngine.Object obj && obj == null)
                    continue;

                try
                {
                    playModeListener.OnEnterPlayMode();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Enter play mode: {e}");
                }
                finally
                {
                    GameStartListenersDone.Add(playModeListener);
                }
            }

            GameStartListeners.Lock(false);
        }

        public static void PlayModeUnsubscribe<T>(this T playModeListener)
            where T : class, IPlayModeListener
        {
            GameStartListeners.Remove(playModeListener);
        }

        public static void PlayModeSubscribe<T>(this T playModeListener)
            where T : class, IPlayModeListener
        {
            if (ApplicationExt.IsQuitting || GameStartListenersDone.Contains(playModeListener))
                return;

            if (ApplicationExt.IsPlaying)
            {
                if (!playModeListener.MainThreadOnly || ThreadExt.IsMain)
                {
                    playModeListener.OnEnterPlayMode();
                }
                else
                {
                    GameStartListeners.Add(playModeListener);
                    Updatable.enabled = true;
                }
            }
            else
            {
                GameStartListeners.Add(playModeListener);
            }
        }
    }
}