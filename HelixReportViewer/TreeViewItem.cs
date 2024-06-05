using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixReportViewer
{
    public class TreeViewItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string DisplayText { get; set; }
        public string Value { get; set; }
    }
}
