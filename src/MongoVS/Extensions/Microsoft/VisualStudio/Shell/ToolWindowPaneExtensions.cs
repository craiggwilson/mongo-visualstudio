using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.Shell
{
    public static class ToolWindowPaneExtensions
    {
        public static void Show(this ToolWindowPane @this)
        {
            var windowFrame = (IVsWindowFrame)@this.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}