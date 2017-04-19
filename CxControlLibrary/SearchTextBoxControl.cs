using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CxControlLibrary
{
    public class SearchTextBoxControl
    {

        private string _user;
        private string _grupCopy;
        private List<UIControls.NonUnique> _selections;

        public UIControls.SearchTextBox This { get; set; }
        public string SerachInformation { get; set; }
        
        public SearchTextBoxControl()
        {
           // _user = "pack://application:,,,/SearchTextBox;component/Images/user.png";
           // _grupCopy = "pack://application:,,,/SearchTextBox;component/Images/Group copy.png";

            //CreateSelections();

           
            // Choose a style for displaying sections
            //This.SectionsStyle = UIControls.SearchTextBox.SectionsStyles.CheckBoxStyle;

            // Add a routine handling the event OnSearch
            //This.OnSearch += new RoutedEventHandler(OnSearchHandler);
        }
        public void CreateSelections()
        {
            _selections = new List<UIControls.NonUnique>();

            _selections.Add(new UIControls.NonUnique { KEY = _user, VALUE = "User" });
            _selections.Add(new UIControls.NonUnique { KEY = _user, VALUE = "User2" });
            _selections.Add(new UIControls.NonUnique { KEY = _grupCopy, VALUE = "Group" });
            _selections.Add(new UIControls.NonUnique { KEY = _user, VALUE = "User3" });
            _selections.Add(new UIControls.NonUnique { KEY = _grupCopy, VALUE = "Group2" });

            This.SectionsList = _selections;
        } //ChengeCreateSelection
        public void CreateSelections(List<UIControls.NonUnique> selections)
        {
            This.SectionsList = selections;
        }
        public void OnSearchHandler(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;
            // Display search data
            string sections = "\r\nSections(s): ";
            foreach (string section in searchArgs.Sections)
                sections += (section + "; ");
            SerachInformation = "Keyword: " + searchArgs.Keyword + sections;
        }
        public void SetUserIcon(string path)
        {
            _user = path;
        }
        public void SetGrupCopyIcon(string path)
        {
            _grupCopy = path;
        }
        public void SetSelectionStyle(UIControls.SearchTextBox.SectionsStyles style)
        {
            This.SectionsStyle = style;
        }
    }
}
