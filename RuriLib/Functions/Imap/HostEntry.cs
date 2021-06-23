﻿namespace RuriLib.Functions.Imap
{
    public class HostEntry
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public HostEntry(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
