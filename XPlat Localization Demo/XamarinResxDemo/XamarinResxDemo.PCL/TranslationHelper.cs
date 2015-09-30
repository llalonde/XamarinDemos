using System.Globalization;
using System.Resources;
using System.Reflection;

namespace XamarinResxDemo.PCL
{
    public static class TranslationHelper
    {

        public static string GetString(string key, CultureInfo ci)
        {
            ResourceManager temp = new ResourceManager("XamarinResxDemo.PCL.Resources.AppResources",
                typeof(AppResources).GetTypeInfo().Assembly);

            string result = temp.GetString(key, ci);

            return result;
        }
    }

}
