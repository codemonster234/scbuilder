//=============================================================================
// System  : Sandcastle Help File Builder Utilities
// File    : TokenCollection.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 08/07/2008
// Note    : Copyright 2008, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains a collection class used to hold the conceptual content
// token information from a token file.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy
// of the license should be distributed with the code.  It can also be found
// at the project website: http://SHFB.CodePlex.com.   This notice, the
// author's name, and all copyright notices must remain intact in all
// applications, documentation, and source files.
//
// Version     Date     Who  Comments
// ============================================================================
// 1.6.0.7  04/24/2008  EFW  Created the code
// 1.8.0.0  07/25/2008  EFW  Reworked to support new MSBuild project format
//=============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

using SandcastleBuilder.Utils;

using Microsoft.Build.BuildEngine;

namespace SandcastleBuilder.Utils.ConceptualContent
{
    /// <summary>
    /// This collection class is used to hold the conceptual content tokens
    /// for an associated token file.
    /// </summary>
    public class TokenCollection : BindingList<Token>
    {
        #region Private data members
        //=====================================================================

        private FileItem fileItem;
        #endregion

        #region Properties
        //=====================================================================

        /// <summary>
        /// This read-only property returns the project file item associated
        /// with the collection.
        /// </summary>
        public FileItem FileItem
        {
            get { return fileItem; }
        }
        #endregion

        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file">The token file associated with the collection.</param>
        /// <remarks>Tokens are not loaded until the <see cref="Load" /> method
        /// is called.</remarks>
        public TokenCollection(FileItem file)
        {
            fileItem = file;
        }
        #endregion

        #region Sort collection
        //=====================================================================
        // Sort the collection

        /// <summary>
        /// This is used to sort the collection
        /// </summary>
        /// <remarks>Values are sorted by token name and value.  Comparisons
        /// are case-sensitive.</remarks>
        public void Sort()
        {
            ((List<Token>)base.Items).Sort(
                delegate(Token x, Token y)
                {
                    int result = String.Compare(x.TokenName, y.TokenName,
                        StringComparison.CurrentCulture);

                    if(result == 0)
                        result = String.Compare(x.TokenValue, y.TokenValue,
                            StringComparison.CurrentCulture);

                    return result;
                });
        }
        #endregion

        #region Read/write the token file
        //=====================================================================

        /// <summary>
        /// Load the collection from the related file
        /// </summary>
        /// <remarks>This will be done automatically at constructor.  This can
        /// be called to reload the collection if needed.</remarks>
        public void Load()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader xr = null;

            try
            {
                this.Clear();
                settings.CloseInput = true;

                xr = XmlReader.Create(fileItem.FullPath, settings);
                xr.MoveToContent();

                while(!xr.EOF)
                {
                    if(xr.NodeType == XmlNodeType.Element && xr.Name == "item")
                        this.Add(new Token(xr.GetAttribute("id"),
                            xr.ReadInnerXml()));

                    xr.Read();
                }

                this.Sort();
            }
            finally
            {
                if(xr != null)
                    xr.Close();
            }
        }

        /// <summary>
        /// Save the token collection to its related file ready for use by
        /// <b>BuildAssembler</b>.
        /// </summary>
        public void Save()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = null;

            try
            {
                settings.Indent = true;
                settings.CloseOutput = true;
                writer = XmlWriter.Create(fileItem.FullPath, settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("content");
                writer.WriteAttributeString("xml", "space", null, "preserve");
                writer.WriteAttributeString("xmlns", "ddue", null,
                    "http://ddue.schemas.microsoft.com/authoring/2003/5");
                writer.WriteAttributeString("xmlns", "xlink", null,
                    "http://www.w3.org/1999/xlink");

                foreach(Token t in this)
                {
                    writer.WriteStartElement("item");
                    writer.WriteAttributeString("id", t.TokenName);

                    // The value is written as raw text to preserve any XML
                    // within it.  The token value is also trimmed to remove
                    // unnecessary whitespace that might affect the layout.
                    writer.WriteRaw(t.TokenValue.Trim());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();   // </content>
                writer.WriteEndDocument();
            }
            finally
            {
                if(writer != null)
                    writer.Close();
            }
        }
        #endregion
    }
}
