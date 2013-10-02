using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MongoDB.VisualStudio
{
    public static class MongoVSCommands
    {
        public static RoutedUICommand ViewDatabase = new RoutedUICommand("View Database", "ViewDatabase", typeof(MongoVSCommands));
    }
}