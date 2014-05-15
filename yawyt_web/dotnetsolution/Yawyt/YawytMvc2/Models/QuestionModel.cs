using System.Collections.Generic;

namespace YawytMvc2.Models
{
	public class QuestionModel
	{
		public string QuestionUserName { get; set; }
		public string Text { get; set; }
		public List<AnswerModel> Answers { get; set; }
	}
}