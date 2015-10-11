﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class AppGlobal
    {
        private static AppGlobal _instance;

        private List<Client> clients;
        private List<string> wordList;
        private List<Tuple<string, string>> chatMessages;

        //Create's static instance of AppGlobal
        public static AppGlobal Instance
        {
            get { return _instance ?? (_instance = new AppGlobal()); }
        }

        public AppGlobal()
        {
            clients = new List<Client>();
            wordList = JsonConverter.SetWordList();
            chatMessages = new List<Tuple<string, string>>();
        }

        // :::LEGACY::: Used to convert a wordlist to JSON
        /*private void fullWordList()
        {
            File.WriteAllText(Environment.CurrentDirectory + @"..\..\..\Resource\WordList.json", JsonConvert.SerializeObject(File.ReadAllText(Environment.CurrentDirectory + @"..\..\..\Resource\words.txt").Split(',').ToList()));
        }*/

        public string GetWord()
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, wordList.Count - 1);
            return wordList.ElementAt(randomIndex);
        }

        public List<Tuple<string, string>> GetChat()
        {
            return chatMessages;
        }

        public void AddChatMessage(string name, string message)
        {
            chatMessages.Add(new Tuple<string, string>(name, message));
        }

        public List<Client> GetClients()
        {
            return clients;
        }

        public void AddUser(Client client)
        {
            clients.Add(client);
        }

        public void RemoveUser(Client c)
        {
            foreach (Client client in clients)
            {
                if(client.Equals(c))
                {
                    clients.Remove(client);
                }
            }
        }


    }
}
