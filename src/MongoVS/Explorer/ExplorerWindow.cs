using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;
using MongoDB.Driver;
using MongoDB.VisualStudio.ConnectionManager.ViewModels;
using MongoDB.VisualStudio.ConnectionManager;
using System.Windows.Input;
using System.ComponentModel.Composition;

namespace MongoDB.VisualStudio.Explorer
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("6afb9412-b6bc-4da8-b17b-29b1109062b5")]
    public class ExplorerWindow : ToolWindowPane
    {
        private ExplorerTreeViewModel _clusterTreeViewModel;

        [Import]
        public IRootExplorerNodeFactory RootExplorerNodeFactory { get; set; }

        [Import]
        public IWindowManager WindowManager { get; set; }

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public ExplorerWindow()
            : base(null)
        {
            this.Caption = "MongoDB Explorer";

            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;
            base.Content = new ExplorerTree();
            this.ToolBar = new CommandID(GuidList.guidMongoVSCmdSet, (int)PkgCmdIDList.tbExplorer);

            _clusterTreeViewModel = new ExplorerTreeViewModel();
            ((ExplorerTree)base.Content).ViewModel = _clusterTreeViewModel;

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (mcs != null)
            {
                CommandID addConnectionCommandID = new CommandID(GuidList.guidMongoVSCmdSet, (int)PkgCmdIDList.cmdExplorerAddConnection);
                MenuCommand addConnectionCommand = new MenuCommand(AddConnection, addConnectionCommandID);
                mcs.AddCommand(addConnectionCommand);
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            ((MongoVSPackage)Package).CompositionService.SatisfyImportsOnce(this);
            ((ExplorerTree)base.Content).WindowManager = WindowManager;
        }

        private void AddConnection(object sender, EventArgs e)
        {
            var rootNode = RootExplorerNodeFactory.CreateRootNode("temp", new[] { "localhost" });
            _clusterTreeViewModel.Children.Add(rootNode);

            //var model = new AddConnectionViewModel();
            //var dialog = new AddConnectionDialog(model);
            //var result = dialog.ShowDialog();
            //if (result.HasValue && result.Value)
            //{
            //    var serverModel = new ServerViewModel(model.ServerAddress);
            //    _clusterTreeViewModel.Children.Add(serverModel);
            //}
        }
    }
}