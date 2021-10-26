using System;
using System.Collections.Generic;

namespace Task9
{
    public delegate void LogToFileDelegate(string logPath, string exception, string incorrectLine);
    public delegate void ReplaceProductDelegate(Storage storage, string incorrectLine);
    public delegate bool CompareToEqualityDelegate(object atribute,Product product);
    public delegate void DeleteSpoiledProductsDelegate(Storage storage,string path);
    
}
