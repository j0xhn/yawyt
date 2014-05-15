using System;
using System.Configuration;

namespace YawytMvc2.Data {
	public class DataAccessLayerFactory {
		public static IDataAccessLayer GetDataAccessLayer() {
			//Instantiate the implementation of IDataAccessLayer specified in the web.config file and return it
			var dataAccessLayerClassName = ConfigurationManager.AppSettings["dataAccessLayerClassName"];

			if (string.IsNullOrWhiteSpace(dataAccessLayerClassName)) {
				throw new Exception("No class name found for data access layer.");
			}

			var dataAccessLayerType = Type.GetType(dataAccessLayerClassName);
			var dataAccessLayer = (IDataAccessLayer)Activator.CreateInstance(dataAccessLayerType);

			return dataAccessLayer;
		}
	}
}