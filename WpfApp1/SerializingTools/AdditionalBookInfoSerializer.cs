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
                if(streamWriter != null)
                using (JsonTextWriter bookJsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    bookSerializer.Serialize(bookJsonTextWriter, bookVM.Books);
                }
            }
        }
    }

    public static class BookInfoDeserializer<T>
    {
        public static ObservableCollection<T> AdditionalBookInfosDeserialize(T book)
        {
            ObservableCollection<T> bookInfos = new ObservableCollection<T>();
            using (StreamReader streamReader = new StreamReader(@"d:\additionalBookInfos.txt"))
            {
                if (streamReader != null)
                    bookInfos = JsonConvert.DeserializeObject<ObservableCollection<T>>(streamReader.ReadToEnd());
            }

            return bookInfos;
        }
    }
}
