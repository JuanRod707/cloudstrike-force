using UnityEngine;
using UnityEngine.UI;

namespace Campaign.Environment
{
    public class ResourceBar : MonoBehaviour
    {
        public Image Fill;

        public void SetFill(float amount) => Fill.fillAmount = amount;
    }
}
