﻿using Newtonsoft.Json;
using System;

namespace DTC.Utilities
{
    public class WaypointCaptureData
    {
        public bool upload;
        public bool resetAllPP;
        public bool resetAllSmart;
        public WaypointCaptureWptData[] data;
    }

    public class WaypointCaptureWptData
    {
        public string latitude;
        public string longitude;
        public string elevation;
        public bool target;
        public string route;
        public bool pp;
        public int ppStation;
        public int ppNumber;
        public bool smart;
        public string smartStation;
    }

    public class DataReceiver2
    {
        public static event Action<WaypointCaptureData> DataReceived;

        private static UDPSocket2 socket = new UDPSocket2();
        private static bool running = false;

        public static void Start()
        {
            if (running) return;

            socket.StartReceiving("127.0.0.1", 43002, (string s) =>
            {
                var d = JsonConvert.DeserializeObject<WaypointCaptureData>(s);
                DataReceived?.Invoke(d);
            });

            running = true;
        }

        public static void Stop()
        {
            socket.Stop();
            running = false;
        }
    }
}