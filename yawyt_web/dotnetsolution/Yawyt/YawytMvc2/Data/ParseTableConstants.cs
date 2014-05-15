
namespace YawytMvc2.Data {
	public sealed class ParseTableConstants {
		private ParseTableConstants() { }

		public const string UserTable_Name = "user";

		public const string UserTable_ColumnName_ObjectId = "objectId";
		public const string UserTable_ColumnName_CreateAt = "createdAt";
		public const string UserTable_ColumnName_UpdatedAt = "updatedAt";
		public const string UserTable_ColumnName_Acl = "ACL";
		public const string UserTable_ColumnName_Score = "score";
		public const string UserTable_ColumnName_TwitterUserName = "twitterUserName";
	}
}