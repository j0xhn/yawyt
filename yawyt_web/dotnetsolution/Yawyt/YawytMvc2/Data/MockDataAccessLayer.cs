
namespace YawytMvc2.Data {
	public class MockDataAccessLayer : IDataAccessLayer {
		private readonly string MOCK_USER_ID = "someObjectId";
		private const string MOCK_USER_NAME = "mockturtle";
		private const string MOCK_PASSWORD = "P@ssw0rd";

		public Models.UserModel GetUserByUserName(string userName) {
			return new Models.UserModel {
				Id = MOCK_USER_ID,
				TwitterPassword = MOCK_PASSWORD,
				TwitterUserName = MOCK_USER_NAME
			};
		}

		public void UpdateUserScore(string userId, int score) {
			//Do nothing, since this is a mock class
		}
	}
}