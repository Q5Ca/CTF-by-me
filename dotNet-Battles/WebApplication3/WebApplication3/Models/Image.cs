using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Image
    {
        public String Path { get; set; }
        public virtual String getLink()
        {
            return "~/images/" + System.IO.Path.GetFileName(Path);
        }
    }
    public class Avatar : Image
    {
        public byte[] Content { get; set; }
        public override string getLink()
        {
            String filename = System.IO.Path.GetFileName(Path);
            File.WriteAllBytes("wwwroot/avatars/"+filename, Content);
            String Link = "~/avatars/" + filename;
            return Link;
        }
    }
}
