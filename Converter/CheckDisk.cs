using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Windows;
using System.Windows.Documents;

namespace Converter
{
    class CheckDisk
    {
        //Провекра пользователя на уникальность(в данном случае по номеру HDD)

        public CheckDisk()
        {
            if (GetHardDiskSerialNo() != Properties.Settings.Default.HDD_name)
            {                
                Properties.Settings.Default.Path = 
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Properties.Settings.Default.HDD_name = GetHardDiskSerialNo();                

                Properties.Settings.Default.Save();
            }
        }

        private string GetHardDiskSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();

            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }

            return result;
        }
    }
}
