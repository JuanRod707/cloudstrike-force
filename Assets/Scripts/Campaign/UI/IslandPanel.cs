using Campaign.Cloudstrike;
using UnityEngine;
using UnityEngine.UI;

namespace Campaign.UI
{
    public class IslandPanel : MonoBehaviour
    {
        public Text IslandName;
        public Animator Animator;
        private CarrierInteractions carrier;

        public void Initialize(CarrierInteractions carrier) => this.carrier = carrier;

        public void Show(string islandName)
        {
            IslandName.text = islandName;
            Animator.SetTrigger("PanelIn");
        }

        public void Hide() => Animator.SetTrigger("PanelOut");

        public void Attack() => carrier.AttackIsland();
    }
}
