<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.FeaturesTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<div class='collapsibleContainer' myTitle='Features'>
    <table class='mGrid'>
        <tr>
            <th>ID</th>
            <th>Display Name</th>
            <th>Description</th>
            <th>Status</th>
            <th>Activate On Default</th>
            <th>Auto Activate In Central Admin</th>
            <th>Hidden</th>
            <th>Scope</th>
        </tr>
        <asp:Repeater ID="FeaturesRepeater" runat="server" />
    </table>
</div>