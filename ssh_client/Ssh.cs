using System;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System.Collections.Generic;

namespace ssh_client
{
    public class Ssh
    {
        

        public string Host { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        private ConnectionInfo con;
        PrivateKeyFile keyFile = new PrivateKeyFile(@"", "");
        public Ssh(string _host,string _username="guy",string _password="")
        {
            Host = _host;
            Password = _password;
            Username = _username;
            initConnection();
        }
        private void initConnection()
        {
            var methods = new List<AuthenticationMethod>();
           
            methods.Add(new PrivateKeyAuthenticationMethod(Username, keyFile));
            con= new ConnectionInfo(Host, 22, Username, methods.ToArray());
        }
        public bool UploadFile(string filePath,string outputPath)
        {
            List<string> lis = new List<string>();
            using (SftpClient sftp = new SftpClient(con))
            {
                try
                {
                    sftp.Connect();
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        sftp.UploadFile(fs, outputPath);
                    }
                   
                    sftp.Disconnect();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
            return false;
        }


        public List<string> listFiles(string remoteDirectory) {
            List<string> lis = new List<string>();
            using (SftpClient sftp = new SftpClient(con))
            {
                try
                {
                    sftp.Connect();
               
                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {
                        lis.Add(file.Name);
                    }

                    sftp.Disconnect();
                    return lis;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
            return lis;
        }
        public string WriteCommand(string command) {

            using (SshClient ssh = new SshClient(con))
            {
                try
                {
                    ssh.Connect();
                   return ssh.RunCommand(command).Execute();

                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
                finally {
                    ssh.Disconnect();
                   
                }
                return null;
            }

        }
        



    }
}
