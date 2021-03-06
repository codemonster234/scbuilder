//=============================================================================
// System  : Sandcastle Help File Builder Utilities
// File    : BuildStep.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 06/30/2010
// Note    : Copyright 2006-2010, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains the enumerated type that defines the build steps used
// when reporting progress during a build.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy
// of the license should be distributed with the code.  It can also be found
// at the project website: http://SHFB.CodePlex.com.   This notice, the
// author's name, and all copyright notices must remain intact in all
// applications, documentation, and source files.
//
// Version     Date     Who  Comments
// ============================================================================
// 1.0.0.0  08/10/2006  EFW  Created the code
// 1.6.0.2  11/06/2007  EFW  Added new component config merge build step
// 1.6.0.5  02/04/2008  EFW  Added HTML Info Extract and Generate Inherited
//                           documentation build steps.
// 1.6.0.7  03/24/2008  EFW  Removed the PurgeDuplicateTopics build step.
//                           Added conceptual content build steps.
// 1.9.0.0  06/13/2010  EFW  Moved GenerateIntermediateTableOfContents so that
//                           it occurs right after MergeTablesOfContents.
// 1.9.0.0  06/30/2010  EFW  Added CombiningIntermediateTocFiles step and
//                           removed UpdateTableOfContents step.
//=============================================================================

using System;

namespace SandcastleBuilder.Utils.BuildEngine
{
    /// <summary>
    /// This public enumerated type defines the build steps used when reporting
    /// progress during a build.
    /// </summary>
    [Serializable]
    public enum BuildStep
    {
        /// <summary>The build has not yet started.</summary>
        None,
        /// <summary>Initializing to prepare for build.</summary>
        Initializing,
        /// <summary>The working folder is about to be created or cleared.</summary>
        ClearWorkFolder,
        /// <summary>The builder is searching for Sandcastle and the
        /// HTML help compiler.</summary>
        FindingTools,
        /// <summary>The documentation source information is being validated
        /// and copied to the build folder.</summary>
        ValidatingDocumentationSources,
        /// <summary>The shared content files are being generated.</summary>
        GenerateSharedContent,
        /// <summary>Generate the API filter for MRefBuilder</summary>
        GenerateApiFilter,
        /// <summary>The reflection information is being generated by
        /// <b>MRefBuilder</b>.</summary>
        GenerateReflectionInfo,
        /// <summary>Namespace summary information is being generated.</summary>
        GenerateNamespaceSummaries,
        /// <summary>The Visibility category properties are being applied to
        /// the reflection information file to remove unwanted items.</summary>
        ApplyVisibilityProperties,
        /// <summary>All <c>&lt;inheritDoc /&gt;</c> tags are being expanded.</summary>
        GenerateInheritedDocumentation,
        /// <summary>The reflection information is being transformed by
        /// <b>XslTransform</b>.</summary>
        TransformReflectionInfo,
        /// <summary>Help topic filenames are being altered.</summary>
        ModifyHelpTopicFilenames,
        /// <summary>The standard help file content (art, scripts, and styles)
        /// is being copied to the help project folder.</summary>
        CopyStandardContent,
        /// <summary>The conceptual content files are being copied.</summary>
        CopyConceptualContent,
        /// <summary>The conceptual content topic configuration files are being
        /// generated.</summary>
        CreateConceptualTopicConfigs,
        /// <summary>The additional content files are being copied to the
        /// help project folder.</summary>
        CopyAdditionalContent,
        /// <summary>The conceptual and additional content tables of contents
        /// are being merged.</summary>
        MergeTablesOfContents,
        /// <summary>The intermediate table of contents is being generated by
        /// <b>XslTransform</b>.</summary>
        GenerateIntermediateTableOfContents,
        /// <summary>The <b>sandcastle.config</b> <b>Conceptual.config</b>
        /// <b>BuildAssembler</b> files are being created.</summary>
        CreateBuildAssemblerConfigs,
        /// <summary>Custom build component configurations are being merged
        /// into the <b>sandcastle.config</b> file.</summary>
        MergeCustomConfigs,
        /// <summary>Conceptual help file topics are being generated by
        /// <b>BuildAssembler</b>.</summary>
        BuildConceptualTopics,
        /// <summary>API reference help file topics are being generated by
        /// <b>BuildAssembler</b>.</summary>
        BuildReferenceTopics,
        /// <summary>The intermediate table of content files are being merged
        /// into a single file.</summary>
        CombiningIntermediateTocFiles,
        /// <summary>Title and keyword index information is being extracted for
        /// the HTML Help 1 TOC and index and/or website TOC.</summary>
        ExtractingHtmlInfo,
        /// <summary>The format-specific table of contents is being generated
        /// by <b>XslTransform</b>.</summary>
        GenerateHelpFormatTableOfContents,
        /// <summary>The help file index is being generated.</summary>
        GenerateHelpFileIndex,
        /// <summary>The help project file is being generated.</summary>
        GenerateHelpProject,
        /// <summary>The help file project is being compiled.</summary>
        CompilingHelpFile,
        /// <summary>Generate full-text index for ASP.NET website search.</summary>
        GenerateFullTextIndex,
        /// <summary>The website files are being copied to the output path.</summary>
        CopyingWebsiteFiles,
        /// <summary>The temporary help project files are being removed.</summary>
        CleanIntermediates,
        /// <summary>The build has completed successfully.</summary>
        Completed,
        /// <summary>The build was canceled by user request.</summary>
        Canceled,
        /// <summary>The build failed with an unexpected error.</summary>
        Failed
    }
}
