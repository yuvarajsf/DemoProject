using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignmentDocter
{
    class Docter
    {
        private static int _docterid = 0;

        public int DocterId;
        public string DocterName { get; set; }
        public string DocterDepartment{ get; set; }

        public Docter(string DocName,string DocDepartment)
        {
            _docterid++;
            this.DocterId = _docterid;
            this.DocterName = DocName;
            this.DocterDepartment = DocDepartment;
        }
    }
}
