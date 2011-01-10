using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Template for features
    /// </summary>
    public class FeaturesTemplate : UserControl
    {
        #region "Variables"

        /// <summary>
        /// Repeater to hold features
        /// </summary>
        protected Repeater FeaturesRepeater;

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// List of features to bind data
        /// </summary>
        public List<SPFeature> Data { get; set; }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public FeaturesTemplate()
        {
        }

        /// <summary>
        /// Load feature template for each item in the list
        /// </summary>
        public override void DataBind()
        {
            foreach (SPFeature feature in this.Data)
            {
                SingleFeatureTemplate singleFeatureTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/SingleFeatureTemplate.ascx") as SingleFeatureTemplate;
                singleFeatureTemplate.Data = feature;
                this.FeaturesRepeater.Controls.Add(singleFeatureTemplate);
            }
        }

        #endregion "Methods"
    }
}