using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using CommonServices.Utility.IUtilityServices;

namespace CommonServices.Utility.UtilityServices
{
    public class Utils : IUtils
    {
        public IntPtr ArrayToIntptr(byte[] source)
        {
            if (source == null)
                return IntPtr.Zero;
            unsafe
            {
                fixed (byte* point = source)
                {
                    IntPtr ptr = new IntPtr(point);
                    return ptr;
                }
            }
        }

        public long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }


        public long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long freeSpace = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return freeSpace;
        }


        public bool CheckCapacityMoreThanLimit(string dir, int limit)
        {
            if (dir != null && dir.Length > 0)
            {
                char[] disks = new char[] { 'C', 'D', 'E', 'F', 'G', 'H' };
                if (disks.Contains((char)dir[0]))
                {
                    return GetHardDiskFreeSpace(dir[0].ToString()) > limit;
                }
            }
            return false;
        }
    }
}

