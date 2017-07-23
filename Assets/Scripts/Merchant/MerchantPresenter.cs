using System.Globalization;
using Core;
using Ports;
using State;

namespace Merchant
{
    public class MerchantPresenter : Entity
    {
        public MerchantView MerchantViewPrefab;
        public ItemView ItemViewPrefab;

        private ItemView _selectedItemView;
        private ItemView SelectedItemView
        {
            get
            {
                return _selectedItemView;
            }
            set
            {
                if (_selectedItemView != null)
                    _selectedItemView.Selected = false;

                _selectedItemView = value;

                if (_selectedItemView != null)
                    _selectedItemView.Selected = true;
            }
        }

        private MerchantView _view;
        private Culture _portCulture;
        private Inventory _playerInventory;
        private Inventory _portInventory;

        public void Present(Culture portCulture, Inventory playerInventory, Inventory portInventory)
        {
            _portCulture = portCulture;
            _playerInventory = playerInventory;
            _portInventory = portInventory;

            _view = Instantiate(MerchantViewPrefab, Application.View.SuperiorCanvas.transform);
            _view.SellButton.onClick.AddListener(OnSellClick);
            _view.BuyButton.onClick.AddListener(OnBuyClick);
            _view.ExitButton.onClick.AddListener(OnViewExit);
            _view.BuyFoodButton.onClick.AddListener(OnBuyFoodClicked);
            _view.HealCrewButton.onClick.AddListener(OnHealCrewClicked);
            _view.BuyAmmoButton.onClick.AddListener(OnBuyAmmoClicked);

            FillPlayerInventory(playerInventory);
            FillPortInventory(portInventory);
        }

        public void OnBuyFoodClicked()
        {
            var playerState = FindObjectOfType<PlayerState>();
            if (!(playerState.CurrentMoney >= 100.0f)) return;

            playerState.Food = playerState.FoodCapacity;
            playerState.CurrentMoney -= 100.0f;
        }

        public void OnHealCrewClicked()
        {
            var playerState = FindObjectOfType<PlayerState>();
            if (!(playerState.CurrentMoney >= 100.0f)) return;

            playerState.CrewHealth = playerState.CrewMaxHealth;
            playerState.CurrentMoney -= 100.0f;
        }

        public void OnBuyAmmoClicked()
        {
            var playerState = FindObjectOfType<PlayerState>();
            if (!(playerState.CurrentMoney >= 100.0f)) return;

            playerState.Ammo = playerState.AmmoCapacity;
            playerState.CurrentMoney -= 100.0f;
        }

        public void Update()
        {
            if (_view != null)
                _view.GoldText.text = Application.Model.PlayerState.CurrentMoney.ToString(CultureInfo.InvariantCulture);
        }

        private void FillPlayerInventory(Inventory playerInventory)
        {
            foreach (var item in playerInventory)
            {
                var itemView = Instantiate(ItemViewPrefab, _view.PlayerInventoryContainer.transform);
                itemView.Item = item;
                itemView.NameText.text = item.Name;
                itemView.MaterialText.text = item.Material;
                itemView.QuantityText.text = item.Quantity.ToString();
                itemView.ValueText.text = item.CalculateSellPrice(_portCulture).ToString(CultureInfo.InvariantCulture);
                itemView.Button.onClick.AddListener(() => { OnItemViewClicked(itemView); });
            }
        }
        private void FillPortInventory(Inventory portInventory)
        {
            foreach (var item in portInventory)
            {
                var itemView = Instantiate(ItemViewPrefab, _view.PortInventoryContainer.transform);
                itemView.Item = item;
                itemView.NameText.text = item.Name;
                itemView.MaterialText.text = item.Material;
                itemView.QuantityText.text = item.Quantity.ToString();
                itemView.ValueText.text = item.OriginalPrice.ToString(CultureInfo.InvariantCulture);
                itemView.Button.onClick.AddListener(() => { OnItemViewClicked(itemView); });
            }
        }

        public void OnSellClick()
        {
            // Remove from player inventory:
            SelectedItemView.transform.SetParent(null);

            // Add to port inventory:
            SelectedItemView.transform.SetParent(_view.PortInventoryContainer);

            // Update buy value:
            var item = SelectedItemView.Item;
            SelectedItemView.QuantityText.text = item.OriginalPrice.ToString(CultureInfo.InvariantCulture);

            // Add gold:
            var playerState = Application.Model.PlayerState;
            playerState.CurrentMoney += item.CalculateSellPrice(_portCulture);

            // Update inventories:
            _portInventory.AddItem(item);
            _playerInventory.DeleteItem(item.ID);
        }
        public void OnBuyClick()
        {
            var item = SelectedItemView.Item;
            var playerState = Application.Model.PlayerState;

            if (item.OriginalPrice > playerState.CurrentMoney)
            {
                // TODO Warn that gold is not enough:
                return;
            }

            // Remove from port inventory:
            SelectedItemView.transform.SetParent(null);

            // Add to player inventory:
            SelectedItemView.transform.SetParent(_view.PlayerInventoryContainer);

            // Update sell value:
            SelectedItemView.QuantityText.text = item.CalculateSellPrice(_portCulture).ToString(CultureInfo.InvariantCulture);

            // Remove gold:
            Application.Model.PlayerState.CurrentMoney -= item.OriginalPrice;

            // Update inventories:
            _playerInventory.AddItem(item);
            _portInventory.DeleteItem(item.ID);
        }

        public void OnViewExit()
        {
            Destroy(_view.gameObject);
        }

        public void OnItemViewClicked(ItemView itemView)
        {
            SelectedItemView = itemView;
        }
    }
}
