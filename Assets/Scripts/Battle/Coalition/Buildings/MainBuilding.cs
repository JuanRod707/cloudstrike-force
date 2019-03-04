namespace Battle.Coalition.Buildings
{
    public class MainBuilding : Building
    {
        public override void Initialize(IslandBase faction)
        {
            islandBase = faction;
            Health.Initialize(Destroy);
        }
    }
}
