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
using MongoDB.VisualStudio.Explorer.ViewModels;
using MongoDB.VisualStudio.ConnectionManager.ViewModels;
using MongoDB.VisualStudio.ConnectionManager;

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

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public ExplorerWindow() 
            : base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.ToolWindowTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.
            _clusterTreeViewModel = new ExplorerTreeViewModel();
            base.Content = new ExplorerTree(_clusterTreeViewModel);
            this.ToolBar = new CommandID(GuidList.guidMongoVSCmdSet, (int)PkgCmdIDList.tbExplorer);

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (mcs != null)
            {
                CommandID addConnectionCommandID = new CommandID(GuidList.guidMongoVSCmdSet, (int)PkgCmdIDList.cmdExplorerAddConnection);
                MenuCommand addConnectionCommand = new MenuCommand(AddConnection, addConnectionCommandID);
                mcs.AddCommand(addConnectionCommand);
            }
        }

        private void AddConnection(object sender, EventArgs e)
        {
            var model = new AddConnectionViewModel();
            var dialog = new AddConnectionDialog(model);
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var serverModel = new ServerViewModel(model.ServerAddress);
                _clusterTreeViewModel.Children.Add(serverModel);
            }
        }
    }
}