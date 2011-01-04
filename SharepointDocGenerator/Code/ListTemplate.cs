using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for lists
    /// </summary>
    public class ListTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// Template to hold list of fields
        /// </summary>
        protected FieldsTemplate fieldsTemplate;

        /// <summary>
        /// Repeater for list content types
        /// </summary>
        protected Repeater ContentTypeRepeater;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// MOSS list to bind data
        /// </summary>
        public SPList Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListTemplate()
        {
        }

        /// <summary>
        /// Load content type and fields templates
        /// </summary>
        public override void DataBind()
        {
            foreach (SPContentType ct in this.Data.ContentTypes)
            {
                ContentTypeTemplate contentTypeTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/ContentTypeTemplate.ascx") as ContentTypeTemplate;
                contentTypeTemplate.Data = ct;
                contentTypeTemplate.DataBind();
                ContentTypeRepeater.Controls.Add(contentTypeTemplate);
            }

            List<SPField> fields = new List<SPField>();
            foreach (SPField field in this.Data.Fields) fields.Add(field);
            fieldsTemplate.Data = fields;
            fieldsTemplate.DataBind();
        }

        #endregion "Methods"
    }
}