using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using UIControls;

namespace ControlTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Supply the control with the list of sections



            string user = "pack://application:,,,/SearchTextBox;component/Images/user.png";
            string groupCopy = "pack://application:,,,/SearchTextBox;component/Images/Group copy.png";

            List<NonUnique> sections1 = new List<NonUnique>();

            sections1.Add(new NonUnique { KEY = user, VALUE = "User" });
            sections1.Add(new NonUnique { KEY = user, VALUE = "User2" });
            sections1.Add(new NonUnique { KEY = groupCopy, VALUE = "Group" });
            sections1.Add(new NonUnique { KEY = user, VALUE = "User3" });
            sections1.Add(new NonUnique { KEY = groupCopy, VALUE = "Group2" });

            m_txtTest.SectionsList = sections1;
            // Choose a style for displaying sections
            m_txtTest.SectionsStyle = SearchTextBox.SectionsStyles.CheckBoxStyle;

            // Add a routine handling the event OnSearch
            m_txtTest.OnSearch += new RoutedEventHandler(m_txtTest_OnSearch);
        }

        void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;

            // Display search data
            string sections = "\r\nSections(s): ";
            foreach (string section in searchArgs.Sections)
                sections += (section + "; ");
            m_txtSearchContent.Text = "Keyword: " + searchArgs.Keyword + sections;
        }


        private void m_txtTest_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
