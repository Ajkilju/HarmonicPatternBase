﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HarmonicPatternBase.Services
{
    public class Pinger
    {
        private static string m_pingUrl;
        private static int m_pingInterval;

        private static void PingSite()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMinutes(m_pingInterval));

                try
                {
                    GetSiteContent(m_pingUrl);
                }
                catch (Exception) { } // w razie niepowodzenia
            }
        }
        public static void StartPinging(string url, int minutes)
        {
            m_pingUrl = url;
            m_pingInterval = minutes;
            Thread t = new Thread(new ThreadStart(PingSite));
            //t.Priority = ThreadPriority.BelowNormal;
            t.Start();
        }

        private static void GetSiteContent(string url)
        {
            HttpClient client = new HttpClient();
            var html = client.GetStringAsync(url);
        }
    }
}
