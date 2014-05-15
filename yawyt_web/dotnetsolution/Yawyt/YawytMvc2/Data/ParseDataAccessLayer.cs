using System.Configuration;
using Parse;
using YawytMvc2.Models;

namespace YawytMvc2.Data {
	public class ParseDataAccessLayer : IDataAccessLayer {
		private const string TABLE_NAME_USER = "user";

		private ParseClient GetClient() {
			string appId = ConfigurationManager.AppSettings["parseApplicationId"];
			string restApiKey = ConfigurationManager.AppSettings["parseRestApiKey"];
			string masterKey = ConfigurationManager.AppSettings["parseMasterKey"];

			var client = new ParseClient(appId, restApiKey, masterKey);
			return client;
		}

		public UserModel GetUserByUserName(string userName) {
			var client = GetClient();

			var userRecords = client.GetObjectsWithQuery(TABLE_NAME_USER, new { twitterUserName = userName });
			if (userRecords != null && userRecords.Length > 0) {
				var userRecord = userRecords[0];
				var userModel = new UserModel {
					Id = ParseDataTypeConverter.ToString(userRecord[ParseTableConstants.UserTable_ColumnName_ObjectId]),
					TwitterUserName = ParseDataTypeConverter.ToString(userRecord[ParseTableConstants.UserTable_ColumnName_TwitterUserName]),
					Score = ParseDataTypeConverter.ToInt(userRecord[ParseTableConstants.UserTable_ColumnName_Score]),
					DateLastScored = ParseDataTypeConverter.ToNullableDateTime(userRecord[ParseTableConstants.UserTable_ColumnName_UpdatedAt])
				};

				return userModel;
			}

			return null;
		}

		public void UpdateUserScore(string userId, int score) {
			var client = GetClient();
			
			ParseObject user = new ParseObject(ParseTableConstants.UserTable_Name);
			user[ParseTableConstants.UserTable_ColumnName_ObjectId] = userId;
			user[ParseTableConstants.UserTable_ColumnName_Score] = score;

			client.UpdateObject(user);
		}
	}
}
