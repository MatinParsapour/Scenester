using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;

namespace Dastan.Scenester.Editor.Services
{
    public interface IDialogueRenderer : IService
    {

        void RenderDialogue(ScenarioUI scenarioUI, DialogueUI dialogueUI);

    }
}