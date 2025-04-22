using Dastan.Scenester.Entity.Base;

namespace Dastan.Scenester.Editor.Services
{
    public interface ISaveAgentService<in T> : IService where T: SceneUnit
    {
        bool Save(T unit);
    }
}