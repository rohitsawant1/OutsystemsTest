﻿<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Blocks\ContactManager\Private\jQueryCookie.ascx.cs" Inherits="ssContactManager.Flows.FlowPrivate.WBlkjQueryCookie,ContactManager" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="osweb" Namespace="OutSystems.HubEdition.WebWidgets" Assembly="OutSystems.HubEdition.WebWidgets" %>
<%@ Assembly Name="OutSystems.WidgetsRuntimeAPI" %>
<%@ Import namespace="ssContactManager" %>
<%# PageStartHook() %><osweb:IfPlaceHolder runat="server"><osweb:If runat="server" visible="<%# if_wt_If4() %>"><osweb:DynamicImage runat="server" id="wt_Image2" anonymous="true" StaticSource="<%# Images.Script_Source() %>" ImageType="Static" StaticPath="<%# AppUtils.Instance.getImagePath(skipSeo: this.Page is OutSystems.HubEdition.RuntimePlatform.Web.IEmailScreen) %>" Height="<%# System.Web.UI.WebControls.Unit.Parse(img_Image2_actualHeight(), System.Globalization.CultureInfo.InvariantCulture) %>" Width="<%# System.Web.UI.WebControls.Unit.Parse(img_Image2_actualWidth(), System.Globalization.CultureInfo.InvariantCulture) %>" alt=""/><osweb:PlaceHolder runat="server"><%# " " %></osweb:PlaceHolder><osweb:Span runat="server" id="wt_InlineExpression5" anonymous="true" class="Text_Note"><%# OutSystems.HubEdition.RuntimePlatform.RuntimePlatformUtils.ExtendedHtmlEncode(expression_InlineExpression5()) %></osweb:Span></osweb:If><osweb:If runat="server" visible="<%# !if_wt_If4() %>"></osweb:If></osweb:IfPlaceHolder><%# PageEndHook() %>