using MyAsteroids.CodeBase.Data;

namespace MyAsteroids.CodeBase.Ammunitions
{
    public class Laser : Ammunition
    {
        public override void Construct(AmmunitionsData ammunitionsData)
        {
            StartSpeed = ammunitionsData.LaserStartSpeed;
            MaxSpeed = ammunitionsData.LaserMaxSpeed;
        }
    }
}