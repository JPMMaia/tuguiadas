using System;
using Collision;
using Core;
using Currency;
using State;

namespace Ports
{
    public class PortView : Entity
    {
        public TriggerCollider RangeArea;
        public String Name;
        public Culture Culture;
        public Inventory Inventory;

        public void Awake()
        {
            //DontDestroyOnLoad(gameObject);

            RangeArea.OnEnter += RangeArea_OnEnter;
            RangeArea.OnExit += RangeArea_OnExit;

            FillInventory();
        }

        private void FillInventory()
        {
            var itemTypes = ItemTypesByCulture.Collection[Culture];

            foreach (var itemType in itemTypes)
            {
                var quantity =
                    (uint) UnityEngine.Random.Range((int) itemType.MinimunQuantity, (int) itemType.MaximunQuantity);

                if(quantity == 0)
                    continue;

                var item = new Currency.Item
                {
                    Name = itemType.Name,
                    Material = itemType.Material,
                    Quantity = quantity,
                    OriginalPrice = UnityEngine.Random.Range(itemType.MinimunPrice, itemType.MaximunPrice),
                    Culture = Culture
                };
                Inventory.AddItem(item);
            }
        }

        private void RangeArea_OnEnter(object sender, TriggerCollider.CollisionEventArgs e)
        {
            //Debug.Log("Enter port!");

            // Present merchant view:
            Application.Presenter.MerchantPresenter.Present(Culture, Application.Model.PlayerState.Inventory, Inventory);
        }
        private void RangeArea_OnExit(object sender, TriggerCollider.CollisionEventArgs e)
        {
            //Debug.Log("Exit port!");
        }
    }
}
