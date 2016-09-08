using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PatientJournalClassLib.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientNumber { get; set; }
        public bool IsArchived { get; set; }

        public virtual List<Journal> Journals { get; set; }

        public void PostPatient(Patient patient)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    db.Patients.Add(patient);
                    db.Entry(patient).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    string result = e.Message;
                }
            }
        }

        public void DeletePatient(Patient patient)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    Patient p = db.Patients.Find(patient.Id);
                    db.Patients.Remove(p);
                    db.Entry(p).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    string result = e.Message;
                }
            }
        }

        public void SetArchived(Patient patient)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    Patient p = db.Patients.Find(patient.Id);
                    p.IsArchived = !p.IsArchived;
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    string result = e.Message;
                }
            }
        }

        public List<Journal> GetJournals(Patient patient)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    Patient p = db.Patients.Find(patient.Id);
                    return p.Journals.ToList<Journal>();
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
