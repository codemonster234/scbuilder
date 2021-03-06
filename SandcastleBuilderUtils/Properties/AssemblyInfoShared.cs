//=============================================================================
// System  : Sandcastle Help File Builder
// File    : AssemblyInfoShared.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 07/07/2010
// Note    : Copyright 2006-2010, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// Sandcastle Help File Builder common assembly attributes.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy
// of the license should be distributed with the code.  It can also be found
// at the project website: http://SHFB.CodePlex.com.   This notice, the
// author's name, and all copyright notices must remain intact in all
// applications, documentation, and source files.
//
// Version     Date     Who  Comments
// ============================================================================
// 1.0.0.0  08/02/2006  EFW  Created the code
// 1.1.0.0  08/22/2006  EFW  Added support for building MS Help 2 files
// 1.2.0.0  09/02/2006  EFW  Various additions and updates
// 1.3.0.0  09/08/2006  EFW  Various additions and updates
// 1.3.2.0  10/10/2006  EFW  Various additions and updates
// 1.3.4.0  12/24/2006  EFW  Various additions and updates
// 1.5.0.0  06/19/2007  EFW  Various additions and updates
// 1.6.0.0  06/19/2007  EFW  Various additions and updates
// 1.8.0.0  06/20/2008  EFW  Implemented new MSBuild project format
// 1.9.0.0  06/06/2010  EFW  Added support for generating MS Help Viewer files
//=============================================================================

using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Resources contained within the assembly are English
[assembly: NeutralResourcesLanguageAttribute("en")]

//
// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Eric Woodruff")]
[assembly: AssemblyCopyright("Copyright \xA9 2006-2010, Eric Woodruff, All Rights Reserved")]
[assembly: AssemblyTrademark("Eric Woodruff, All Rights Reserved")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// No special permissions are required by this assembly
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers
// by using the '*' as shown below:

// NOTE: Revision number should always be zero.  This allows build component
// and plug-in developers to use the same major, minor, and build numbers
// as the Sandcastle Help File Builder to indicate with which version their
// components are compatible.
[assembly: AssemblyVersion("1.9.1.0")]

// See AssemblyInfo.cs for project-specific assembly attributes
