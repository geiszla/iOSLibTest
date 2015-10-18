using IOSLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iOSLibTest
{
    class Program
    {
        // Uncomment lines to try code
        // feel free to change the code, some of the lines may not work defaultly (because of representative purposes)
        static void Main(string[] args)
        {
            // Searches for devices and connects to them. (22ms, 3ms)
            List<iDevice> devices = iOSLib.GetDevices();            
            devices[0].Connect();
            
            // Sets path to save Photos.sqlite temporarily to (optional, default path: %appdata%\iOSLib). (<1ms)
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            iOSLib.TempFolder = appDataPath + @"\iOSLib";

            // Gets photo list from device (also used for refreshing the list). (3000ms)
            devices[0].GetPhotos();
            // Gets Photos.sqlite from the device (it's included in GetPhotos, so you only have to call it if you want to refresh only the database, not the photo list) (648ms)
            //devices[0].Photos.RefreshDatabase();
            // (Note that all photo properties and functions - except Save, SavePhotos, Remove, RemovePhotos and Restore - depend on the photo list and database got with GetPhotos()
            // if the actual photos or database has changed on the device these functions and properties may not work properly.
            // In this case, please refresh database with RefreshDatabase() or photo list with GetPhotos())

            // Returns the number of photos on the device. (<1ms)
            long photoCount = devices[0].Photos.Count;

            // Gets photo properties from Photos.sqlite either with Photo.GetProperty(string propertyName) (searches only in "ZGENERICASSET" and "ZADDITIONALASSETATTRIBUTES" tables)
            // or with a custom database search: Photos.CustomDatabaseSearch(string tableName, string columnName, string primaryKeyName, string primaryKeyValue) (7ms, 4ms)
            string returnedProperty = devices[0].Photos.PhotoList[0].GetProperty("ZORIGINALHEIGHT");
            string customProperty = devices[0].Photos.CustomDatabaseSearch("Z_PRIMARYKEY", "Z_MAX", "Z_ENT", "1");

            // Checks if photo object already exist on the device
            // (can check either a photo from a device or a user made photo object from the computer). (5ms)
            bool photoExists = devices[0].Photos.Exists(devices[0].Photos.PhotoList[0]);

            // Removes a photo from device (restart Photos.app to see changes) (1000ms)
            //devices[0].Photos.PhotoList.Where(x => x.Name == "IMG_1833").FirstOrDefault().Remove();
            // Removes multiple photos from a device (can remove photos from photolist with photos from multiple devices, restart Photos.app to see changes).
            //List<Photo> removedPhotoList = new List<Photo> { devices[0].Photos.PhotoList[0], devices[0].Photos.PhotoList[1] };
            //devices[0].Photos.RemovePhotos(removedPhotoList);

            // Saves a photo from device to the computer to a specific path along with its basic properties in an xml. (300ms)
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //devices[0].Photos.PhotoList[0].Save(desktopPath);
            // Saves multiple photos from the device to a specific folder along with their basic properties in an xml (can save photos from multiple devices at once).
            //List<Photo> savedPhotoList = devices[0].Photos.PhotoList.Concat(devices[1].Photos.PhotoList).ToList();
            //devices[0].Photos.SavePhotos(savedPhotoList, desktopPath + @"\Saved Photos");

            //devices[0].Photos.Restore(new Photo()); -- Doesn't work yet!!!

            // Disconnects from device and frees all unnecessary variables.
            devices[0].Disconnect();
            
            Console.ReadLine();
        }
    }
}
