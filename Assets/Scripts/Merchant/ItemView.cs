using UnityEngine;
using UnityEngine.UI;

namespace Merchant
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class ItemView : MonoBehaviour
    {
        public Text NameText;
        public Text MaterialText;
        public Text QuantityText;
        public Text ValueText;

        public Currency.Item Item { get; set; }
        public Button Button { get; private set; }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                _image.color = _selected ? Color.green : Color.white;
            }
        }

        private Image _image;
        private bool _selected;

        public void Awake()
        {
            Button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

    }
}
