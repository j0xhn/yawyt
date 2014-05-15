using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using YawytMvc2.Data;
using YawytMvc2.Extensions;
using YawytMvc2.Globals;
using YawytMvc2.Models;
using YawytMvc2.Twitter;
using YawytMvc2.Twitter.JsonTypes;
using YawytMvc2.ViewModels;

namespace YawytMvc2.Controllers {
	public class QuestionController : Controller {
		public ActionResult Index() {
			//Make sure we don't get here if we're not signed in
			if (UserStateRepository.User == null) {
				return RedirectToAction("Index", "SignIn");
			}
			
			//Load up some random question data and display it
			var questionPageViewModel = SetUpQuestionPageViewModel();
			return View(questionPageViewModel);
		}

		public ActionResult SignOut() {
			UserStateRepository.SignUserOut();
			return RedirectToAction("Index", "SignIn");
		}

		[HttpPost]
		public ActionResult Next(QuestionPageViewModel model) {
			var selectedUserName = model.SelectedUserName;

			var correctAnswer = model.CorrectAnswerText;
			if (correctAnswer.ToLower().Trim() == selectedUserName.ToLower().Trim()) {
				//Persist the new score in memory and to the data store
				UserStateRepository.User.Score++;

				var dataAccessLayer = DataAccessLayerFactory.GetDataAccessLayer();
				dataAccessLayer.UpdateUserScore(UserStateRepository.User.Id, UserStateRepository.User.Score);
			}

			//Load up some random question data and display it
			var questionPageViewModel = SetUpQuestionPageViewModel();
			questionPageViewModel.Score = UserStateRepository.User.Score;
			return View("Index", questionPageViewModel);
		}

		private QuestionPageViewModel SetUpQuestionPageViewModel() {
			const int MAX_FOLLOWEES_TO_USE_FOR_ANSWERS = 4;
			const int MAX_TWEETS_TO_RETRIEVE_FOR_FOLLOWEE = 50;
			const int MAX_FOLLOWEES_TO_RETRIEVE_FOR_USER = 100;

			string screenName = UserStateRepository.User.TwitterUserName;
			string friendsListUrlFormat = ConfigurationManager.AppSettings["twitterFriendsListUrlFormat"];

			try {
				var twitterHelper = UserStateRepository.GetTwitterHelper();

				//Get a list of followees (called "friends" in the API) to work with
				var friendsListRequestSettings = new FriendsListRequestSettings {
					ScreenName = screenName,
					Count = MAX_FOLLOWEES_TO_RETRIEVE_FOR_USER,
					IncludeUserEntities = false,
					SkipStatus = true,
					RequestUrlFormat = friendsListUrlFormat
				};

				var friendsListJson = twitterHelper.GetFriendsListJson(friendsListRequestSettings);
				var friendsListItems = JsonConvert.DeserializeObject<FriendsList>(friendsListJson);

				//If user does not have at least four followees, he can't play
				if (friendsListItems == null || friendsListItems.Users == null || friendsListItems.Users.Count == 0) {
					//todo: Handle this exception somewhere up the call stack
					throw new Exception("You must be following at least four people to play.");
				}

				//Randomly select four distinct followees
				int followeesCount = friendsListItems.Users.Count;
				var randomFollowees = new List<User>();

				Random random = new Random();

				for (int i = 0; i < MAX_FOLLOWEES_TO_USE_FOR_ANSWERS; i++) {
					bool distinctRandomUserFound = false;
					while (!distinctRandomUserFound) {
						int randomIndex = random.Next(0, followeesCount);
						var followee = friendsListItems.Users[randomIndex];
						if (!randomFollowees.Contains(followee)) {
							randomFollowees.Add(followee);
							distinctRandomUserFound = true;
						}
					}
				}

				//Randomly choose one of the random followees to be the one with the correct answer
				int randomIndexForCorrectAnswerFollowee = random.Next(0, MAX_FOLLOWEES_TO_USE_FOR_ANSWERS);
				var correctAnswerFollowee = randomFollowees[randomIndexForCorrectAnswerFollowee];
				var questionModel = new QuestionModel {
					Answers = new List<AnswerModel>(),
					QuestionUserName = correctAnswerFollowee.ScreenName
				};

				//Get a random tweet from the "correct" followee and add it to the question model
				string randomTweetForCorrectAnswerFollowee = GetRandomTweetForUser(correctAnswerFollowee.ScreenName, MAX_TWEETS_TO_RETRIEVE_FOR_FOLLOWEE);
				questionModel.Text = randomTweetForCorrectAnswerFollowee;

				//Set up the list of answers (followees' screen names) and randomize their order
				questionModel.Answers = randomFollowees.Select(x => new AnswerModel { UserName = x.ScreenName }).ToList();
				questionModel.Answers.Shuffle();

				//Package it all up in a QuestionPageViewModel
				var questionPageViewModel = new QuestionPageViewModel(questionModel) {
					Score = UserStateRepository.User.Score
				};

				return questionPageViewModel;
			}
			catch (Exception ex) {
				Console.WriteLine(ex.ToString());
				throw ex;
			}
		}

		private string GetRandomTweetForUser(string screenName, int maxTweets) {
			string result = string.Empty;

			var twitterHelper = UserStateRepository.GetTwitterHelper();

			var random = new Random();

			string timeLineUrlFormat = ConfigurationManager.AppSettings["twitterTimeLineUrlFormat"];

			var timeLineRequestSettings = new TimeLineRequestSettings {
				Count = maxTweets,
				ExcludeReplies = true,
				IncludeRts = true,
				RequestUrlFormat = timeLineUrlFormat,
				ScreenName = screenName,
				TrimUser = true
			};

			var timeLineJson = twitterHelper.GetTimelineJson(timeLineRequestSettings);
			var timeLineItems = JsonConvert.DeserializeObject<List<TimeLine>>(timeLineJson);

			if (timeLineItems == null || timeLineItems.Count == 0) {
				result = string.Empty;
			}
			else if (timeLineItems.Count == 1) {
				result = timeLineItems[0].Text;
			}
			else {
				int randomIndexForTimeLineItem = random.Next(0, timeLineItems.Count);
				var randomTimeLineItem = timeLineItems[randomIndexForTimeLineItem];
				result = randomTimeLineItem.Text;
			}

			return result;
		}
	}
}
