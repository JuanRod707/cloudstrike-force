namespace Data.Dtos
{
    public class MissionData
    {
        public IslandData MissionIsland;

        public MissionData()
        {
        }

        public MissionData(IslandData island) => MissionIsland = island;
    }
}
