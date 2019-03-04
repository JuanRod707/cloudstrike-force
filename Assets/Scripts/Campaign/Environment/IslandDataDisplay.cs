using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Campaign.Environment
{
    public class IslandDataDisplay : MonoBehaviour
    {
        public Text Name;
        public Text Level;
        public Image Shield;
        public ResourceBar ResourceBarPrefab;
        public Transform ResourceContainer;

        List<ResourceBar> Resources;
        private int maxPerBar;

        public void SetName(string name) => Name.text = name;

        public void SetLevel(int level) => Level.text = level.ToString();

        public void UpdateRsources(int amount)
        {
            for (int i = 0; i < Resources.Count; i++)
            {
                var siloFill = amount - (maxPerBar * i);
                Resources[i].SetFill((float)siloFill/maxPerBar);
            }
        }

        public void SetResourceBars(int siloCount, int siloCapacity)
        {
            Resources = new List<ResourceBar>();
            maxPerBar = siloCapacity;

            foreach (var _ in Enumerable.Range(0, siloCount))
                Resources.Add(Instantiate(ResourceBarPrefab, ResourceContainer));
        }
    }
}
