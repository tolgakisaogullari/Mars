using System.Collections.Generic;

namespace Mars
{
    public class Plateau
    {
        public Plateau(int xRange, int yRange)
        {
            XRange = xRange;
            YRange = yRange;
            Coordinates = new List<Coordinate>();
        }

        public int XRange { get; set; }

        public int YRange { get; set; }

        public List<Coordinate> Coordinates { get; set; }

        /// <summary>
        /// Creates the plaeau
        /// </summary>
        public void Create()
        {
            for (int x = 0; x <= XRange; x++)
            {
                for (int y = 0; y <= YRange; y++)
                {
                    var coordinate = new Coordinate(x, y);

                    coordinate.SetForbiddenDirectionsForCoordinate(XRange, YRange);

                    Coordinates.Add(coordinate);
                }
            }
        }
    }
}