using System;
using System.Timers;
using System.Text.RegularExpressions;
using System.IO.Ports;

namespace SharpGLWinformsApp
{
    class Parser
    {
        public float getAngleX(string coordinates)
        {
            float angleX;
            int x;
            string data = "";
            string patX = @"(\d{1,3}(?=\ Y\:)|\-\d{1,3}(?=\ Y\:))";

            Regex r = new Regex(patX, RegexOptions.IgnoreCase);

            Match m = r.Match(coordinates);

            Group g = m.Groups[1];

            data = g.ToString();

            x = Convert.ToInt32(data);

            angleX = x * (180f / 204f);

            return angleX;
        }

        public float getAngleY(string coordinates)
        {
            float angleY;
            int y;
            string data = "";
            string patY = @"(\d{1,3}(?=\ Z\:)|\-\d{1,3}(?=\ Z\:))";

            Regex r = new Regex(patY, RegexOptions.IgnoreCase);

            Match m = r.Match(coordinates);

            Group g = m.Groups[1];

            data = g.ToString();

            y = Convert.ToInt32(data);

            angleY = y * (180f / 204f);

            return angleY;
        }

        public float getAngleZ(string coordinates)
        {
            float angleZ;
            int z;
            string data = "";
            string patZ = @"(?<=Z:)((\d{1,3})|(\-\d{1,3}))";

            Regex r = new Regex(patZ, RegexOptions.IgnoreCase);

            Match m = r.Match(coordinates);

            Group g = m.Groups[1];

            data = g.ToString();

            z = Convert.ToInt32(data);

            angleZ = z * (180f / 204f);

            return angleZ;
        }

       /* private static System.Timers.Timer aTimer;
        public float coordinateX { get; set; }

        public void Main()
        {
            aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {            
            Coordinates coordinates = new Coordinates();
            coordinates.axisX++;
            coordinates.setX(coordinates.axisX);
            Parser parser = new Parser();
            parser.coordinateX = coordinates.axisX;
        }

        public class Coordinates
        {
            public float axisX = 0;
            public float axisY = 0;
            public float axisZ = 0;

            public void setX(float x)
            {
                this.axisX = x;
            }

            public float getX()
            {
                return this.axisX;
            } 
        } */
    }
}
