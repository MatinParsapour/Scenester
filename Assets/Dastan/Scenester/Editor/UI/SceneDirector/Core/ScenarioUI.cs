using System.Collections.Generic;
using System.Linq;
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
        public EntryDialogueUI Entry { get; private set; }

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
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());


            GridBackground grid = new GridBackground();
            Insert(0, grid);
            
            AddEntryDialogue();
        }

        private void AddEntryDialogue()
        {
            Vector2 desiredPosition = new Vector2(700, 150);
            Entry = _scenario.entryDialogue == null ? DialogueNodeFactory.CreateEntryDialogue(_scenario, desiredPosition, null) : DialogueNodeFactory.CreateEntryDialogue(_scenario, desiredPosition, _scenario.entryDialogue);
            AddElement(Entry);
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
            
            evt.menu.AppendAction("Dialogues/Simple Dialogue", action => AddElement(DialogueNodeFactory.CreateSimpleDialogue(_scenario, graphMousePosition, null)), DropdownMenuAction.AlwaysEnabled);
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new List<Port>();

            foreach (Port port in ports)
            {
                if (startPort == port) continue;
                if (startPort.node == port.node) continue;
                if (startPort.direction == port.direction) continue;

                compatiblePorts.Add(port);
            }

            return compatiblePorts;
        }

        public override EventPropagation DeleteSelection()
        {
            var edgesToDelete = selection.OfType<Edge>().ToList();
            foreach (Edge edge in edgesToDelete)
            {
                EdgeConnectorListener.OnDelete(edge);
            }
            
            List<EntryDialogueUI> dialoguesToDelete = selection.OfType<EntryDialogueUI>().ToList();
            if (dialoguesToDelete.Count > 0)
            {
                return EventPropagation.Stop;
            }

            return base.DeleteSelection();
        }
    }
}