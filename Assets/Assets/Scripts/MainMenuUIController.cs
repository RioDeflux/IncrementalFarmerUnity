using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class MainMenuUIController : MonoBehaviour
    {
        private Button _fieldsButton;
        private Button _animalsButton;
        private Button _barnButton;
        private Button _workshopButton;
        private Button _marketButton;
        private Button _shopButton;
    
    
        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            _fieldsButton = root.Q<Button>("Fields");
            _animalsButton = root.Q<Button>("Animals");
            _barnButton = root.Q<Button>("Barn");
            _workshopButton = root.Q<Button>("Workshop");
            _marketButton = root.Q<Button>("Market");
            _shopButton = root.Q<Button>("Shop");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
