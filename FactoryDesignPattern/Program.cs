using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//Inner Factory
namespace FactoryDesignPattern
{


    public class Point
    {
        //factory method ctrl shift r

        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }


        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double thetha)
            {
                return new Point(rho * Math.Cos(thetha), rho * Math.Sin(thetha));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);

            foreach (var m in MesHelper.ObtenerMeses())
            {
                WriteLine($"{m.NoMes} {m.NombreMes}");
            }
        }
    }

    public class MesHelper
    {
        public string NombreMes { get; set; }
        public int NoMes { get; set; }

        public MesHelper(string nombreMes, int noMes)
        {
            NombreMes = nombreMes;
            NoMes = noMes;
        }

        public static List<MesHelper> ObtenerMeses()
        {
            List<MesHelper> meses = new List<MesHelper>();
            for (int i = 1; i <= 12; i++)
            {
                string nombreMes = new DateTime(2000, i, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).Capitalize();
                meses.Add(new MesHelper(nombreMes, i));
            }
            return meses;
        }
    }

    public static class StringExtension
    {
        public static string Capitalize(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

