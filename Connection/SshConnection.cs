using Renci.SshNet;

namespace WebSupport.Connection
{
    public class SshConnection
    {
        private string server = "192.168.25.95";
        string sshUserName = "root";
        string sshPassword = "x897ty";
        string databaseUserName = "your database user name";
        string databasePassword = "your database password";
        SshClient ssh;
        public void OpenConnect(string server, string username, string password)
        {
            if (ssh.IsConnected) return;
            ssh = new SshClient(server, username, password);
            ssh.Connect();
        }

        public void ConnectDB()
        {
            if (ssh.IsConnected)
            {
            }
        }

        public void CloseConnect()
        {
            if (ssh.IsConnected)
            {
                ssh.Disconnect();
                ssh.Dispose();
            }
        }

    }
}
