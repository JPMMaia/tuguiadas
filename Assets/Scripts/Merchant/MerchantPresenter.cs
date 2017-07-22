using Core;
using Ports;
using State;

namespace Merchant
{
    public class MerchantPresenter : Entity
    {
        public MerchantView MerchantViewPrefab;

        private MerchantView _view;

        public void Present(Inventory playerInventory, PortInventory portInventory)
        {
            _view = Instantiate(MerchantViewPrefab, Application.View.SuperiorCanvas.transform);

            
        }
    }
}
