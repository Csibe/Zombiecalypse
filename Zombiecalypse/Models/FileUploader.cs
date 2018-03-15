using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class FileUploader
    {
        public int FileUploaderID { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}