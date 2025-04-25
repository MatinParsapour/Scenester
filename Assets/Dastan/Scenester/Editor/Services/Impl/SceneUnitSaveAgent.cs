using Dastan.Scenester.Editor.Entity.Base;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public abstract class SceneUnitSaveAgent<T> : ISceneUnitySaveAgent<T> where T : SceneUnit
    {

        protected const string ScenariosPath = "Assets/Dastan/Scenester/Resources/Scenarios";
        public abstract bool Save(T unit);
    
    }
}