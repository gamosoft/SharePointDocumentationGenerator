using System.Web.UI;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for a feature
    /// </summary>
    public class SingleFeatureTemplate : UserControl
    {
        #region "Properties"

        /// <summary>
        /// Actual feature that contains the information
        /// </summary>
        public SPFeature Data { get; set; }

        #endregion "Properties"
    }
}