using Ports;

namespace Core
{
    public class Model : Entity
    {
        private readonly WorldMapModel _worldMap = new WorldMapModel();
        public WorldMapModel WorldMap
        {
            get { return _worldMap; }
        }
    }
}
