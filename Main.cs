using Life;
using UnityEngine;
using Life.UI;
using Life.Network;
using ModKit.Helper;
using System.Collections.Generic;
using System;
using ModKit.Interfaces;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Main
{
    public class PlayerData
    {
        public int PlayerId { get; set; }
        public int PinCode { get; set; }
    }

    public class PlayerDatabase
    {
        private readonly string dbPath = "playerData.json";
        private List<PlayerData> players;

        public PlayerDatabase()
        {
            if (File.Exists(dbPath))
            {
                var json = File.ReadAllText(dbPath);
                players = string.IsNullOrWhiteSpace(json)
                    ? new List<PlayerData>()
                    : JsonConvert.DeserializeObject<List<PlayerData>>(json) ?? new List<PlayerData>();
            }
            else
            {
                players = new List<PlayerData>();
            }
        }
