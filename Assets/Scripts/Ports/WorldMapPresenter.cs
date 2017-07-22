using Core;

namespace Ports
{
    public class WorldMapPresenter : Entity
    {
        public WorldMapModel MapModel
        {
            get { return Application.Model.WorldMap; }
        }
        public WorldMapView MapView
        {
            get { return Application.View.WorldMap; }
        }

        public void Start()
        {
            foreach (var portView in MapView)
            {
                var portModel = MapModel.CreatePort();
                
            }
        }
    }
}
