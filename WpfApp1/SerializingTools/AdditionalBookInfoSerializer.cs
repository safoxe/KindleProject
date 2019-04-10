using Newtonsoft.Json;
using KindleReader.ViewModel;
using System.IO;
using KindleReader.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace KindleReader.SerializingTools
{
    public static class AdditionalBookInfoSerializer
    { 
        public static void AdditionalBookInfosSerialize(BookVM bookVM)
        {
            JsonSerializer bookSerializer = new JsonSerializer();
            bookSerializer.NullValueHandling = NullValueHandling.Include;

            using (StreamWriter streamWriter = new StreamWriter(@"d:\additionalBookInfos.txt"))
            {
                using (JsonTextWriter bookJsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    bookSerializer.Serialize(bookJsonTextWriter, bookVM.Books);
                }
            }
        }
        public static ObservableCollection<AdditionalBookInfo> AdditionalBookInfosDeserialize() 
        {

            ObservableCollection<AdditionalBookInfo> bookInfos = new ObservableCollection<AdditionalBookInfo>();
            using (StreamReader streamReader = new StreamReader(@"d:\additionalBookInfos.txt"))
            {
                bookInfos = JsonConvert.DeserializeObject<ObservableCollection<AdditionalBookInfo>>(streamReader.ReadToEnd());
            }
            
            return bookInfos;             
        }
    }
}
