using System;
using System.Data.Entity;

namespace PatientJournalClassLib.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Text { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual Patient Patient { get; set; }

        public void PostJournal(int id, Journal journal)
        {
            using (var db = new PatientJournalContext())
            {
                try
                {
                    journal.PatientId = id;
                    Patient p = db.Patients.Find(id);
                    p.Journals.Add(journal);
                    db.Entry(p).State = EntityState.Modified;
                    db.Journals.Add(journal);
                    db.Entry(journal).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    string result = e.Message;
                }
            }
        }
    }
}
