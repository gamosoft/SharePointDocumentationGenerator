<%@ Assembly Name="Microsoft.SharePoint.ApplicationPages, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%> 
<%@ Page MaintainScrollPositionOnPostback="true" Language="C#" Inherits="SharepointDocGenerator.Code.DocGenerator, SharepointDocGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d2509254a3c55f6" MasterPageFile="~/_layouts/application.master" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register Tagprefix="wc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.Portal.WebControls" Assembly="Microsoft.SharePoint.Portal, Version=14.0.0.0,  Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Documentation Generator
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
    Sharepoint Documentation Generator
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">

    <script type="text/javascript" src="/_layouts/SharepointDocGenerator/Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/_layouts/SharepointDocGenerator/Scripts/diQuery-collapsiblePanel.js"></script>
    <script type="text/javascript" src="/_layouts/SharepointDocGenerator/scripts/jquery-ui-1.8.4.custom.min.js"></script>
    <link media="screen" href="/_layouts/SharepointDocGenerator/Styles/jquery-ui-1.8.4.custom.css" type="text/css" rel="StyleSheet" />
    <link media="screen" href="/_layouts/SharepointDocGenerator/Styles/diQuery-collapsiblePanel.css" type="text/css" rel="StyleSheet" />

    <script type="text/javascript">
        $(document).ready(function() {
            $(".collapsibleContainer").collapsiblePanel();
            ShowHideAll();
        });
    </script>

    <asp:Panel ID="ControlsPanel" runat="server" Visible="true">
    <table class=ms-propertysheet border="0" width="100%" cellspacing="0" cellpadding="0">
    	<wssuc:InputFormSection Title="Fields" Description="Choose fields export settings" runat="server">
			<Template_InputFormControls>
                <wssuc:InputFormControl LabelText="Groups:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormDropDownList ID="fieldsGroups" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="FieldGroupChanged" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl LabelText="Fields:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormCheckBox ID="chkSelectAllFields" AutoPostBack="true" OnCheckedChanged="SelectAllFields" runat="server" Text="Select all" class="ms-input" />
                        <wssawc:InputFormListBox ID="fields" runat="server" SelectionMode="Multiple" Rows="10" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
		</wssuc:InputFormSection>

    	<wssuc:InputFormSection Title="Content Types" Description="Choose content types export settings" runat="server">
			<Template_InputFormControls>
                <wssuc:InputFormControl LabelText="Groups:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormDropDownList ID="contentTypesGroups" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ContentTypeGroupChanged" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl LabelText="Content Types:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormCheckBox ID="chkSelectAllContentTypes" AutoPostBack="true" OnCheckedChanged="SelectAllContentTypes" runat="server" Text="Select all" class="ms-input" />
                        <wssawc:InputFormListBox ID="contentTypes" runat="server" SelectionMode="Multiple" Rows="10" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
		</wssuc:InputFormSection>

    	<wssuc:InputFormSection Title="Lists" Description="Choose lists export settings" runat="server">
			<Template_InputFormControls>
                <wssuc:InputFormControl LabelText="Lists:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormCheckBox ID="chkSelectAllLists" AutoPostBack="true" OnCheckedChanged="SelectAllLists" runat="server" Text="Select all" class="ms-input" />
                        <wssawc:InputFormListBox ID="lists" runat="server" SelectionMode="Multiple" Rows="10" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
		</wssuc:InputFormSection>

    	<wssuc:InputFormSection Title="Features" Description="Choose features export settings" runat="server">
			<Template_InputFormControls>
                <wssuc:InputFormControl LabelText="Features:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormCheckBox ID="chkSelectAllFeatures" AutoPostBack="true" OnCheckedChanged="SelectAllFeatures" runat="server" Text="Select all" class="ms-input" />
                        <wssawc:InputFormListBox ID="features" runat="server" SelectionMode="Multiple" Rows="10" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
		</wssuc:InputFormSection>

    	<wssuc:InputFormSection Title="Users" Description="Choose users export settings" runat="server">
			<Template_InputFormControls>
                <wssuc:InputFormControl LabelText="Users:" runat="server">
                    <Template_Control>
                        <wssawc:InputFormCheckBox ID="chkSelectAllUsers" AutoPostBack="true" OnCheckedChanged="SelectAllUsers" runat="server" Text="Select all" class="ms-input" />
                        <wssawc:InputFormListBox ID="users" runat="server" SelectionMode="Multiple" Rows="10" class="ms-input" />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
		</wssuc:InputFormSection>

		<wssuc:ButtonSection runat="server">
            <Template_Buttons>
                <asp:Button id="btnOk"
                    UseSubmitBehavior="false" runat="server"
                    class="ms-ButtonHeightWidth" OnClick="btnOk_Click" Text="Ok" />
            </Template_Buttons>
        </wssuc:ButtonSection>
    </table>
    </asp:Panel>
    <asp:Panel ID="ResultsPanel" runat="server" Visible="false">
        <div align="left">
            <asp:Button ID="btnShowHideAll" Text="Show/Hide all" runat="server" OnClientClick="return ShowHideAll();" class="ms-ButtonHeightWidth" />
            &nbsp;<asp:Button ID="btnGoBack" Text="Back" OnClick="GoBack" runat="server" class="ms-ButtonHeightWidth" />
            &nbsp;<asp:Button ID="btnExit" Text="Exit" OnClick="Exit" runat="server" class="ms-ButtonHeightWidth" />
        </div>
        <br />
        <asp:Panel ID="PanelControls" runat="server" />
    </asp:Panel>
</asp:Content>