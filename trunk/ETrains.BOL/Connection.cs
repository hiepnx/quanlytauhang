using System.Configuration;

namespace ETrains.BOL
{
    public class ConnectionController
    {
        private static string _connection;

        public static string GetConnection()
        {
            if (string.IsNullOrEmpty(_connection))
                _connection = Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbTrainEntities"].ConnectionString, true);

            return _connection;
        }
    }
}
