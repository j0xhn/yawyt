using System;

namespace YawytMvc2.Data {
	public sealed class ParseDataTypeConverter {
		private ParseDataTypeConverter() { }

		public static string ToString(object toConvert, string defaultValue = "") {
			try {
				if (toConvert == null) return defaultValue;
				return Convert.ToString(toConvert);
			}
			catch {
				return defaultValue;
			}
		}

		public static int ToInt(object toConvert, int defaultValue = 0) {
			try {
				if (toConvert == null) return defaultValue;
				return Convert.ToInt32(toConvert);
			}
			catch {
				return defaultValue;
			}
		}

		public static DateTime? ToNullableDateTime(object toConvert, DateTime? defaultValue = null) {
			try {
				if (toConvert == null) return defaultValue;
				return Convert.ToDateTime(toConvert);
			}
			catch {
				return defaultValue;
			}
		}

		public static bool ToBool(object toConvert, bool defaultValue = false) {
			try {
				if (toConvert == null) return defaultValue;
				return Convert.ToBoolean(toConvert);
			}
			catch {
				return defaultValue;
			}
		}
	}
}