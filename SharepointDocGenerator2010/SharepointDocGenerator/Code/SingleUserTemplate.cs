using System.Web.UI;
using Microsoft.Office.Server;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Tempalte for a single user
    /// </summary>
    public class SingleUserTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// User profile
        /// </summary>
        private UserProfile _profile;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// SPUser object to retrieve information from
        /// </summary>
        public SPUser Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public SingleUserTemplate()
        {
        }

        /// <summary>
        /// Retrieve a property value, or default value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Value</returns>
        public string ProfileProperty(string propertyName)
        {
            return this.GetStringValueOrDefault(propertyName);
        }

        /// <summary>
        /// Locate user information to bind data
        /// </summary>
        public override void DataBind()
        {
            try
            {
                SPServiceContext serverContext = SPServiceContext.GetContext(SPContext.Current.Site);
                UserProfileManager profileManager = new UserProfileManager(serverContext);
                this._profile = profileManager.GetUserProfile(this.Data.LoginName);
            }
            catch // (Exception exc)
            {
                //Log.Write(String.Format("Error retrieving manager profile of user '{0}'. Exception: {1}", loginName, exc.Message), EventLogEntryType.Warning);
            }
        }

        /// <summary>
        /// Gets a string value of a property, or the empty string in case of error
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns>String value</returns>
        private string GetStringValueOrDefault(string property)
        {
            string retValue = "";
            if (this._profile != null)
            {
                try
                {
                    retValue = this._profile[property].Value.ToString();
                }
                catch { }
            }
            return retValue;
        }

        #endregion "Methods"
    }
}