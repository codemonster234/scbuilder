//=============================================================================
// System  : EWSoftware Design Time Attributes and Editors
// File    : MSHelpAttrEditorDlg.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 07/03/2008
// Note    : Copyright 2008, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains the form used to edit the help attribute items.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy
// of the license should be distributed with the code.  It can also be found
// at the project website: http://SHFB.CodePlex.com.   This notice, the
// author's name, and all copyright notices must remain intact in all
// applications, documentation, and source files.
//
// Version     Date     Who  Comments
// ============================================================================
// 1.6.0.7  03/27/2008  EFW  Created the code
//=============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using SandcastleBuilder.Utils;

namespace SandcastleBuilder.Utils.Design
{
    /// <summary>
    /// This form is used to edit the help attribute collection
    /// </summary>
    internal partial class MSHelpAttrEditorDlg : Form
    {
        #region Private data members
        //=====================================================================

        private MSHelpAttrCollection attributes;
        #endregion

        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentAttributes">The item collection to edit</param>
        /// <param name="isTopic">If true, the Default button is hidden as
        /// topics don't need to include the default attributes.  They are
        /// added automatically at build time.</param>
        public MSHelpAttrEditorDlg(MSHelpAttrCollection currentAttributes,
          bool isTopic)
        {
            InitializeComponent();

            if(isTopic)
                btnDefault.Visible = false;

            attributes = currentAttributes;
            dgvAttributes.AutoGenerateColumns = false;
            dgvAttributes.DataSource = attributes;
        }
        #endregion

        #region Event handlers
        //=====================================================================

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            attributes.Sort();
            this.Close();
        }

        /// <summary>
        /// Add new help attribute
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvAttributes.EndEdit();
            attributes.Add("NoName", null);
            dgvAttributes.CurrentCell = dgvAttributes[0,
                attributes.Count - 1];
            dgvAttributes.Focus();
        }

        /// <summary>
        /// Delete the selected attribute
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idx;

            if(dgvAttributes.SelectedRows.Count != 0)
            {
                idx = dgvAttributes.SelectedRows[0].Index;

                if(idx < attributes.Count)
                {
                    dgvAttributes.EndEdit();
                    attributes.RemoveAt(idx);
                }
            }
        }

        /// <summary>
        /// Insert a default set of attributes if they are not already there
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            dgvAttributes.DataSource = null;

            attributes.Add("DocSet", "NetFramework");
            attributes.Add("DocSet", "{@HtmlHelpName}");
            attributes.Add("TargetOS", "Windows");

            attributes.Sort();
            dgvAttributes.DataSource = attributes;
        }

        /// <summary>
        /// View help for this form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);

            try
            {
#if DEBUG
                path += @"\..\..\..\Doc\Help\SandcastleBuilder.chm";
#else
                path += @"\SandcastleBuilder.chm";
#endif
                Form form = new Form();
                form.CreateControl();
                Help.ShowHelp(form, path, HelpNavigator.Topic,
                    "html/7d28bf8f-923f-44c1-83e1-337a416947a1.htm#HelpAttributes");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show(String.Format(CultureInfo.CurrentCulture,
                    "Unable to open help file '{0}'.  Reason: {1}",
                    path, ex.Message), Constants.AppName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Mark the collection as dirty if changed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void dgvAttributes_CellValueChanged(object sender,
          DataGridViewCellEventArgs e)
        {
            if(attributes != null)
                attributes.MarkAsDirty();
        }
        #endregion
    }
}
