using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Windows;
using MongoDB.VisualStudio.Explorer;
using MongoDB.VisualStudio.Editors.Database;

namespace MongoDB.VisualStudio
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ExplorerWindow))]
    [ProvideToolWindow(typeof(DatabaseEditorWindow), 
        MultiInstances=true, 
        Style=VsDockStyle.Tabbed,
        Transient=true, DocumentLikeTool=true)]
    [Guid(GuidList.guidMongoVSPkgString)]
    public sealed class MongoVSPackage : Package
    {
        public MongoVSPackage()
        { }

        protected override void Initialize()
        {
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (mcs != null)
            {
                CommandID toolwndCommandID = new CommandID(GuidList.guidMongoVSCmdSet, (int)PkgCmdIDList.cmdShowExplorerWindow);
                MenuCommand menuToolWin = new MenuCommand(ShowExplorerWindow, toolwndCommandID);
                mcs.AddCommand( menuToolWin );
            }
        }

        private void ShowExplorerWindow(object sender, EventArgs e)
        {
            var window = this.FindToolWindow(typeof(ExplorerWindow), 0, true);
            if (window == null || window.Frame == null)
            {
                throw new NotSupportedException(Resources.CanNotCreateWindow);
            }
            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}