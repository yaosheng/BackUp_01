// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Collections.Generic;
using BackUp_01;

try
{
    List<string> directoryList1 = [];
    List<string> directoryList2 = [];
    string disk1 = "";
    string disk2 = "";

    DriveInfo[] drives = DriveInfo.GetDrives();

    foreach (var item in drives.ToList())
    {
        if(item.IsReady)
        {
            if (item.VolumeLabel == "BACKUP_1")
            {
                disk1 = item.Name.Substring(0, 1);
                directoryList1 = Tools.GetALlDirectories(item);
            }
            if (item.VolumeLabel == "BACKUP_2")
            {
                disk2 = item.Name.Substring(0, 1);
            }
        }
    }

    #region 處理資料夾
    //將J換成K
    foreach(var item in directoryList1)
    {
        directoryList2.Add(disk2 + item.Substring(1, item.Length - 1));
    }

    foreach(var item in directoryList2)
    {
        if (!Directory.Exists(item))
        {
            Directory.CreateDirectory(item);
        }
    }

    #endregion

    #region 處理檔案
       
    List<string> dataPaths = new List<string>();

    foreach (var item in directoryList1)
    {
        var tmp = Directory.GetFiles(item);
        foreach(var filePath in tmp)
        {
            dataPaths.Add(disk2 + filePath.Substring(1, filePath.Length - 1));
        }
    }

    foreach (var item in dataPaths)
    {
        try
        {
            if (!File.Exists(item))
            {
                string sourcePath = disk1 + item.Substring(1, item.Length - 1);
                File.Copy(sourcePath, item);
            }
        }
        catch(Exception e)
        {
            continue;
        }
    }


    Console.WriteLine(dataPaths);
    #endregion

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

