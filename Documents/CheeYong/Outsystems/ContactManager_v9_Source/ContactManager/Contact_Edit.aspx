﻿<%@ Page Language="c#" Codebehind="Contact_Edit.aspx.cs" AutoEventWireup="false" Inherits="ssContactManager.Flows.FlowMainFlow.ScrnContact_Edit" %>
<%@ Register TagPrefix="osweb" Namespace="OutSystems.HubEdition.WebWidgets" Assembly="OutSystems.HubEdition.WebWidgets" %>
<%@ Import namespace="ssContactManager" %>
<%@ Import namespace="OutSystems.HubEdition.RuntimePlatform" %>
<%@ Assembly Name="OutSystems.WidgetsRuntimeAPI" %>
<%@ Register TagPrefix="widgets" TagName="K_C9RMY3Tlkmkndhqz4X4nQ" Src="Blocks\ContactManager\Common\Layout_Normal.ascx" %>
<%@ Register TagPrefix="widgets" TagName="KRaaKItBSykuefvtic5G6FQ" Src="Blocks\ContactManager\Common\Menu.ascx" %>

<%= ContactManager_Properties.DocType %>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server"><%= GetHeadTopJavaScript() %>
	<title><%= HttpUtility.HtmlEncode (Title) %></title>
    <meta http-equiv="Content-Type" content="<%= "text/html; charset=" + Response.ContentEncoding.WebName %>" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta http-equiv="Content-Style-Type" content="text/css" />
<%= "\n" + GetStyleSheetIncludes() %><%= GetRequestInfoJavaScript() + GetJavaScriptIncludes() + GetHeadBottomJavaScript() %>
  </head>
  <osweb:Body runat="server"><%= GetBodyTopJavaScript() %>
    <osweb:Form id="WebForm1" method="post"  action="<%# GetFormAction() %>" runat="server">
