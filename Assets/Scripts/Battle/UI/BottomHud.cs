using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class BottomHud : MonoBehaviour
    {
        public Text HPValue;
        public Image HPBar;

        int baseHp;

        public void Initialize(int baseHp) => this.baseHp = baseHp;

        public void UpdateHp(int hp)
        {
            HPValue.text = hp.ToString();
            HPBar.fillAmount = (float) hp / baseHp;
        }
    }
}