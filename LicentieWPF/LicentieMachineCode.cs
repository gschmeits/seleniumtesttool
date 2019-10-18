﻿// ***********************************************************************
// Assembly         : LicentieWPF
// Author           : G.H.M.H. Schmeits
// Created          : 03-07-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 04-17-2018
// ***********************************************************************
// <copyright file="LicentieMachineCode.cs" company="SCHMEITS SOFTWARE">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LicentieWPF.LicenseKey
{
    using System;
    using System.Management;

    /// <summary>
    /// Class LicentieMachineCode.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for LicentieMachineCode
    public static class LicentieMachineCode
    {
        /// <summary>
        /// Gets the machine code.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for getMachineCode
        public static int getMachineCode()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            string collectedInfo = "";
            // here we will put the informa
            foreach (ManagementObject share in searcher.Get())
            {
                // first of all, the processorid
                collectedInfo += share.GetPropertyValue("ProcessorId");
            }

            searcher.Query = new ObjectQuery("select * from Win32_BIOS");
            foreach (ManagementObject share in searcher.Get())
            {
                //then, the serial number of BIOS
                collectedInfo += share.GetPropertyValue("SerialNumber");
            }

            searcher.Query = new ObjectQuery("select * from Win32_BaseBoard");
            foreach (ManagementObject share in searcher.Get())
            {
                //finally, the serial number of motherboard
                collectedInfo += share.GetPropertyValue("SerialNumber");
            }

            // patch luca bernardini
            if (string.IsNullOrEmpty(collectedInfo) | collectedInfo == "00" | collectedInfo.Length <= 3)
            {
                collectedInfo += getHddSerialNumber();
            }

            return getEightByteHash(collectedInfo, 100000);
        }

        /// <summary>
        /// Gets the HDD serial number.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for getHddSerialNumber
        public static string getHddSerialNumber()
        {
            // --- Win32 Disk
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\root\\cimv2", "select * from Win32_DiskPartition WHERE BootPartition=True");

            uint diskIndex = 999;
            foreach (ManagementObject partition in searcher.Get())
            {
                diskIndex = Convert.ToUInt32(partition.GetPropertyValue("Index"));
                break; // TODO: might not be correct. Was : Exit For
            }

            // I haven't found the bootable partition. Fail.
            if (diskIndex == 999)
                return string.Empty;

            // --- Win32 Disk Drive
            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where Index = " + diskIndex.ToString());

            string deviceName = "";
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                deviceName = wmi_HD.GetPropertyValue("Name").ToString();
                break; // TODO: might not be correct. Was : Exit For
            }

            // I haven't found the disk drive. Fail
            if (string.IsNullOrEmpty(deviceName.Trim()))
                return string.Empty;

            // -- Some problems in query parsing with backslash. Using like operator
            if (deviceName.StartsWith("\\\\.\\"))
            {
                deviceName = deviceName.Replace("\\\\.\\", "%");
            }

            // --- Physical Media
            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia WHERE Tag like '" + deviceName + "'");
            string serial = string.Empty;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                serial = wmi_HD.GetPropertyValue("SerialNumber").ToString();
                break; // TODO: might not be correct. Was : Exit For
            }

            return serial;
        }

        /// <summary>
        /// Gets the eight byte hash.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="MUST_BE_LESS_THAN">The must be less than.</param>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for getEightByteHash
        public static int getEightByteHash(string s, int MUST_BE_LESS_THAN = 1000000000)
        {
            //This function generates a eight byte hash

            //The length of the result might be changed to any length
            //just set the amount of zeroes in MUST_BE_LESS_THAN
            //to any length you want
            uint hash = 0;

            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
            {
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            int result = (int)(hash % MUST_BE_LESS_THAN);
            int check = MUST_BE_LESS_THAN / result;

            if (check > 1)
            {
                result *= check;
            }

            return result;
        }
    }
}