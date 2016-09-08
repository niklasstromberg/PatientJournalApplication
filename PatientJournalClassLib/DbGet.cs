using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PatientJournalClassLib.Models;

namespace PatientJournalClassLib
{
    public static class DbGet
    {
        public static List<Patient> GetPatientList(bool archived)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    if (archived)
                    {
                        var query = from patients in db.Patients
                                    select patients;
                        return query.ToList<Patient>();
                    }
                    else
                    {
                        var query = from patients in db.Patients
                                    where patients.IsArchived == false
                                    select patients;
                        return query.ToList<Patient>();
                    }

                }
                catch (Exception e)
                {
                    string result = e.Message;
                    return null;
                }
            }
        }

        public static Patient GetPatient(int id)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    var query = from patient in db.Patients
                                where patient.Id == id
                                select patient;
                    return query.FirstOrDefault();
                }
                catch (Exception e)
                {
                    string result = e.Message;
                    return null;
                }
            }
        }

        public static List<Journal> GetJournalList()
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    var query = from j in db.Journals
                                select j;
                    return query.ToList<Journal>();
                }
                catch (Exception e)
                {
                    string result = e.Message;
                    return null;
                }
            }
        }
    }
}
