using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class TopHud : MonoBehaviour
    {
        public Text IslandName;
        public Text IslandLevel;

        public void Initialize(string name, int level)
        {
            IslandName.text = name;
            UpdateLevel(level);
        }

        public void UpdateLevel(int level) => IslandLevel.text = level.ToString();
    }
}