
using WebSupport.DataEntities;

namespace WebSupport.Account
{
    public class Account
    {
        public static User currentUser { get; set; }
        public static bool isAuthorized { get; set; } = false;
    }
}
