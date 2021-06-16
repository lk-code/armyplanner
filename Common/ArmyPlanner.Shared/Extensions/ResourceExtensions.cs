using Windows.ApplicationModel.Resources;

namespace ArmyPlanner.Extensions
{
    internal static class ResourceExtensions
    {
        private static ResourceLoader _resLoader = new ResourceLoader();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public static string GetLocalized(this string resourceKey)
        {
            ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView();
            return resourceLoader.GetString(resourceKey);
        }
    }
}