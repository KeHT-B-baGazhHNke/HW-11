using System;

namespace Tlab_13
{
    internal class Buildings
    {
        private Building[] buildings = new Building[10];

        public Buildings()
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                buildings[i] = new Building();
            }
        }

        public Building this[int index]
        {
            get
            {
                if (index < 0 || index >= buildings.Length)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за пределы диапазона");
                }

                return buildings[index];
            }
        }

    }
}
