using System;
using Campaign;
using UnityEngine;

namespace Data.Dtos
{
    [Serializable]
    public class CityData
    {
        public string Name;
        public Vector3 Position;
        public Alignment Alignment;
    }
}
