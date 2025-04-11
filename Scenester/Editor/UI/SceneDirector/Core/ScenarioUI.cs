using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using Dastan.Scenester.Editor.UI.Inspector;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Core
{
    public class ScenarioUI : GraphView
    {

        private readonly Scenario _scenario;

        public Scenario Scenario => _scenario;

        public ScenarioUI(Scenario scenario)
        {
            _scenario = scenario;
            InitializeUI();
            OnMouseDownClick();
        }

        private void OnMouseDownClick()
        {
            RegisterCallback<MouseDownEvent>(OnMouseDown);
        }

        private void InitializeUI()
        {
            // Enable zoom and dragging
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            // this.AddManipulator(new RectangleSelector());


            // Add grid background
            GridBackground grid = new GridBackground();
            Insert(0, grid);

        }

        private void OnMouseDown(MouseDownEvent e)
        {
            if (e.button == 0)
            {
                SceneUnitInspector.GetInstance(_scenario).ChangeInspector();
            }
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            Vector2 graphMousePosition = contentViewContainer.WorldToLocal(evt.mousePosition);

            SimpleDialogue simpleDialogue = ScriptableObject.CreateInstance<SimpleDialogue>();
            simpleDialogue.Scenario = _scenario;
            simpleDialogue.key = "Simple Dialogue " + (_scenario.GetDialogues().Count + 1);
            _scenario.AddDialogue(simpleDialogue, graphMousePosition);
            evt.menu.AppendAction("Dialogues/Simple Dialogue", action => AddDialogueNode(new SimpleDialogueUI(simpleDialogue), graphMousePosition), DropdownMenuAction.AlwaysEnabled);
        }

        public void AddDialogueNode(DialogueUI dialogueUI, Vector2 position)
        {
            dialogueUI.SetPosition(new Rect(position, new Vector2(100, 100)));
            AddElement(dialogueUI);
        }
    }
}