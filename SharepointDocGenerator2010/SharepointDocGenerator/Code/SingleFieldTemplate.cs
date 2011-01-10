using System.Web.UI;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for a single field
    /// </summary>
    public class SingleFieldTemplate : UserControl
    {
        #region "Properties"

        /// <summary>
        /// Actual field that holds the information
        /// </summary>
        public SPField Data { get; set; }

        #endregion "Properties"
    }
}