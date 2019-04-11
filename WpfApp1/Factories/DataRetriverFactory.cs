using System;
using KindleReader.Services;

namespace KindleReader.Factories
{
    public class DataRetriverFactory
    {
        public static IDataRetriver GetDataRetriever()
        {
            return new DataRetriver();
        }
    }
}
