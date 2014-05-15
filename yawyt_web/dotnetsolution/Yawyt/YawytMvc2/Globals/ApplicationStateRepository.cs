using System.Configuration;

namespace YawytMvc2.Globals {
	public sealed class ApplicationStateRepository {
		private static string _appRootRelativePath = null;

		public static string GetAppRootRelativePath() {
			if (string.IsNullOrWhiteSpace(_appRootRelativePath)) {
				_appRootRelativePath = ConfigurationManager.AppSettings["appRootRelativePath"];
			}

			return _appRootRelativePath;
		}
	}
}