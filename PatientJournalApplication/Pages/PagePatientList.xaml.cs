using PatientJournalApplication.Models;
using PatientJournalClassLib;
using PatientJournalClassLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PatientJournalApplication.Pages
{
    /// <summary>
    /// Interaction logic for PagePatientList.xaml
    /// </summary>
    public partial class PagePatientList : Page
    {
        public PagePatientList(ViewModelPatientList vm)
        {
            InitializeComponent();

            if (!vm.toggle)
            {
                LVPatients.ItemsSource = vm.ListOfActivePatients;
            }
            else
            {
                LVPatients.ItemsSource = vm.ListOfAllPatients;
            }
        }

        private void BtnCreatePatient_Click(object sender, RoutedEventArgs e)
        {
            PageCreatePatient pcp = new PageCreatePatient();
            NavigationService.Navigate(pcp);
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Patient patient = (Patient)LVPatients.ItemContainerGenerator.ItemFromContainer(dep);
            PagePatient pp = new PagePatient(DbGet.GetPatient(patient.Id));
            NavigationService.Navigate(pp);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Patient patient = (Patient)LVPatients.ItemContainerGenerator.ItemFromContainer(dep);
            patient.DeletePatient(patient);
            ViewModelPatientList vm = new ViewModelPatientList();
            PagePatientList ppl = new PagePatientList(vm);
            NavigationService.Navigate(ppl);
        }

        private void ChkBxToggle_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)ChkBxToggle.IsChecked)
                LVPatients.ItemsSource = DbGet.GetPatientList(true);
            else
                LVPatients.ItemsSource = DbGet.GetPatientList(false);
        }

        private void TBArchive_Checked(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;

            Patient patient = (Patient)LVPatients.ItemContainerGenerator.ItemFromContainer(dep);
            patient.SetArchived(patient);
            ViewModelPatientList vm = new ViewModelPatientList();
            PagePatientList ppl = new PagePatientList(vm);
            NavigationService.Navigate(ppl);
        }
    }
}
