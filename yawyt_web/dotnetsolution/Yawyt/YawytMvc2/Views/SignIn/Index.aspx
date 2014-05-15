<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SignIn.Master" Inherits="System.Web.Mvc.ViewPage<YawytMvc2.Models.SignInModel>" %>
<%@ Import Namespace="YawytMvc2.Globals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    YAWYT - Sign In
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerBar dropShadowDefault">
    </div>
    <img class="signInLogo" src="<%: ApplicationStateRepository.GetAppRootRelativePath() %>img/sign_in_yawyt.png" />
    <div class="signInWithTwitterContainer">
        <span class="signInWithTwitter">sign in with Twitter</span>
    </div>

    <%
		using (Html.BeginForm("SignIn", "SignIn", FormMethod.Post)) {
			Html.ValidationSummary(true, "Log-in failed.");
	%>
			<div>
				<fieldset>
					<div class="customErrorMessageContainer">
						<%: Html.ValidationMessage("CustomError") %>
					</div>
					<div class="signInTextEntryContainer">
						<%: Html.ValidationMessageFor(x => x.UserName) %>
						<%: Html.TextBoxFor(x => x.UserName, new { @class="textEntry", placeholder="username" }) %>
					</div>
					<div class="signInTextEntryContainer">
						<%: Html.ValidationMessageFor(x => x.Password) %>
						<%: Html.PasswordFor(x => x.Password, new { @class="textEntry", placeholder="password" }) %>
					</div>

					<button class="signInButton">
						<img src="<%: ApplicationStateRepository.GetAppRootRelativePath() %>img/signin@2x.png" />
					</button>
				</fieldset>
			</div>
	<% } %>
   
</asp:Content>
