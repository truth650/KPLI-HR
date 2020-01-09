using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    //휴가신청내용
    public class RequestV
    {
        private string id;
        private string name;
        private DateTime requestdate; //신청날짜
        private string type;
        private DateTime startvacation;
        private DateTime endvacation;
        private string destination;
        private string contact;
        private string agent;
        private bool approval; //승인여부



        private string content;

        public RequestV(string id, string name, DateTime requestdate, string type, DateTime startvacation,
            DateTime endvacation, string destination, string contact, string agent, bool approval)
        {
            this.id = id;
            this.name = name;
            this.requestdate = requestdate;
            this.type = type;
            this.startvacation = startvacation;
            this.endvacation = endvacation;
            this.destination = destination;
            this.contact = contact;
            this.agent = agent;
            this.approval = approval;
        }

        public string ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public DateTime RequestDate { get { return requestdate; } set { requestdate = value; } }
        public string Type { get { return type; } set { type = value; } }
        public DateTime StartVacation { get { return startvacation; } set { startvacation = value; } }
        public DateTime EndVacation { get { return endvacation; } set { endvacation = value; } }
        public string Destination { get { return destination; } set { destination = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
        public string Agent { get { return agent; } set { agent = value; } }
        public bool Approval { get { return approval; } set { approval = value; } }
    }
}
