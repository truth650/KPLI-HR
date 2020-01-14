using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    public class Expense
    {
        private DateTime date;
        private string id;
        private string name;
        private float ae;
        private float me;
        private float os;
        private float gift;
        private float oe;
        private float advertisement;
        private float etc;
        private float total;
        private string contents;
        private byte[] image;
        private string filename;
        private string extension;
        private string approval;

        public Expense(DateTime date, string id, string name, float ae, float me, float os, float gift, float oe, float advertisement, float etc, 
            float total, string contents, byte[] image, string filename, string extension, string approval)
        {
            this.date = date;
            this.id = id;
            this.name = name;
            this.ae = ae;
            this.me = me;
            this.os = os;
            this.gift = gift;
            this.oe = oe;
            this.advertisement = advertisement;
            this.etc = etc;
            this.total = total;
            this.contents = contents;
            this.image = image;
            this.filename = filename;
            this.extension = extension;
            this.approval = approval; //결제대기 OR 결제승인
        }

        public DateTime Date { get { return date; } set { date = value; } }
        public string ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public float AE { get { return ae; } set { ae = value; } }
        public float ME { get { return me; } set { me = value; } }
        public float OS { get { return os; } set { os = value; } }
        public float Gift { get { return gift; } set { gift = value; } }
        public float OE { get { return oe; } set { oe = value; } }
        public float Advertisment { get { return advertisement; } set { advertisement = value; } }
        public float ETC { get { return etc; } set { etc = value; } }
        public float Total { get { return total; } set { total = value; } }
        public string Contents { get { return contents; } set { contents = value; } }
        public byte[] Image { get { return image; } set { image = value; } }
        public string Filename { get { return filename; } set { filename = value; } }
        public string Extension { get { return extension; } set { extension = value; } }
        public string Approval { get { return approval; } set { approval = value; } }
    }
}
