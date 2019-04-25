using System;
using UnityEngine;

namespace Battle.AI
{
    [Serializable]
    public class DefensePrefabs
    {
        [Header("Big Buildings")]
        public GameObject Refinery;
        public GameObject DroneTower;
        public GameObject TurretControl;
        public GameObject SAMTower;
        public GameObject Bunker;
        public GameObject MassDriver;
        public GameObject InterceptorBase;
        public GameObject Factory;

        [Header("Small Buildings")]
        public GameObject ShieldBattery;
        public GameObject SAMTurret;
        public GameObject Turret;

        [Header("Units")]
        public GameObject Tank;
        public GameObject Drone;
        public GameObject Interceptor;
        public GameObject Cruiser;
    }
}
