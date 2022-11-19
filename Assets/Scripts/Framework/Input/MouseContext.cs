using GameCore.Plant;

namespace Framework.Input
{
    public class MouseContext
    {
        public PlantType PlantPicked;

        public MouseContext()
        {
            Reset();
        }

        public void Reset()
        {
            PlantPicked = PlantType.Unknown;
        }
    }
}