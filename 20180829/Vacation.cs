using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    public class Vacation
    {
        private string id;
        private string name;
        private int sickday;
        private int yearvacation; //연차휴가
        private int annual; //연차

        public Vacation(string id, string name, int sickday, int yearvacation, int annual)
        {
            this.id = id;
            this.name = name;
            this.sickday = sickday;
            this.yearvacation = yearvacation;
            this.annual = annual;
        }

        public string ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int SickDay { get { return sickday; } set { sickday = value; } }
        public int YearVacation { get { return yearvacation; } set { yearvacation = value; } }
        public int Annual { get { return annual; } set { annual = value; } }
    }
}
