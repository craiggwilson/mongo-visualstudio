using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public interface IHandlesLefMouseButtonDoubleClick
    {
        ICommand LefMouseButtonDoubleClickCommand { get; }
    }
}