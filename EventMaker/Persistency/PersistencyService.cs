using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using EventMaker.Model;
using Newtonsoft.Json;
using WinUX.Messaging.Dialogs;

namespace EventMaker.Persistency
{
     public class PersistencyService
    {

        private static string jsonFileName = "Events.json";

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string eventsJsonString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(eventsJsonString, jsonFileName);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(jsonFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

       
            bool isItAvailable = true;
      

            while (isItAvailable)
            {
                if (localFile.IsAvailable == true)
                {
                    isItAvailable = false;
                }

            }

            if (localFile.IsAvailable)
            {
                await FileIO.WriteTextAsync(localFile, eventsString);
            }

        }

        public static async Task<string> DeSerializeEventsFileAsync(string FileName)
        {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(FileName);
                return await FileIO.ReadTextAsync(localFile);
        }

     }

}
