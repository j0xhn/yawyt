using YawytMvc2.Models;

namespace YawytMvc2.Data
{
	/// <summary>
	/// An interface used to provide a contract for data access layers.
	/// </summary>
	public interface IDataAccessLayer
	{
		UserModel GetUserByUserName(string userName);
		void UpdateUserScore(string userId, int score);
	}
}
