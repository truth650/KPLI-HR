using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
   public class Board
    {
        private int idx;
        private string category;
        private string id;
        private string title;
        private string contents;
        private string contents_info;
        private string file_name;
        private byte[] file_binary;
        private string extension;
        private DateTime time;

        public Board(int idx, string category, string id, string title, string contents, string contents_info, string file_name, 
            byte[] file_binary, string extension, DateTime time)
        {
            this.idx = idx;
            this.category = category;
            this.id = id;
            this.title = title;
            this.contents = contents;
            this.contents_info = contents_info;
            this.file_name = file_name;
            this.file_binary = file_binary;
            this.extension = extension;
            this.time = time;
        }

        public int Idx { get { return idx; } set { idx = value; } }
        public string Category { get { return category; } set { category = value; } }
        public string Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Contents { get { return contents; } set { contents = value; } }
        public string Contents_Info { get { return contents_info; } set { contents_info = value; } }
        public string File_Name { get { return file_name; } set { file_name = value; } }
        public byte[] File_Binary { get { return file_binary; } set { file_binary = value; } }
        public string Extension { get { return extension; } set { extension = value; } }
        public DateTime Time {get { return time; } set { time = value; } }

    }
}
