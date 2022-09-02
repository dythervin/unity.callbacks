using System;

namespace Dythervin.Callbacks
{
    public interface IParticleCallbacks : IGameObjectGetter
    {
        public event Action<IParticleCallbacks> OnParticleSystemStop;
    }
}