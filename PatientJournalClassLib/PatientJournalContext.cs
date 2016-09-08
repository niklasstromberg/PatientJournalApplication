using PatientJournalClassLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientJournalClassLib
{
    public class PatientJournalContext : DbContext
    {
        public PatientJournalContext()
            : base("name=PatientJournalContext")
        {
        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Journal>()
            //    .HasRequired(e => e.Patient);
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Journals)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(true);

        }

    }
}
