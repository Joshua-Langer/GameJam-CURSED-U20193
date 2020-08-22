using UnityEngine.UI;
using UnityEngine;

namespace GJApp.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        static Image _playerHealthBar;
        // Start is called before the first frame update
        void Start()
        {
            _playerHealthBar = GetComponent<Image>();
        }
        public static void SetHealthBarValue(float value)
        {
            _playerHealthBar.fillAmount = value;
        }

        public static float GetHealthBarValue()
        {
            return _playerHealthBar.fillAmount;
        }
    }
}
