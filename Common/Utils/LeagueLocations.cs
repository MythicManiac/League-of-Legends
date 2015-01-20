﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeagueCommon.Utils
{
    public static class LeagueLocations
    {
        public static string GetArchivePath(string leaguePath)
        {
            return string.Format(leaguePath + @"RADS\projects\lol_game_client\filearchives\");
        }

        public static string GetManifestPath(string leaguePath)
        {
            string manifestDir = string.Format(leaguePath + @"RADS\projects\lol_game_client\releases\");
            string[] directories = Directory.GetDirectories(manifestDir);
            int currentResult = 0;
            int[] currentVersion = new int[4];

            for(int i = 0; i < directories.Length; i++)
            {
                string folder = directories[i].Substring(directories[i].LastIndexOf('\\') + 1);
                string[] version = folder.Split('.');
                for(int j = 0; j < version.Length; j++)
                {
                    if (Convert.ToInt32(version[j]) < currentVersion[j])
                        break;

                    if(Convert.ToInt32(version[j]) > currentVersion[j])
                    {
                        currentResult = i;
                        for (int k = 0; k < version.Length; k++)
                        {
                            currentVersion[k] = Convert.ToInt32(version[k]);
                        }
                        break;
                    }
                }
            }
            return directories[currentResult] + @"\releasemanifest";
        }
    }
}