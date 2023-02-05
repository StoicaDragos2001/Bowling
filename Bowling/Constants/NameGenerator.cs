namespace Bowling.UtilityComponents
{
    internal static class NameGenerator
    {
        private static readonly Random Random = new Random();
        private static readonly List<String> Names = new List<String> { "Emil", "Bunny", "Brande", "Jacquetta", "Arminda", "Holley", "Jacalyn", "Dawna", "Shirl", "Heidy", "Dedra", "Candyce", "Deanna", "Evelina", "Shawanna", "Nichelle", "Magali", "Shani", "Kerry", "Karyl", "Irving", "Shyla", "Jannet", "Bronwyn", "Eliz", "Harley", "Bethel", "Adelina", "Meagan", "Laquita", "Rafaela", "Jeannie", "Nicolle", "Lacresha", "Linnie", "Taina", "Ingeborg", "Pearlie", "Helga", "Laveta", "Carlos", "Azalee", "Amado", "Denisse", "Kelly", "Natisha", "Tanesha", "Refugio", "Jesusita", "Pheobe" };
        public static String Get()
        {
            var NameIndex = Random.Next(Names.Count);
            return Names[NameIndex];    
        }
    }
}
