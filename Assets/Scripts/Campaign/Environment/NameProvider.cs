using System.Collections.Generic;
using System.Linq;
using Common;

namespace Campaign.Environment
{
    public static class NameProvider
    {
        private static List<string> cityCandidates;

        private static List<string> islandCandidates;

        static NameProvider() => ResetLists();

        public static string GetIslandName()
        {
            var candidate = islandCandidates.PickOne();
            islandCandidates.Remove(candidate);
            return candidate;
        }

        public static string GetCityName()
        {
            var candidate = cityCandidates.PickOne();
            cityCandidates.Remove(candidate);
            return candidate;
        }

        static void ResetLists()
        {
            cityCandidates = cityNames.ToList();
            islandCandidates = islandNames.ToList();
        }
        
        private static string[] cityNames = new []
        {
            "New Beijing",
            "New Victoria",
            "Bisoria",
            "Crisin",
            "Essen",
            "Strandford",
            "Port Madanus"
        };

        private static string[] islandNames = new []
        {
            "Deimos",
            "Phobos",
            "Callisto",
            "Casiopea",
            "Io",
            "Europa",
            "Titan",
            "Amalthea",
            "Carpo",
            "Ganymide",
            "Hegemone",
            "Thebe",
            "Atlas",
            "Calypso",
            "Janus",
            "Hyperion",
            "Pandora",
            "Caliban",
            "Cordelia",
            "Arrakis",
            "Caladan",
            "Charon",
            "Namaka",
            "Kisaba",
            "Proteus",
            "Triton",
            "Thalasa",
            "Sirius",
            "Centauri",
            "Cygni",
            "Procyon",
            "Arcturus",
            "Vega",
            "Altair"
        };
    }
}
