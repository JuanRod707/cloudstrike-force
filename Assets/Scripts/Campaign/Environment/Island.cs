using System.Collections;
using Campaign.Environment.Generation;
using Common;
using Data.Dtos;
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

        public void Initialize()
        {
            Name = NameProvider.GetIslandName();
            Alignment = Alignment.Coalition;
            level = RandomService.GetRandom(1, 10);

            Startup();
        }

        public void Initialize(IslandData source)
        {
            Name = source.Name;
            Alignment = source.Alignment;
            level = source.Level;

            Startup();
        }

        void Startup()
        {
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

        public void Upgrade()
        {
            resources -= SiloCapacity;
            level++;
            Display.SetLevel(level);
        }
    }
}
