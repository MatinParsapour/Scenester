using Dastan.Scenester.Entity.Base;

namespace Dastan.Scenester.Editor.Services
{
    public interface ISceneUnitySaveAgent<in T> : ISaveAgentService<T> where T : SceneUnit
    {
        
    }
}