using System;
using System.Collections.Generic;
using System.Linq;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Components;
using NUnit.Framework;

namespace Dastan.Scenester.Editor.util
{
    public class ComponentUtil
    {
        public static List<Component> GetComponents(Dialogue dialogue)
        {
            return ComponentFactory.CreateComponents(dialogue);
        }
    }
}