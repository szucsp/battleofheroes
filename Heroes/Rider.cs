namespace Heroes
{
    public class Rider : HeroBase
    {
        public Rider()
        {
            MaxVitality = 150;
            Vitality = MaxVitality;
            State = HeroState.Live;
        }
    }
}
