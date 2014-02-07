using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PNPController
{
    public class RemoteControl
    {
        HttpListener listener = new HttpListener();
        string listeningURL = "http://localhost:8080/";
        public void initRemote()
        {
            listener.Prefixes.Add(listeningURL);
            listener.Start();

            while (listener.IsListening)
            {
                HttpListenerContext context = listener.GetContext();
                try
                {
                    Thread t = new Thread(() =>
                    {
                        var request = context.Request;
                        string text;
                        using (var reader = new StreamReader(request.InputStream,
                                                             request.ContentEncoding))
                        {
                            text = reader.ReadToEnd();
                        }

                        string Mach3Command = "";
                        string[] words = text.Split('&');
                        foreach (string word in words)
                        {
                            if (word.StartsWith("command="))
                            {
                                Mach3Command = word.Replace("command=", "").Replace("+", " ");
                            }

                        }
                        byte[] Buffer = System.Text.Encoding.UTF8.GetBytes("OK" + Environment.NewLine);
                        context.Response.ContentType = "text/html; charset=utf-8";
                        context.Response.OutputStream.Write(Buffer, 0, Buffer.Length);
                        context.Response.Close();
                        //writing the sent message into the console

                        Console.WriteLine("Command: {0}", Mach3Command);
                        Console.ReadLine();
                    });
                    t.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }

        }
    }
}
