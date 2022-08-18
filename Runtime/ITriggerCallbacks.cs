namespace Dythervin.Callbacks
{
    public interface ITriggerCallbacks : IGameObjectGetter
    {
        public event TriggerHandler OnEnter;
        public event TriggerHandler OnExit;
    }
}