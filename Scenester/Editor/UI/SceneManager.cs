using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;

namespace Dastan.Scenester.Editor.UI
{
    public class SceneManager
    {
        public static void AddScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance(null).Add(scenarioButtonContainer);
        }

        public static void DeleteScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance(null).Remove(scenarioButtonContainer);
        }

        public static int SizeScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            return TabBar.GetInstance(scenarioButtonContainer).childCount;
        }
    }
}