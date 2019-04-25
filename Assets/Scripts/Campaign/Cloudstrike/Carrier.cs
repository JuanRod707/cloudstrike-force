using Data.Dtos;
using UnityEngine;

namespace Campaign.Cloudstrike
{
    public class Carrier : MonoBehaviour
    {
        public int InitialResources;

        private int resourceUnits;

        public int Resources => resourceUnits;

        void Start() => resourceUnits = InitialResources;

        public void Initialize(CarrierData source)
        {
            transform.position = source.Position;
            resourceUnits = source.Resources;
        }

        public void AddResources(int resources) => resourceUnits = resources;
    }
}
