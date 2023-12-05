using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlab_13
{
    internal class Building
    {
        private int unique_Id;
        private int height;
        private int floors;
        private int apartments;
        private int entrances;

        public Building()
        {
            height = 100;
            floors = 10;
            apartments = 100;
            entrances = 10;
            unique_Id = getNextUniqueNumber();
        }

        public Building(int height, int floors, int apartments, int entrances)
        {
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
            unique_Id = getNextUniqueNumber();
        }

        private static int nextUniqueNumber = 1;

        public int UniqueNumber
        {
            get { return unique_Id; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Floors
        {
            get { return floors; }
            set { floors = value; }
        }

        public int Apartments
        {
            get { return apartments; }
            set { apartments = value; }
        }

        public int Entrances
        {
            get { return entrances; }
            set { entrances = value; }
        }

        public int ApartmentsOnFloor
        {
            get { return Apartments / Floors; }
        }

        public int ApartmentsInEntrance
        {
            get { return Apartments / Entrances; }
        }

        public int FloorHeight
        {
            get { return Height / Floors; }
        }

        private static int getNextUniqueNumber()
        {
            int uniqueNumber = nextUniqueNumber;
            nextUniqueNumber++;
            return uniqueNumber;
        }

        public override string ToString()
        {
            return $"Номер здания: {UniqueNumber}, высота: {Height}, кол-во этажей: {Floors}, кол-во квартир: {Apartments}, кол-во подъездов: {Entrances}";
        }
    }
}