<widgets:K_C9RMY3Tlkmkndhqz4X4nQ runat="server" id="wt_WebBlockInstance20" OnEvaluateParameters="webBlck_WebBlockInstance20_onDataBinding" InstanceID="_WebBlockInstance20"><phMenu><widgets:KRaaKItBSykuefvtic5G6FQ runat="server" id="wt_WebBlockInstance19" OnEvaluateParameters="webBlck_WebBlockInstance19_onDataBinding" InstanceID="_WebBlockInstance19"></widgets:KRaaKItBSykuefvtic5G6FQ></phMenu><phTitle><osweb:IfPlaceHolder runat="server"><osweb:If runat="server" visible="<%# if_wt_If34() %>"><osweb:PlaceHolder runat="server"><%# "New Contact" %></osweb:PlaceHolder></osweb:If><osweb:If runat="server" visible="<%# !if_wt_If34() %>"><osweb:PlaceHolder runat="server"><%# "Edit &#39;" %></osweb:PlaceHolder><osweb:PlaceHolder runat="server"><%# OutSystems.HubEdition.RuntimePlatform.RuntimePlatformUtils.ExtendedHtmlEncode(expression_InlineExpression11()) %></osweb:PlaceHolder><osweb:PlaceHolder runat="server"><%# "&#39;" %></osweb:PlaceHolder></osweb:If></osweb:IfPlaceHolder></phTitle><phMainContent><osweb:EditRecord runat="server" id="wtContactEdit" class="EditRecord" style="border-spacing: 7px" cellspacing="7" border="0"><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell33" anonymous="true" class="EditRecord_Caption"><osweb:PlaceHolder runat="server"><%# "Name" %></osweb:PlaceHolder></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell25" anonymous="true" class="EditRecord_Value"><osweb:TextBox runat="server" id="wtContact_Name" columns="40" Visible="<%# inputwtContact_Name_isVisible() %>" ReadOnly="<%# !inputwtContact_Name_isEnabled() %>" maxlength="50" OnDefaultMandatoryValidationMessage="GetMandatoryValidatorMsg" OnDefaultTypeValidationMessage="GetTextValidatorMsg" textmode="SingleLine" text="<%# inputwtContact_Name_input_value() %>" onTextChanged="inputwtContact_Name_input_onTextChanged" Mandatory="<%# inputwtContact_Name_isMandatory() %>" parentEditRecord="wtContactEdit"/><osweb:RequiredFieldTextValidator  runat="server" display="Dynamic" id="wtContact_NameValidatorRequired" ErrorMessage="<%# ContactManager_Properties.MandatoryValidatorMsg %>" ControlToValidate="wtContact_Name"/><osweb:TextValidator runat="server" display="Dynamic" id="wtContact_NameValidatorType" ErrorMessage="<%# ContactManager_Properties.TextValidatorMsg %>" ControlToValidate="wtContact_Name" ClientValidationFunction="OsCustomValidatorText"/></osweb:Td></osweb:Tr><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell28" anonymous="true" class="EditRecord_Caption"><osweb:PlaceHolder runat="server"><%# "Job Title" %></osweb:PlaceHolder></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell1" anonymous="true" class="EditRecord_Value"><osweb:TextBox runat="server" id="wtContact_JobTitle" columns="40" Visible="<%# inputwtContact_JobTitle_isVisible() %>" ReadOnly="<%# !inputwtContact_JobTitle_isEnabled() %>" maxlength="50" OnDefaultMandatoryValidationMessage="GetMandatoryValidatorMsg" OnDefaultTypeValidationMessage="GetTextValidatorMsg" textmode="SingleLine" text="<%# inputwtContact_JobTitle_input_value() %>" onTextChanged="inputwtContact_JobTitle_input_onTextChanged" Mandatory="<%# inputwtContact_JobTitle_isMandatory() %>" parentEditRecord="wtContactEdit"/><osweb:RequiredFieldTextValidator  runat="server" display="Dynamic" id="wtContact_JobTitleValidatorRequired" ErrorMessage="<%# ContactManager_Properties.MandatoryValidatorMsg %>" ControlToValidate="wtContact_JobTitle"/><osweb:TextValidator runat="server" display="Dynamic" id="wtContact_JobTitleValidatorType" ErrorMessage="<%# ContactManager_Properties.TextValidatorMsg %>" ControlToValidate="wtContact_JobTitle" ClientValidationFunction="OsCustomValidatorText"/></osweb:Td></osweb:Tr><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell21" anonymous="true" class="EditRecord_Caption"><osweb:PlaceHolder runat="server"><%# "Phone" %></osweb:PlaceHolder></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell7" anonymous="true" class="EditRecord_Value"><osweb:TextBox runat="server" id="wtContact_Phone" columns="20" Visible="<%# inputwtContact_Phone_isVisible() %>" ReadOnly="<%# !inputwtContact_Phone_isEnabled() %>" maxlength="20" OnDefaultMandatoryValidationMessage="GetMandatoryValidatorMsg" OnDefaultTypeValidationMessage="GetPhoneNumberValidatorMsg" textmode="SingleLine" text="<%# inputwtContact_Phone_input_value() %>" onTextChanged="inputwtContact_Phone_input_onTextChanged" Mandatory="<%# inputwtContact_Phone_isMandatory() %>" parentEditRecord="wtContactEdit"/><osweb:RequiredFieldTextValidator  runat="server" display="Dynamic" id="wtContact_PhoneValidatorRequired" ErrorMessage="<%# ContactManager_Properties.MandatoryValidatorMsg %>" ControlToValidate="wtContact_Phone"/><osweb:TextValidator runat="server" display="Dynamic" id="wtContact_PhoneValidatorType" ErrorMessage="<%# ContactManager_Properties.PhoneNumberValidatorMsg %>" ControlToValidate="wtContact_Phone" ClientValidationFunction="OsCustomValidatorPhoneNumber"/></osweb:Td></osweb:Tr><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell40" anonymous="true" class="EditRecord_Caption"><osweb:PlaceHolder runat="server"><%# "Email" %></osweb:PlaceHolder></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell38" anonymous="true" class="EditRecord_Value"><osweb:TextBox runat="server" id="wtContact_Email" columns="40" Visible="<%# inputwtContact_Email_isVisible() %>" ReadOnly="<%# !inputwtContact_Email_isEnabled() %>" maxlength="250" OnDefaultMandatoryValidationMessage="GetMandatoryValidatorMsg" OnDefaultTypeValidationMessage="GetEmailValidatorMsg" textmode="SingleLine" type="email" text="<%# inputwtContact_Email_input_value() %>" onTextChanged="inputwtContact_Email_input_onTextChanged" Mandatory="<%# inputwtContact_Email_isMandatory() %>" parentEditRecord="wtContactEdit"/><osweb:RequiredFieldTextValidator  runat="server" display="Dynamic" id="wtContact_EmailValidatorRequired" ErrorMessage="<%# ContactManager_Properties.MandatoryValidatorMsg %>" ControlToValidate="wtContact_Email"/><osweb:TextValidator runat="server" display="Dynamic" id="wtContact_EmailValidatorType" ErrorMessage="<%# ContactManager_Properties.EmailValidatorMsg %>" ControlToValidate="wtContact_Email" ClientValidationFunction="OsCustomValidatorEmail"/></osweb:Td></osweb:Tr><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell12" anonymous="true" class="EditRecord_Caption"><osweb:PlaceHolder runat="server"><%# "Notes" %></osweb:PlaceHolder></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell45" anonymous="true" class="EditRecord_Value"><osweb:TextBox runat="server" id="wtContact_Notes" columns="40" Visible="<%# inputwtContact_Notes_isVisible() %>" ReadOnly="<%# !inputwtContact_Notes_isEnabled() %>" maxlength="500" onchange="OsLimitInput(this,event,500);" onkeyup="OsLimitInput(this,event,500);" OnDefaultMandatoryValidationMessage="GetMandatoryValidatorMsg" OnDefaultTypeValidationMessage="GetTextValidatorMsg" textmode="MultiLine" rows="2" text="<%# inputwtContact_Notes_input_value() %>" onTextChanged="inputwtContact_Notes_input_onTextChanged" Mandatory="<%# inputwtContact_Notes_isMandatory() %>" parentEditRecord="wtContactEdit"/><osweb:RequiredFieldTextValidator  runat="server" display="Dynamic" id="wtContact_NotesValidatorRequired" ErrorMessage="<%# ContactManager_Properties.MandatoryValidatorMsg %>" ControlToValidate="wtContact_Notes"/><osweb:TextValidator runat="server" display="Dynamic" id="wtContact_NotesValidatorType" ErrorMessage="<%# ContactManager_Properties.TextValidatorMsg %>" ControlToValidate="wtContact_Notes" ClientValidationFunction="OsCustomValidatorText"/></osweb:Td></osweb:Tr><osweb:Tr runat="server"><osweb:Td runat="server" id="wt_EditRecordCell22" anonymous="true" class="EditRecord_Caption"></osweb:Td><osweb:Td runat="server" id="wt_EditRecordCell17" anonymous="true" class="EditRecord_Value"><osweb:Button runat="server" id="wt_Button26" onDataBinding="btn_Button26_onDataBinding" cssClass="Button Is_Default" Visible="<%# btn_Button26_isVisible() %>" Enabled="<%# btn_Button26_isEnabled() %>" CausesValidation="false" parentEditRecord="wtContactEdit" text="<%# btn_Button26_getLabel() %>"/><osweb:PlaceHolder runat="server"><%# "or " %></osweb:PlaceHolder><osweb:HyperLink runat="server" id="wt_Link32" Visible="<%# lnk_Link32_isVisible() %>" Enabled="<%# lnk_Link32_isEnabled() %>" NavigateUrl="<%# lnk_Link32_NavigateUrl() %>" parentEditRecord="wtContactEdit"><osweb:PlaceHolder runat="server"><%# "Cancel" %></osweb:PlaceHolder></osweb:HyperLink></osweb:Td></osweb:Tr></osweb:EditRecord></phMainContent><phActions></phActions></widgets:K_C9RMY3Tlkmkndhqz4X4nQ><osweb:DummySubmitLink runat="server" id="Dummy_Submit_Link"/>
    <%= OutSystems.HubEdition.RuntimePlatform.AppInfo.GetAppInfo().GetWatermark() %><%= GetCallbackDebug()	
%><%= GetVisitCode() %></osweb:Form><%= GetEndPageJavaScript() + GetBodyBottomJavaScript() %>
  </osweb:Body>
</html>
