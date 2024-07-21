// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using BackUp_01;

try
{
    Console.WriteLine("Hello, World!");

    DriveInfo[] drives = DriveInfo.GetDrives();

    Console.WriteLine(drives);

    DriveInfo driveBACKUP_1;
    DriveInfo driveBACKUP_2;
    Dictionary<string, DirectoryInfo> dir1 = [];
    Dictionary<string, DirectoryInfo> dir2 = [];

    foreach (var item in drives.ToList())
    {
        if(item.IsReady)
        {
            if (item.VolumeLabel == "BACKUP_1")
            {
                driveBACKUP_1 = item;
            }
            if (item.VolumeLabel == "BACKUP_2")
            {
                driveBACKUP_2 = item;
            }
        }
    }




    Console.WriteLine(  );
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

