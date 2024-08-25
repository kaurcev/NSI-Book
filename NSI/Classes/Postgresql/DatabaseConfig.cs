namespace NSI.Classes.Postgresql
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string Shema { get; set; }

        public DatabaseConfig() { }

        public DatabaseConfig(string host, string username, string password, string database, string port, string shema)
        {
            Host = host;
            Username = username;
            Password = password;
            Database = database;
            Port = port;
            Shema = shema;
        }
    }
}
