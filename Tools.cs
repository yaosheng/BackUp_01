using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUp_01
{
    internal class Tools
    {
        public static List<string> GetALlDirectories(DriveInfo info)
        {
            List<string> finalDirects = new List<string>();
            List<string> directories = Directory.GetDirectories(info.Name).ToList();
            List<string> newDirectories = new List<string>();

            foreach (var item in directories)
            {
                if (!item.Contains("$RECYCLE.BIN") && !item.Contains("System"))
                {
                    newDirectories.Add(item);
                    finalDirects.Add(item);
                }
            }
            //找出所有資料夾(遞迴)
            GetDirectoryInfos(ref finalDirects, newDirectories.ToArray());

            return finalDirects;
        }

        private static void GetDirectoryInfos(ref List<string> dicts, string[] paths)
        {
            List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();

            foreach (var path in paths)
            {
                List<string> directories = Directory.GetDirectories(path).ToList();
                if(directories.Count != 0)
                {
                    foreach (var d in directories) {
                        if (Directory.Exists(d)) {
                            dicts.Add(d);
                        }
                    }
                    GetDirectoryInfos(ref dicts, directories.ToArray());
                }
                else
                {

                }
                Console.WriteLine();
            }
        }
    }
}
