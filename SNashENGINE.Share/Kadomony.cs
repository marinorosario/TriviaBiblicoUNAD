using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share
{
    public class Kadomony
    {
        public static DateOnly HoySoloFecha => DateOnly.FromDateTime(DateTime.Today);
        public static DateTime Hoy => DateTime.Today;
        public static DateTime Ahora => DateTime.Now;
        public static TimeOnly AhoraSoloTiempo => TimeOnly.FromDateTime(DateTime.Now);
    }
}
