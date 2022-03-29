/*  
    20/03/2022 Brayan Villa  
*/

using System.IO;
using System.Diagnostics;
using System.Threading;
using Renci.SshNet;

public class RenciSshNetClass
{
    public string SSH(string Comando)
    {

        SshClient Ssh = new SshClient("127.0.0.1", "root", "alpine");



        try
        {

            if(!Ssh.IsConnected)
            {

                Ssh.Connect();

                Ssh.CreateCommand("mount -o rw,union,update /").Execute();

            }

             Ssh.CreateCommand("mount -o rw,union,update /").Execute();

            SshCommand command = Ssh.CreateCommand(Comando);

            var Asynch = command.BeginExecute();

            var Result = command.EndExecute(Asynch);

            return Result;
        }

        catch
        {

            return "";

        }

    }

    public void SEND(string Local, string Remote)
    {

        ScpClient Scp = new ScpClient("127.0.0.1", "root", "alpine");

        try
        {

            if(!Scp.IsConnected)
            {

                Scp.Connect();
            }

            Scp.Upload(new FileInfo(Local), Remote);

        }

        catch
        {


        }

    }
}
