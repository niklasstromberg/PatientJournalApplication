using PatientJournalApplication.Models;
using System.Windows;
using System.Windows.Controls;

namespace PatientJournalApplication.Pages
{
    /// <summary>
    /// Interaction logic for PageDefault.xaml
    /// </summary>
    public partial class PageDefault : Page
    {
        public PageDefault()
        {
            InitializeComponent();
        }

        private void BtnPatient_Click(object sender, RoutedEventArgs e)
        {
            ViewModelPatientList vm = new ViewModelPatientList();
            PagePatientList ppl = new PagePatientList(vm);
            ContentFrame.Navigate(ppl);
        }
    }
}
