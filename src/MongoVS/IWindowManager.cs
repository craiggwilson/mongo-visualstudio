using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;

namespace MongoDB.VisualStudio
{
    public interface IWindowManager
    {
        TWindow CreateToolWindow<TWindow>() where TWindow : ToolWindowPane;

        TWindow FindToolWindow<TWindow>(bool create, int id = 0) where TWindow : ToolWindowPane;
    }
}