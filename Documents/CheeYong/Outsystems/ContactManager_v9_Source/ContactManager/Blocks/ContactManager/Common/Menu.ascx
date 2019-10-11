﻿<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Blocks\ContactManager\Common\Menu.ascx.cs" Inherits="ssContactManager.Flows.FlowCommon.WBlkMenu,ContactManager" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="osweb" Namespace="OutSystems.HubEdition.WebWidgets" Assembly="OutSystems.HubEdition.WebWidgets" %>
<%@ Assembly Name="OutSystems.WidgetsRuntimeAPI" %>
<%@ Import namespace="ssContactManager" %>
<%@ Register TagPrefix="widgets" TagName="KR5jTByrm4ESUvnM__9raCw" Src="..\..\ContactManager\RichWidgets\Container_Round.ascx" %>
<%# PageStartHook() %><osweb:Container runat="server" id="wt_Container5" anonymous="true" onDataBinding="cnt_Container5_onDataBinding" cssClass="Menu_Container"><osweb:Container runat="server" id="wt_Container3" anonymous="true" onDataBinding="cnt_Container3_onDataBinding" cssClass="Menu_TopMenus"><osweb:Container runat="server" id="wt_Container7" anonymous="true" onDataBinding="cnt_Container7_onDataBinding" cssClass="Menu_TopMenu"><osweb:HyperLink runat="server" id="wt_Link9" Visible="<%# lnk_Link9_isVisible() %>" Enabled="<%# lnk_Link9_isEnabled() %>" NavigateUrl="<%# lnk_Link9_NavigateUrl() %>"><osweb:PlaceHolder runat="server"><%# OutSystems.HubEdition.RuntimePlatform.RuntimePlatformUtils.ExtendedHtmlEncode(expression_InlineExpression6()) %></osweb:PlaceHolder></osweb:HyperLink></osweb:Container></osweb:Container></osweb:Container><osweb:IfPlaceHolder runat="server"><osweb:If runat="server" visible="<%# if_wt_If4() %>"></osweb:If><osweb:If runat="server" visible="<%# !if_wt_If4() %>"><widgets:KR5jTByrm4ESUvnM__9raCw runat="server" id="wt_WebBlockInstance1" OnEvaluateParameters="webBlck_WebBlockInstance1_onDataBinding" InstanceID="_WebBlockInstance1"></widgets:KR5jTByrm4ESUvnM__9raCw></osweb:If></osweb:IfPlaceHolder><%# PageEndHook() %>