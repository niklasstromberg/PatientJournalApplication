using PatientJournalClassLib;
using PatientJournalClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientJournalApplication.Models
{
    public class ViewModelPatientList
    {
        public bool toggle = false;
        public List<Patient> ListOfAllPatients = DbGet.GetPatientList(true);
        public List<Patient> ListOfActivePatients = DbGet.GetPatientList(false);
    }
}
