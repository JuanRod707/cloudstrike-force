using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class HealthBar : MonoBehaviour
    {
        public Text HPValue;
        public Image HPBar;

        int baseHp;

        public void Initialize(int baseHp) => this.baseHp = baseHp;

        public void UpdateHp(int hp)
        {
            if(HPValue!= null)
                HPValue.text = hp.ToString();
            
            if(HPBar!= null)
                HPBar.fillAmount = (float) hp / baseHp;
        }
    }
}