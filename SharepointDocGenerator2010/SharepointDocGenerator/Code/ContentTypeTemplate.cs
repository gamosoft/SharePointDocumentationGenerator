using System.Collections.Generic;
using System.Web.UI;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template to show content types
    /// </summary>
    public class ContentTypeTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// Fields template
        /// </summary>
        protected FieldsTemplate fieldsTemplate;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// Content type to bind fields
        /// </summary>
        public SPContentType Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContentTypeTemplate()
        {
        }

        /// <summary>
        /// Binding of the data to add fields
        /// </summary>
        public override void DataBind()
        {
            List<SPField> fields = new List<SPField>();

            foreach (SPField field in this.Data.Fields) fields.Add(field);

            fieldsTemplate.Data = fields;
            fieldsTemplate.DataBind();
        }

        #endregion "Methods"
    }
}