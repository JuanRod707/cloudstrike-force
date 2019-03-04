using System.Collections;
using Common;
using UnityEngine;

namespace Campaign.Environment
{
    public class Island : MonoBehaviour
    {
        public string Name;
        public Alignment Alignment;

        public float MiningSpeed;
        public int MiningYield;
        public int SiloCapacity;
        public int SiloCount;

        public IslandDataDisplay Display;

        private int level;
        private int resources;

        void Start()
        {
            Name = NameProvider.GetIslandName();
            Alignment = Alignment.Coalition;
            level = RandomService.GetRandom(1, 10);

            Display.SetName(Name);    
            Display.SetLevel(level);
            Display.SetResourceBars(SiloCount, SiloCapacity);
            Display.SetAlignment(Alignment);
            StartCoroutine(ProduceResources());
        }

        IEnumerator ProduceResources()
        {
            GainResource();
            yield return new WaitForSeconds(MiningSpeed);
            StartCoroutine(ProduceResources());
        }

        private void GainResource()
        {
            if (resources < SiloCapacity * SiloCount)
                resources += MiningYield;
            else
                Upgrade();

            Display.UpdateRsources(resources);
        }

        void Upgrade()
        {
            resources -= SiloCapacity;
            level++;
            Display.SetLevel(level);
        }
    }
}
