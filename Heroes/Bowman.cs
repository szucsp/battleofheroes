namespace Heroes
{
    public sealed class Bowman : HeroBase
    {
        public Bowman()
        {
            MaxVitality = 100;
            Vitality = MaxVitality;
            State = HeroState.Live;
        }
    }
}
