using PatientJournalClassLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PatientJournalApplication.Pages
{
    /// <summary>
    /// Interaction logic for PagePatient.xaml
    /// </summary>
    public partial class PagePatient : Page
    {
        int id;
        public PagePatient(Patient patient)
        {
            InitializeComponent();
            TBFirstName.Text = patient.FirstName;
            TBLastName.Text = patient.LastName;
            TBPatientNumber.Text = patient.PatientNumber;
            if (patient.IsArchived)
                TBArchived.Text = "Patient is archived.";
            LVJournals.ItemsSource = patient.GetJournals(patient);
            id = patient.Id;
        }

        private void BtnNewJournal_Click(object sender, RoutedEventArgs e)
        {
            PageJournal pp = new PageJournal(id);
            NavigationService.Navigate(pp);
        }
    }
}
