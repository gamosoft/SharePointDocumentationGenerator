<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.SingleFeatureTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>
<%@ Import Namespace="System.Globalization" %>

<tr>
    <td><%= this.Data.DefinitionId.ToString()%></td>
    <td><%= this.Data.Definition.DisplayName%></td>
    <td><%= this.Data.Definition.GetDescription(CultureInfo.CurrentCulture) %></td>
    <td><%= this.Data.Definition.Status.ToString() %></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Definition.ActivateOnDefault ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Definition.AutoActivateInCentralAdmin ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Definition.Hidden ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td><%= this.Data.Definition.Scope.ToString() %></td>
</tr>