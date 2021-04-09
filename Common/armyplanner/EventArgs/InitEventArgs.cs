using Xamarin.Forms;

namespace armyplanner.EventArgs
{
    public class InitEventArgs : System.EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public INavigation Navigation { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public InitEventArgs()
        {

        }
    }
}