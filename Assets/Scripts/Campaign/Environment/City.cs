using System.Collections;
using UnityEngine;

namespace Campaign.Environment
{
    public class City : MonoBehaviour
    {
        public string Name;
        public Alignment Alignment;
        public CityDataDisplay Display;

        void Start()
        {
            Name = NameProvider.GetCityName();
            Alignment = Alignment.Coalition;

            Display.SetName(Name);  
            Display.SetAlignment(Alignment.Neutral);
        }
    }
}
