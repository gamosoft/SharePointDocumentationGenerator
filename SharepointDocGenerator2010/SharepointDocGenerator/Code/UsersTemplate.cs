using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for users
    /// </summary>
    public class UsersTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// Repeater to display the list of users (templates)
        /// </summary>
        protected Repeater UsersRepeater;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// Collection of users to bind data
        /// </summary>
        public List<SPUser> Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersTemplate()
        {
        }

        /// <summary>
        /// Bind each user to it's own template and add to the repeater
        /// </summary>
        public override void DataBind()
        {
            foreach (SPUser user in this.Data)
            {
                SingleUserTemplate singleUserTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/SingleUserTemplate.ascx") as SingleUserTemplate;
                singleUserTemplate.Data = user;
                singleUserTemplate.DataBind();
                this.UsersRepeater.Controls.Add(singleUserTemplate);
            }
        }

        #endregion "Methods"
    }
}