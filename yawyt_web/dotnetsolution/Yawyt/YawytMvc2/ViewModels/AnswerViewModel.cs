using YawytMvc2.Models;
using YawytMvc2.Globals;

namespace YawytMvc2.ViewModels
{
	public class AnswerViewModel
	{
		private AnswerModel _answer;
		private int _answerNumber;

		public AnswerViewModel() { }

		public AnswerViewModel(AnswerModel answer, int answerNumber)
		{
			_answer = answer;
			_answerNumber = answerNumber;
		}

		public string UserName { get { return _answer == null ? "" : _answer.UserName; } }

		public int AnswerNumber { get { return _answer == null ? -1 : _answerNumber; } }

		public string IconUrl
		{
			get
			{
				switch (_answerNumber)
				{
					case 0: return ApplicationStateRepository.GetAppRootRelativePath() + "img/egg_lightblue.png";
					case 1: return ApplicationStateRepository.GetAppRootRelativePath() + "img/egg_green.png";
					case 2: return ApplicationStateRepository.GetAppRootRelativePath() + "img/egg_darkblue.png";
					case 3: return ApplicationStateRepository.GetAppRootRelativePath() + "img/egg_red.png";
					default: return "";
				}
			}
		}
	}
}