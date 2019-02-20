﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public sealed class MedOrg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Patient> Patiens = null;

        public MedOrg():this("","")
        {
                 
        }
        public MedOrg(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            Patiens = new List<Patient>();
        }
    }

    public class PatientAddedMed
    {
        public int Id { get; set; }
        public int MedOrgId { get; set; }

        public int PatientId { get; set; }
    }
}
