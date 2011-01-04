<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.UsersTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<div class='collapsibleContainer' myTitle='Users'>
    <table class='mGrid'>
        <tr>
            <th>ID</th>
            <th>SID</th>
            <th>Login Name</th>
            <th>Full Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Department</th>
            <th>Site Admin</th>
            <th>Site Auditor</th>
            <th>Domain Group</th>
        </tr>
        <asp:Repeater ID="UsersRepeater" runat="server" />
    </table>
</div>