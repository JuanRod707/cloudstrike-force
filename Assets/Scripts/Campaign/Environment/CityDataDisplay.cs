using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Campaign.Environment
{
    public class CityDataDisplay : MonoBehaviour
    {
        public Text Name;

        private GlobalValues globalValues;
        
        public void SetName(string name) => Name.text = name;

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

        void SetColor(Color color) => Name.color = color;
    }
}
