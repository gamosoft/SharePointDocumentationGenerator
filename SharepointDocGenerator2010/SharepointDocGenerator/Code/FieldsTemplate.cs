using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for fields
    /// </summary>
    public class FieldsTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// Repeater for each individual field
        /// </summary>
        protected Repeater FieldsRepeater;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// List of fields to bind data
        /// </summary>
        public List<SPField> Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public FieldsTemplate()
        {
        }

        /// <summary>
        /// Binding data (new template) for each field in the control
        /// </summary>
        public override void DataBind()
        {
            foreach (SPField field in this.Data)
            {
                SingleFieldTemplate singleFieldTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/SingleFieldTemplate.ascx") as SingleFieldTemplate;
                singleFieldTemplate.Data = field;
                this.FieldsRepeater.Controls.Add(singleFieldTemplate);
            }
        }

        #endregion "Methods"
    }
}