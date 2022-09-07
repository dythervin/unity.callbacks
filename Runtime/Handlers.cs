using UnityEngine;

namespace Dythervin.Callbacks
{
    public delegate void TriggerHandler(ITriggerCallbacks callbacks, Collider other);
    public delegate void TriggerStayHandler(ITriggerStayCallback callbacks, Collider other);
}