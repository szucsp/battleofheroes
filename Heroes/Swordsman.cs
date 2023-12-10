namespace Heroes
{
    public class Swordsman : HeroBase
    {
        public Swordsman()
        {
            MaxVitality = 120;
            Vitality = MaxVitality;
            State = HeroState.Live;
        }
    }
}
