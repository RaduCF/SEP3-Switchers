
using UserAPI.Model;

namespace UserAPI.Mediator
{
    public class ModelManager
    {
        private Client_CSharp client;

        public void RegisterUser(User user)
        {
            client.RegisterUser(user);
        }
    }
}
