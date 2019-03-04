using System;
using Campaign;
using UnityEngine;

namespace Data.Dtos
{
    [Serializable]
    public class IslandData
    {
        public string Name;
        public int Level;
        public int CurrentResources;
        public int SiloCount;
        public int SiloCapacity;
        public Vector3 Position;
        public Alignment Alignment;
    }
}
