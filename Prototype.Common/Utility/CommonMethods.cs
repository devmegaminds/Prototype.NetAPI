using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Prototype.Common.Utility
{
    public static class CommonMethods
    {
        public static string ReadTextFromFile(string stFilePath)
        {
            return System.IO.File.ReadAllText(stFilePath);
        }

        public static bool UpdateTextFromFile(string stFilePath,string JsonString)
        {
            bool IsWrite = false;
            try
            {
                System.IO.File.WriteAllText(stFilePath, JsonString);
                IsWrite = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return IsWrite;
        }
    }
}
