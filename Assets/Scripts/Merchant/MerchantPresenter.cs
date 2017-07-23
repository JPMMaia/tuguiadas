using System.Globalization;
using Core;
using State;

namespace Merchant
{
    public class MerchantPresenter : Entity
    {
        public MerchantView MerchantViewPrefab;
        public ItemView ItemViewPrefab;

        private MerchantView _view;

        public void Present(Inventory playerInventory, Inventory portInventory)
        {
            _view = Instantiate(MerchantViewPrefab, Application.View.SuperiorCanvas.transform);
            _view.ExitButton.onClick.AddListener(OnViewExit);

            FillPlayerInventory(playerInventory);
            FillPortInventory(portInventory);
        }

        public void Update()
        {
            if(_view != null)
                _view.GoldText.text = Application.Model.PlayerState.CurrentMoney.ToString(CultureInfo.InvariantCulture);
        }

        private void FillPlayerInventory(Inventory playerInventory)
        {

        }
        private void FillPortInventory(Inventory portInventory)
        {
            foreach (var item in portInventory)
            {
                var itemView = Instantiate(ItemViewPrefab, _view.PortInventoryContainer.transform);
                itemView.NameText.text = item.Name;
                itemView.MaterialText.text = item.Material;
                itemView.QuantityText.text = item.Quantity.ToString();
                itemView.ValueText.text = item.OriginalPrice.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void OnViewExit()
        {
            Destroy(_view.gameObject);
        }
    }
}
