using System;

namespace YawytMvc2.Extensions {
	public static class DateExtensions {
		public static long GetSecondsSinceUnixEpoch(this DateTime dateTime) {
			var origin = GetUnixOriginDateTime();
			var difference = dateTime.ToUniversalTime() - origin;
			var seconds = (long)difference.TotalSeconds;

			return seconds;
		}

		public static long GetMillisecondsSinceUnixEpoch(this DateTime dateTime) {
			var origin = GetUnixOriginDateTime();
			var difference = dateTime.ToUniversalTime() - origin;
			var milliseconds = (long)difference.TotalMilliseconds;

			return milliseconds;
		}

		private static DateTime GetUnixOriginDateTime(){
			return new DateTime(1970, 1, 1, 0, 0, 0, 0);
		}
	}
}