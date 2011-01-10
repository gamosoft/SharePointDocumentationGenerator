<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.FieldsTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>

<div class='collapsibleContainer' myTitle='Fields'>
    <table class='mGrid'>
        <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Type</th>
            <th>Group</th>
            <th>Static name</th>
            <th>Internal name</th>
            <th>Description</th>
            <th>Read Only</th>
            <th>Required</th>
            <th>Hidden</th>
            <th>Sealed</th>
            <th>Sortable</th>
            <th>Indexed</th>
            <th>Used in Web Content Types</th>
            <th>Scope</th>
        </tr>
        <asp:Repeater ID="FieldsRepeater" runat="server" />
    </table>
</div>