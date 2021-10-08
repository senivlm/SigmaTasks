using System;
namespace Practice
{
    public class MyFile
    {
        public string Path { get; set; }
        public MyFile(string path="")
        {
            Path = path;
        }
        public string GetFileName()
        {
            string result = "";
            string[] temp = Path.Split(@"\");
            try
            {
                result = temp[temp.Length - 1].Remove(temp[temp.Length - 1].LastIndexOf(".")).Replace(" ", "");
            
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public string GetRootFolderName()
        {
            string result = "";
            try
            {
                int index = Path.IndexOf(string.Format(@":"));
                index = Path.IndexOf(string.Format(@"\"), index);
                result = Path.Remove(index + 1);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

    }
}
