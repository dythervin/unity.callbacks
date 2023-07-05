namespace Dythervin.Callbacks
{
    public interface ITriggerStayCallback : IGameObjectGetter
    {
        public event TriggerStayHandler OnStay;
        public void DestroyIfEmpty();
    }
}