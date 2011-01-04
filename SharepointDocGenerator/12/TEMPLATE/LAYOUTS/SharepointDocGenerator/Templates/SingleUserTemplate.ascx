<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.SingleUserTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<tr>
    <td><%= this.Data.ID.ToString() %></td>
    <td><%= this.Data.Sid %></td>
    <td><%= this.Data.LoginName %></td>
    <td><%= this.ProfileProperty("FirstName") + " " + this.ProfileProperty("LastName") %></td>
    <td><%= this.Data.Email %></td>
    <td><%= this.ProfileProperty("WorkPhone") %></td>
    <td><%= this.ProfileProperty("Department") %></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.IsSiteAdmin ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.IsSiteAuditor ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.IsDomainGroup ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
</tr>