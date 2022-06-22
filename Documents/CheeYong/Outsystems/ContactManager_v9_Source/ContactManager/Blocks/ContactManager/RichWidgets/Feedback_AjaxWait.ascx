﻿<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Blocks\ContactManager\RichWidgets\Feedback_AjaxWait.ascx.cs" Inherits="ssContactManager.Flows.FlowRichWidgets.WBlkFeedback_AjaxWait,ContactManager" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="osweb" Namespace="OutSystems.HubEdition.WebWidgets" Assembly="OutSystems.HubEdition.WebWidgets" %>
<%@ Assembly Name="OutSystems.WidgetsRuntimeAPI" %>
<%@ Import namespace="ssContactManager" %>
<%# PageStartHook() %><osweb:IfPlaceHolder runat="server"><osweb:If runat="server" visible="<%# if_wt_If8() %>"><osweb:DynamicImage runat="server" id="wt_Image3" anonymous="true" StaticSource="<%# Images.Feedback_AjaxWait_Source() %>" ImageType="Static" StaticPath="<%# AppUtils.Instance.getImagePath(skipSeo: this.Page is OutSystems.HubEdition.RuntimePlatform.Web.IEmailScreen) %>" Height="<%# System.Web.UI.WebControls.Unit.Parse(img_Image3_actualHeight(), System.Globalization.CultureInfo.InvariantCulture) %>" Width="<%# System.Web.UI.WebControls.Unit.Parse(img_Image3_actualWidth(), System.Globalization.CultureInfo.InvariantCulture) %>" alt=""/></osweb:If><osweb:If runat="server" visible="<%# !if_wt_If8() %>"><osweb:Container runat="server" id="wtdivWait" onDataBinding="cntdivWait_onDataBinding" cssClass="Feedback_AjaxWait"><osweb:DynamicImage runat="server" id="wt_Image2" anonymous="true" StaticSource="<%# Images.SpinYellow_Source() %>" ImageType="Static" StaticPath="<%# AppUtils.Instance.getImagePath(skipSeo: this.Page is OutSystems.HubEdition.RuntimePlatform.Web.IEmailScreen) %>" Height="<%# System.Web.UI.WebControls.Unit.Parse(img_Image2_actualHeight(), System.Globalization.CultureInfo.InvariantCulture) %>" Width="<%# System.Web.UI.WebControls.Unit.Parse(img_Image2_actualWidth(), System.Globalization.CultureInfo.InvariantCulture) %>" alt=""/><osweb:PlaceHolder runat="server"><%# OutSystems.HubEdition.RuntimePlatform.RuntimePlatformUtils.ExtendedHtmlEncode(Global.GetStringResource("m_9xrKfiOkKNre9xD3HLrg#Value", " Loading...")) %></osweb:PlaceHolder></osweb:Container><osweb:PlaceHolder runat="server"><%# expression_InlineExpression7() %></osweb:PlaceHolder></osweb:If></osweb:IfPlaceHolder><%# PageEndHook() %>