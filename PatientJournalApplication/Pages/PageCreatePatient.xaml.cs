using PatientJournalApplication.Models;
using PatientJournalClassLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PatientJournalApplication.Pages
{
    /// <summary>
    /// Interaction logic for PageCreatePatient.xaml
    /// </summary>
    public partial class PageCreatePatient : Page
    {
        public PageCreatePatient()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewModelPatientList vm = new ViewModelPatientList();
            PagePatientList ppl = new PagePatientList(vm);
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            pageFrame.Navigate(ppl);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.FirstName = TBFirstName.Text;
            patient.LastName = TBLastName.Text;
            patient.PatientNumber = TBPatientNumber.Text;
            patient.PostPatient(patient);
            ViewModelPatientList vm = new ViewModelPatientList();
            PagePatientList ppl = new PagePatientList(vm);
            NavigationService.Navigate(ppl);
        }
    }
}
