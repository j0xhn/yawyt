<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<YawytMvc2.ViewModels.QuestionPageViewModel>" %>
<%@ Import Namespace="YawytMvc2.Globals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	YAWYT - Question
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%
		if (Model != null)
		{
			if (Model.CorrectAnswer != null)
			{
				var correctAnswerCookie = new HttpCookie(CookieName.CORRECT_ANSWER, Model.CorrectAnswer.UserName);
				Response.SetCookie(correctAnswerCookie);
			}
		}
	%>

	<script type="text/javascript">
		var _alreadyAnswered = false;
		var _correctAnswer = $.cookie('<%: CookieName.CORRECT_ANSWER %>');
		$.removeCookie('<%: CookieName.CORRECT_ANSWER %>');

		function reset() {
			$('.optionItem').each(function () {
				var rdo = $(this).find('.optionTextRadioButton');
				if (rdo !== null && typeof (rdo) !== 'undefined') {
					$(rdo).prop('checked', false);
				}
			});
		}

		$(function () {
			$('.nextButton').hide();
			$('.nextButton').click(function () {
				var selectedUserName = $('input[name=Answers]:checked', '#frmQuestion').val();
				
				$('#hdnSelectedUserName').val(selectedUserName);
				$('#hdnCorrectAnswerText').val(_correctAnswer);

				$('#frmQuestion').submit();
			});

			$('.optionItem').each(function () {
				$(this).click(function () {
					if (!_alreadyAnswered) {
						_alreadyAnswered = true;

						var rdo = $(this).find('.optionTextRadioButton');
						if (rdo !== null && typeof (rdo) !== 'undefined') {
							$(rdo).prop('checked', true);
						}

						$(this).removeClass('optionCorrect');
						$(this).removeClass('optionIncorrect');

						var userName = $(rdo).attr('value');
						//						alert('userName = ' + userName + ', _correctAnswer = ' + _correctAnswer);
						$(this).addClass((userName === _correctAnswer) ? 'optionCorrect' : 'optionIncorrect');

						$('.nextButton').show();
					}
				});
			});
		});
	</script>

	<div class="headerBar dropShadowDefault">
		<a href="<%: ApplicationStateRepository.GetAppRootRelativePath() %>question/signout">
			<img class="signOutButton backgroundGradientDefault" src="<%: ApplicationStateRepository.GetAppRootRelativePath() %>img/signout@2x.png" />
		</a>
		<img class="headerLogo" src="<%: ApplicationStateRepository.GetAppRootRelativePath() %>img/sign_in_yawyt.png" />
	</div>
	<div class="tweetTitle">Who Tweeted?</div>
	<div class="tweetText">"<%: Model.QuestionModel.Text %>"</div>

	<% using(Html.BeginForm("Next", "Question", FormMethod.Post, new { id = "frmQuestion" })) { %>
		<%: Html.HiddenFor(x => x.SelectedUserName, new { id = "hdnSelectedUserName" })%>
		<%: Html.HiddenFor(x => x.CorrectAnswerText, new { id = "hdnCorrectAnswerText" })%>

		<div class="optionsContainer">
			<% foreach(var answer in Model.Answers){ %>
					<div id="option<%: answer.AnswerNumber %>" class="optionItem">
						<img class="optionImage" src="<%: answer.IconUrl %>" />
						<span class="optionText">
							<%: Html.RadioButtonFor(x => x.Answers, answer.UserName, new { id = "rdoAnswer" + answer.AnswerNumber, @class = "optionTextRadioButton" })%>
							<label for="rdoAnswer<%: answer.AnswerNumber %>"><%: answer.UserName %></label>
						</span>
					</div>
			<% } %>
		</div>
	<% } %>

	<div>
		<div class="scoreBox backgroundGradientDefault dropShadowDefault">
			<div class="scoreBoxTitle">Your Score</div>
			<div class="scoreBoxText"><%: Model.Score %></div>
		</div>
		<div class="nextButton backgroundGradientDefault dropShadowDefault">Next</div>
	</div>
</asp:Content>
