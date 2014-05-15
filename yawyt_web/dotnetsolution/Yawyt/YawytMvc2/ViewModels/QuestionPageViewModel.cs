using System.Collections.Generic;
using System.Linq;
using YawytMvc2.Models;

namespace YawytMvc2.ViewModels
{
	public class QuestionPageViewModel
	{
		private QuestionModel _question;

		public QuestionPageViewModel() { }

		public QuestionPageViewModel(QuestionModel question)
		{
			_question = question;

			this.Answers = new List<AnswerViewModel>();
			foreach (var answer in question.Answers)
			{
				this.Answers.Add(new AnswerViewModel(answer, question.Answers.IndexOf(answer)));
			}
		}

		public QuestionModel QuestionModel { get { return _question; } }

		public List<AnswerViewModel> Answers { get; private set; }

		public AnswerViewModel CorrectAnswer
		{
			get
			{
				return
					Answers == null ?
					null :
					Answers.Where(x => x.UserName.ToLower().Trim() == _question.QuestionUserName.ToLower().Trim()).FirstOrDefault();
			}
		}

		/// <summary>
		/// This property is to be used only for retrieving values from the view.
		/// Do not rely on it to get the text from the CorrectAnswer property.
		/// </summary>
		public string CorrectAnswerText { get; set; }

		public int Score { get; set; }

		public string SelectedUserName { get; set; }
	}
}