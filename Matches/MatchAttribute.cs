namespace Matches
{
    public class MatchAttribute : System.Attribute
    {
        private string Participiant1;
        private string Participiant2;

        public MatchAttribute(string participiant1, string participiant2)
        {
            Participiant1 = participiant1;
            Participiant2 = participiant2;
        }
    }
}
