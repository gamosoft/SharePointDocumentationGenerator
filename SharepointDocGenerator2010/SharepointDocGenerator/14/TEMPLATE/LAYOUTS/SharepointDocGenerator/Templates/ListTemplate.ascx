<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.ListTemplate" %>
<%@ Register TagPrefix="DG" TagName="ContentTypeTemplate" Src="/_layouts/SharepointDocGenerator/Templates/ContentTypeTemplate.ascx" %>
<%@ Register TagPrefix="DG" TagName="FieldsTemplate" Src="/_layouts/SharepointDocGenerator/Templates/FieldsTemplate.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<div class='collapsibleContainer' myTitle='List: <%= this.Data.Title %>'>
    <table class='mGrid'>
        <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Description</th>
            <th>Allow Content Types</th>
            <th>Content Types Enabled</th>
            <th>Hidden</th>
        </tr>
        <tr>
            <td><%= this.Data.ID.ToString() %></td>
            <td><%= this.Data.Title %></td>
            <td><%= this.Data.Description %></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.AllowContentTypes ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.ContentTypesEnabled ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Hidden ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
        </tr>
        <tr>
            <td colspan='6'><asp:Repeater ID="ContentTypeRepeater" runat="server" /></td>
        </tr>
        <tr>
            <td colspan='6'><DG:FieldsTemplate ID="fieldsTemplate" runat="server" /></td>
        </tr>
    </table>
</div>