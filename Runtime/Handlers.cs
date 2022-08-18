using UnityEngine;

namespace Dythervin.Callbacks
{
    public delegate void TriggerHandler(ITriggerCallbacks callbacks, Collider collider);
    public delegate void TriggerStayHandler(ITriggerStayCallback callbacks, Collider collider);
}