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
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ComponentModelHost;
using System.ComponentModel.Composition.Hosting;
using System.Collections.Generic;

namespace MongoDB.VisualStudio
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ExplorerWindow))]
    [ProvideToolWindow(typeof(DatabaseEditorWindow),
        DocumentLikeTool = true,
        MultiInstances = true, 
        Style=VsDockStyle.Tabbed,
        Transient=true, 
        Window = EnvDTE.Constants.vsWindowKindMainWindow)]
    [Guid(GuidList.guidMongoVSPkgString)]
    public sealed class MongoVSPackage : Package
    {
        private ICompositionService _compositionService;
        private IWindowManager _windowManager;

        public MongoVSPackage()
        {
            _windowManager = new PackageWindowManager(this);
        }

        public ICompositionService CompositionService
        {
            get { return _compositionService; }
        }

        [Export]
        public IWindowManager WindowManager
        {
            get { return _windowManager; }
        }

        protected override void Initialize()
        {
            base.Initialize();

            var container = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
            _compositionService = container.DefaultCompositionService;

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
            _windowManager.FindToolWindow<ExplorerWindow>(true).Show();
        }

        private class PackageWindowManager : IWindowManager
        {
            private readonly MongoVSPackage _package;
            private Dictionary<Type, int> _windowIndex;

            public PackageWindowManager(MongoVSPackage package)
            {
                _package = package;
                _windowIndex = new Dictionary<Type, int>();
            }

            public TWindow CreateToolWindow<TWindow>() where TWindow : ToolWindowPane
            {
                // surely there is a way to handle this better...
                int index;
                if (!_windowIndex.TryGetValue(typeof(TWindow), out index))
                {
                    index = 0;
                }
                while (true)
                {
                    var window = (TWindow)_package.FindToolWindow(typeof(TWindow), index, false);
                    if (window == null)
                    {
                        window = (TWindow)_package.FindToolWindow(typeof(TWindow), index, true);
                        _package._compositionService.SatisfyImportsOnce(window);
                        _windowIndex[typeof(TWindow)] = index;
                        return window;
                    }

                    index++;
                }
            }

            public TWindow FindToolWindow<TWindow>(bool create, int id = 0) where TWindow : ToolWindowPane
            {
                var window = (TWindow)_package.FindToolWindow(typeof(TWindow), id, false);
                if (window == null && create)
                {
                    window = (TWindow)_package.FindToolWindow(typeof(TWindow), id, true);
                    _package._compositionService.SatisfyImportsOnce(window);
                }

                return window;
            }
        }
    }
}