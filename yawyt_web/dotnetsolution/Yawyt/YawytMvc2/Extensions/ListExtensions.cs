using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace YawytMvc2.Extensions {
	public static class ListExtensions {
		/// <summary>
		/// Randomizes the order of items in the specified list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <remarks>
		/// This code is based on that provided by "grenade" at: http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
		/// </remarks>
		public static void Shuffle<T>(this IList<T> list) {
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			int n = list.Count;
			while (n > 1) {
				byte[] box = new byte[1];
				do provider.GetBytes(box);
				while (!(box[0] < n * (Byte.MaxValue / n)));
				int k = (box[0] % n);
				n--;
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}