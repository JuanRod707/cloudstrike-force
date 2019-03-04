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
        public SpriteRenderer MinimapPing;

        List<ResourceBar> resources;
        private GlobalValues globalValues;
        private int maxPerBar;

        public void SetName(string name) => Name.text = name;

        public void SetLevel(int level) => Level.text = level.ToString();

        public void UpdateRsources(int amount)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                var siloFill = amount - (maxPerBar * i);
                resources[i].SetFill((float)siloFill/maxPerBar);
            }
        }

        public void SetResourceBars(int siloCount, int siloCapacity)
        {
            resources = new List<ResourceBar>();
            maxPerBar = siloCapacity;

            foreach (var _ in Enumerable.Range(0, siloCount))
                resources.Add(Instantiate(ResourceBarPrefab, ResourceContainer));
        }

        public void SetAlignment(Alignment alignment)
        {
            globalValues = FindObjectOfType<GlobalValues>();

            switch (alignment)
            {
                case Alignment.CloudStrike:
                    SetColor(globalValues.CloudstrikeColor);
                    break;
                case Alignment.Coalition:
                    SetColor(globalValues.CoalitionColor);
                    break;
                case Alignment.Neutral:
                    SetColor(globalValues.NeutralColor);
                    break;
            }
        }

        void SetColor(Color color)
        {
            MinimapPing.color = color;
            Name.color = color;
            Shield.color = color;
            foreach (var r in resources)
                r.SetColor(color);
        }
    }
}
