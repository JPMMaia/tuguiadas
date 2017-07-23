using Ports;
using State;

namespace Core
{
    public class Model : Entity
    {
        public PlayerState PlayerState
        {
            get { return FindObjectOfType<PlayerState>(); }
        }
    }
}
