namespace Heroes
{
    /// <summary>
    /// This is an abstract class for Heroes. 
    /// </summary>
    public abstract class HeroBase
    {
        private const double diedlimit = 0.25;

        public int Id { get; set; }
        public int Vitality { get; protected set; }

        public int MaxVitality { get; protected set; }

        public HeroState State { get; protected set; }

        public void SetState(HeroState state)
        {
            this.State = state;
        }

        public void SetVitality(HeroVitalityChange vitalityChange)
        {
            int value = 0;

            if (vitalityChange == HeroVitalityChange.Up)
                value = 10;
            if (vitalityChange == HeroVitalityChange.Down)
                value = (Vitality / 2) * -1;

            this.Vitality = ((this.Vitality + value) > MaxVitality) ? this.MaxVitality : this.Vitality + value;

            if (this.Vitality < this.MaxVitality * diedlimit)
            {
                SetState(HeroState.Died);
            }
        }
    }
}
