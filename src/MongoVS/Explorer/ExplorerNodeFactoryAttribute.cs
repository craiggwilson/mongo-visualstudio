using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExplorerNodeFactoryAttribute : ExportAttribute
    {
        public ExplorerNodeFactoryAttribute()
            : base(typeof(IExplorerNodeFactory))
        { }
    }
}
