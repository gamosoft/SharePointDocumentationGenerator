<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.ContentTypeTemplate" %>
<%@ Register TagPrefix="DG" TagName="FieldsTemplate" Src="/_layouts/SharepointDocGenerator/Templates/FieldsTemplate.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<div class='collapsibleContainer' myTitle='Content Type: <%= this.Data.Name %>'>
    <table class='mGrid'>
        <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Group</th>
            <th>Description</th>
            <th>Read Only</th>
            <th>Hidden</th>
            <th>Sealed</th>
            <th>Scope</th>
        </tr>
        <tr>
            <td><%= this.Data.Id.ToString() %></td>
            <td><%= this.Data.Name %></td>
            <td><%= this.Data.Group %></td>
            <td><%= this.Data.Description %></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.ReadOnly ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Hidden ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
            <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Sealed ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
            <td><%= this.Data.Scope %></td>
        </tr>
        <tr>
            <td colspan='8'><DG:FieldsTemplate ID="fieldsTemplate" runat="server" /></td>
        </tr>
    </table>
</div>