using PatientJournalClassLib;
using PatientJournalClassLib.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PatientJournalApplication.Pages
{
    /// <summary>
    /// Interaction logic for PageJournal.xaml
    /// </summary>
    public partial class PageJournal : Page
    {
        int patientId;
        public PageJournal(int id)
        {
            InitializeComponent();
            patientId = id;
        }

        private void CancelJournal_Click(object sender, RoutedEventArgs e)
        {
            PagePatient pp = new PagePatient(DbGet.GetPatient(patientId));
            NavigationService.Navigate(pp);
        }

        private void SaveJournal_Click(object sender, RoutedEventArgs e)
        {
            Journal journal = new Journal();
            journal.Text = TBXInputText.Text;
            journal.AddedAt = DateTime.Now;
            journal.PostJournal(patientId, journal);
            PagePatient pp = new PagePatient(DbGet.GetPatient(patientId));
            NavigationService.Navigate(pp);
        }
    }
}
