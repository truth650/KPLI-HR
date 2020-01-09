using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    public class Memo
    {
        private string id;
        private DateTime date;
        private string content;

        public Memo(string id, DateTime date, string content)
        {
            this.id = id;
            this.date = date;
            this.content = content;
        }

        public string ID { get { return id; } set { id = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Content { get { return content; } set { content = value; } }

    }
}
