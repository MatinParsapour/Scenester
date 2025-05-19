// using Dastan.Scenester.Editor.Entity.Base;

using Dastan.Scenester.Editor.Entity.Base;
using UnityEngine;

namespace Dastan.Scenester.API
{
    public class ScenesterAgent
    {
        public static void Cue(Scenario scenario)
        {
            scenario.Play();
        }
    }
}