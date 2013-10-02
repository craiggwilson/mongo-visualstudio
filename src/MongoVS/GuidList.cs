// Guids.cs
// MUST match guids.h
using System;

namespace MongoDB.VisualStudio
{
    internal static class GuidList
    {
        public const string guidMongoVSPkgString = "b813cef7-289c-4101-90c9-aa22b53faf8b";
        public const string guidMongoVSCmdSetString = "15e131aa-292e-421d-9008-41d2632d9b86";

        public const string guidExplorerWindowPersistanceString = "6afb9412-b6bc-4da8-b17b-29b1109062b5";
        public const string guidDatabaseEditorWindowsPersistenceString = "6E1F4FD8-FD30-4426-8A74-15AC3F175746";

        public static readonly Guid guidMongoVSCmdSet = new Guid(guidMongoVSCmdSetString);
    };
}