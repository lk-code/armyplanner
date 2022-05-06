using ArmyPlanner.Pages.Interfaces;

namespace ArmyPlanner.Pages.Services.Message
{
    public class MessageService : IMessageService
    {
        public string GetTextDemo()
        {
            return "Hallo Welt";
        }
    }
}
