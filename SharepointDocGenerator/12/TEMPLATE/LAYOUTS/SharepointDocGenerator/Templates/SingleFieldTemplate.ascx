<%@ Assembly Name="SharepointDocGenerator, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=9d2509254a3c55f6" %>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="SharepointDocGenerator.Code.SingleFieldTemplate" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="SharepointDocGenerator.Code" %>

<tr>
    <td><%= this.Data.Id.ToString() %></td>
    <td><%= this.Data.Title %></td>
    <td><%= this.Data.Type.ToString() %></td>
    <td><%= this.Data.Group %></td>
    <td><%= this.Data.StaticName %></td>
    <td><%= this.Data.InternalName %></td>
<% if (this.Data is SPFieldChoice) { %>
    <td><%= this.Data.Description %><ul><li>
<%
    SPFieldChoice c = this.Data as SPFieldChoice;
    string[] strings = new string[c.Choices.Count];
    c.Choices.CopyTo(strings, 0);
    Response.Write(String.Join("</li><li>", strings));
%>    
    </li></ul></td>
<% } else { %>
    <td><%= this.Data.Description %></td>
<% } %>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.ReadOnlyField ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Required ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Hidden ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Sealed ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Sortable ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.Indexed ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td align="center"><img border='0' src='/_layouts/SharepointDocGenerator/Images/<%= this.Data.UsedInWebContentTypes ? Constants.ImageTrue : Constants.ImageFalse %>' /></td>
    <td><%= this.Data.Scope %></td>
</tr>