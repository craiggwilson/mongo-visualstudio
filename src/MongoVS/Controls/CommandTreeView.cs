using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MongoDB.VisualStudio.Controls
{
    public class CommandTreeView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommandTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CommandTreeViewItem;
        }
    }
}
