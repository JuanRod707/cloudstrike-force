using System.Collections;
using Campaign.Environment.Generation;
using Data.Dtos;
using UnityEngine;

namespace Campaign.Environment
{
    public class City : MonoBehaviour
    {
        public string Name;
        public Alignment Alignment;
        public CityDataDisplay Display;

        public void Initialize()
        {
            Name = NameProvider.GetCityName();
            Alignment = Alignment.Coalition;

            Startup();
        }

        public void Initialize(CityData source)
        {
            Name = source.Name;
            Alignment = source.Alignment;

            Startup();
        }

        void Startup()
        {
            Display.SetName(Name);
            Display.SetAlignment(Alignment.Neutral);
        }
    }
}
