using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Feature receiver to execute custom code upon activation
    /// </summary>
    public class SharepointDocGeneratorFeatureReceiver : SPFeatureReceiver
    {
        #region "Methods"

        /// <summary>
        /// Code to be executed when the feature is activated
        /// </summary>
        /// <param name="properties">SPFeatureReceiverProperties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            // Used this code to add the navigation node to the sitemap, so the breadcrumb navigation works
            // http://weblogs.asp.net/jan/archive/2008/04/16/adding-breadcrumb-navigation-to-sharepoint-application-pages-the-easy-way.aspx
            SPFarm.Local.Services.GetValue<SPWebService>().ApplyApplicationContentToLocalServer(); 
        }

        /// <summary>
        /// Code to be executed when the feature is deactivated
        /// </summary>
        /// <param name="properties">SPFeatureReceiverProperties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties) { }

        /// <summary>
        /// Code to be executed when the feature is installed
        /// </summary>
        /// <param name="properties">SPFeatureReceiverProperties</param>
        public override void FeatureInstalled(SPFeatureReceiverProperties properties) { }

        /// <summary>
        /// Code to be executed when the feature is uninstalled
        /// </summary>
        /// <param name="properties">SPFeatureReceiverProperties</param>
        public override void FeatureUninstalling(SPFeatureReceiverProperties properties) { }

        #endregion "Methods"
    }
}