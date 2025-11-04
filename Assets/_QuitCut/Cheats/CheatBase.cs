using System;
using System.Collections.Generic;
using System.ComponentModel;
using SRDebugger;
using VContainer.Unity;

namespace QuitCut.Cheats
{
    public abstract class CheatBase : IDisposable, IStartable
    {
        protected List<OptionDefinition> addedDynamicOptions = new();
        
        protected OptionDefinition AddDynamicOption(string name, Action action, string category)
        {
            var option = SRDebuggerUtils.AddDynamicOption(category, name, action);
            addedDynamicOptions.Add(option);
            return option;
        }
        
        [Browsable(false)]
        public void Dispose()
        {
            foreach (var option in addedDynamicOptions)
            {
                SRDebuggerUtils.RemoveDynamicOption(option);
            }
            addedDynamicOptions.Clear();
            SRDebuggerUtils.RemoveOptionContainer(this);
        }

        [Browsable(false)]
        public virtual void Start()
        {
            SRDebuggerUtils.AddOptionContainer(this);
        }
    }
}