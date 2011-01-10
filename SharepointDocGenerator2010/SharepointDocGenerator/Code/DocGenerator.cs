using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.ApplicationPages; // To inherit from WebAdminPageBase
using Microsoft.SharePoint.Utilities;
// TODO: Add manual reference to C:\Program Files\Common Files\Microsoft Shared\web server extensions\12\CONFIG\BIN\Microsoft.SharePoint.ApplicationPages.dll


namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Code behind class for the document generator page
    /// </summary>
    public class DocGenerator : WebAdminPageBase
    {
        #region "Variables"

        protected Button btnOk;
        protected Button btnShowHideAll;
        protected Button btnGoBack;
        protected Button btnExit;

        protected DropDownList fieldsGroups;
        protected CheckBox chkSelectAllFields;
        protected ListBox fields;
        
        protected DropDownList contentTypesGroups;
        protected CheckBox chkSelectAllContentTypes;
        protected ListBox contentTypes;

        protected CheckBox chkSelectAllLists;
        protected ListBox lists;

        protected CheckBox chkSelectAllFeatures;
        protected ListBox features;

        protected CheckBox chkSelectAllUsers;
        protected ListBox users;

        protected Panel ControlsPanel;
        protected Panel ResultsPanel;
        protected Panel PanelControls;

        List<SPField> _fields = new List<SPField>();
        List<SPContentType> _contentTypes = new List<SPContentType>();
        List<SPList> _lists = new List<SPList>();
        List<SPFeature> _features = new List<SPFeature>();
        List<SPUser> _users = new List<SPUser>();

        #endregion "Variables"

        #region "Properties"

        /// <summary>
        /// Always require site administrator to use this option
        /// </summary>
        protected override bool RequireSiteAdministrator
        {
            get { return true; }
        }

        #endregion "Properties"

        #region "Methods"

        /// <summary>
        /// Default constructor
        /// </summary>
        public DocGenerator()
        {
        }

        /// <summary>
        /// Loading the page, bind data, etc...
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SPWeb web = SPContext.Current.Web;

            // TODO: Store these in the ViewState
            foreach (SPField field in web.AvailableFields) this._fields.Add(field);
            foreach (SPContentType ct in web.AvailableContentTypes) this._contentTypes.Add(ct);
            foreach (SPList list in web.Lists) this._lists.Add(list);
            foreach (SPFeature feature in web.Features) this._features.Add(feature);
            foreach (SPUser user in web.AllUsers) this._users.Add(user);

            // Only if the feature is activated
            if (!this._features.Exists(f => f.Definition.DisplayName == "SharepointDocGenerator"))
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, this.Context);
            }

            this._fields.Sort(delegate(SPField f1, SPField f2) { return f1.Title.CompareTo(f2.Title); });
            this._contentTypes.Sort(delegate(SPContentType ct1, SPContentType ct2) { return ct1.Name.CompareTo(ct2.Name); });
            this._lists.Sort(delegate(SPList l1, SPList l2) { return l1.Title.CompareTo(l2.Title); });
            this._features.Sort(delegate(SPFeature f1, SPFeature f2) { return f1.Definition.DisplayName.CompareTo(f2.Definition.DisplayName); });
            this._users.Sort(delegate(SPUser u1, SPUser u2) { return u1.LoginName.CompareTo(u2.LoginName); });

            if (!this.IsPostBack)
            {
                this.fields.DataTextField = "Title";
                this.fields.DataValueField = "Id";
                this.fields.DataSource = this._fields;
                this.fields.DataBind();

                List<string> fGroups = this._fields.Distinct<SPField>(new SPFieldGroupComparer()).Select(f => f.Group).ToList();
                fGroups.Sort();
                fGroups.Insert(0, "All Groups");
                this.fieldsGroups.DataSource = fGroups;
                this.fieldsGroups.DataBind();

                this.contentTypes.DataTextField = "Name";
                this.contentTypes.DataValueField = "Id";
                this.contentTypes.DataSource = this._contentTypes;
                this.contentTypes.DataBind();

                List<string> ctGroups = this._contentTypes.Distinct<SPContentType>(new SPContentTypeGroupComparer()).Select(ct => ct.Group).ToList();
                ctGroups.Sort();
                ctGroups.Insert(0, "All Groups");
                this.contentTypesGroups.DataSource = ctGroups;
                this.contentTypesGroups.DataBind();

                this.lists.DataTextField = "Title";
                this.lists.DataValueField = "ID";
                this.lists.DataSource = this._lists;
                this.lists.DataBind();

                this.features.DataTextField = "DisplayName"; //"Definition.DisplayName";
                this.features.DataValueField = "DefinitionId";
                this.features.DataSource = (from f in this._features
                                            select new
                                            {
                                                DisplayName = f.Definition.DisplayName,
                                                f.DefinitionId
                                            }).ToList();
                this.features.DataBind();

                this.users.DataTextField = "LoginName";
                this.users.DataValueField = "ID";
                this.users.DataSource = this._users;
                this.users.DataBind();
            }
        }

        /// <summary>
        /// Clicking the Ok button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            this.ControlsPanel.Visible = false;
            this.ResultsPanel.Visible = true;
            // Get the selected fields
            List<SPField> selectedFields = new List<SPField>();
            foreach (int index in this.fields.GetSelectedIndices())
            {
                selectedFields.Add(this._fields.First(f => f.Id.ToString() == this.fields.Items[index].Value));
            }
            if (selectedFields.Count != 0)
            {
                FieldsTemplate fieldsTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/FieldsTemplate.ascx") as FieldsTemplate;
                fieldsTemplate.Data = selectedFields;
                fieldsTemplate.DataBind();
                this.PanelControls.Controls.Add(fieldsTemplate);
            }
            // Get the selected site content types
            foreach (int index in this.contentTypes.GetSelectedIndices())
            {
                ContentTypeTemplate contentTypeTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/ContentTypeTemplate.ascx") as ContentTypeTemplate;
                contentTypeTemplate.Data = this._contentTypes.First(ct => ct.Id.ToString() == this.contentTypes.Items[index].Value);
                contentTypeTemplate.DataBind();
                this.PanelControls.Controls.Add(contentTypeTemplate);
            }

            foreach (int index in this.lists.GetSelectedIndices())
            {
                ListTemplate listTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/ListTemplate.ascx") as ListTemplate;
                listTemplate.Data = this._lists.First(l => l.ID.ToString() == this.lists.Items[index].Value);
                listTemplate.DataBind();
                this.PanelControls.Controls.Add(listTemplate);
            }
            // Get the selected features
            List<SPFeature> selectedFeatures = new List<SPFeature>();
            foreach (int index in this.features.GetSelectedIndices())
            {
                selectedFeatures.Add(this._features.First(f => f.DefinitionId.ToString() == this.features.Items[index].Value));
            }
            if (selectedFeatures.Count != 0)
            {
                FeaturesTemplate featuresTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/FeaturesTemplate.ascx") as FeaturesTemplate;
                featuresTemplate.Data = selectedFeatures;
                featuresTemplate.DataBind();
                this.PanelControls.Controls.Add(featuresTemplate);
            }
            // Get the selected users
            List<SPUser> selectedUsers = new List<SPUser>();
            foreach (int index in this.users.GetSelectedIndices())
            {
                selectedUsers.Add(this._users.First(u => u.ID.ToString() == this.users.Items[index].Value));
            }
            if (selectedUsers.Count != 0)
            {
                UsersTemplate usersTemplate = this.LoadControl("~/_layouts/SharepointDocGenerator/Templates/UsersTemplate.ascx") as UsersTemplate;
                usersTemplate.Data = selectedUsers;
                usersTemplate.DataBind();
                this.PanelControls.Controls.Add(usersTemplate);
            }
        }

        /// <summary>
        /// Changing the group for fields
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void FieldGroupChanged(object sender, EventArgs e)
        {
            this.chkSelectAllFields.Checked = false;
            this.fields.DataTextField = "Title";
            this.fields.DataValueField = "Id";
            if (this.fieldsGroups.Text == "All Groups")
            {
                this.fields.DataSource = this._fields;
            }
            else
            {
                this.fields.DataSource = this._fields.Where(f => f.Group == this.fieldsGroups.Text);
            }
            this.fields.DataBind();
        }

        /// <summary>
        /// Clicking the Back button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void GoBack(object sender, EventArgs e)
        {
            this.ControlsPanel.Visible = true;
            this.ResultsPanel.Visible = false;
            this.PanelControls.Controls.Clear();
        }

        /// <summary>
        /// Clicking the Exit button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void Exit(object sender, EventArgs e)
        {
            SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, this.Context);
        }

        /// <summary>
        /// Changing the group for content types
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void ContentTypeGroupChanged(object sender, EventArgs e)
        {
            this.chkSelectAllContentTypes.Checked = false;
            this.contentTypes.DataTextField = "Name";
            this.contentTypes.DataValueField = "Id";
            if (this.contentTypesGroups.Text == "All Groups")
            {
                this.contentTypes.DataSource = this._contentTypes;
            }
            else
            {
                this.contentTypes.DataSource = this._contentTypes.Where(ct => ct.Group == this.contentTypesGroups.Text);
            }
            this.contentTypes.DataBind();
        }

        /// <summary>
        /// Select all fields
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void SelectAllFields(object sender, EventArgs e)
        {
            foreach (ListItem li in this.fields.Items) li.Selected = this.chkSelectAllFields.Checked;
        }

        /// <summary>
        /// Select all content types
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void SelectAllContentTypes(object sender, EventArgs e)
        {
            foreach (ListItem li in this.contentTypes.Items) li.Selected = this.chkSelectAllContentTypes.Checked;
        }

        /// <summary>
        /// Select all lists
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void SelectAllLists(object sender, EventArgs e)
        {
            foreach (ListItem li in this.lists.Items) li.Selected = this.chkSelectAllLists.Checked;
        }

        /// <summary>
        /// Select all features
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void SelectAllFeatures(object sender, EventArgs e)
        {
            foreach (ListItem li in this.features.Items) li.Selected = this.chkSelectAllFeatures.Checked;
        }

        /// <summary>
        /// Select all users
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        protected void SelectAllUsers(object sender, EventArgs e)
        {
            foreach (ListItem li in this.users.Items) li.Selected = this.chkSelectAllUsers.Checked;
        }

        #endregion "Methods"
    }
}