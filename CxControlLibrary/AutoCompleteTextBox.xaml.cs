using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for AutoCompleteTextBox.xaml
    /// </summary>    
    public partial class AutoCompleteTextBox : Canvas
    {
        #region Members
        private VisualCollection controls;
        private System.Windows.Controls.TextBox textBox;
        private ComboBox comboBox;
        private ObservableCollection<AutoCompleteEntry> autoCompletionList;
        private System.Timers.Timer keypressTimer;
        private delegate void TextChangedCallback();
        private bool insertText;
        private int delayTime;
        private int searchThreshold;
        private string _defaultText;
        #endregion

        #region Property
        public bool IsComoBox
        {
            set
            {
                if (value)
                {
                    Foreground = new SolidColorBrush(Colors.Black);
                    textBox.MouseEnter -= TextBox_MouseEnter;
                    textBox.MouseLeave -= TextBox_MouseLeave;
                    _defaultText = "";
                }
            }
        }
        public string Text
        {
            get { return textBox.Text; }
            set
            {
                insertText = true;
                textBox.Text = value;

            }
        }
        public Thickness BorderThickness
        {
            get
            {
                return textBox.BorderThickness;
            }
            set
            {
                textBox.BorderThickness = value;
            }
        }
        public Brush BorderBrush
        {
            get
            {
                return textBox.BorderBrush;
            }
            set
            {
                textBox.BorderBrush = value;
            }
        }
        public Brush Foreground
        {
            get
            {
                return textBox.Foreground;
            }
            set
            {
                textBox.Foreground = value;
            }
        }
        public String DefaultText
        {
            get
            {
                return _defaultText;
            }
            set
            {
                _defaultText = value;
            }
        }
        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }
        public ObservableCollection<AutoCompleteEntry> AutoCompletionList
        {
            get
            {
                return autoCompletionList;
            }
            set
            {
                autoCompletionList = value;
            }
        }
        public int Threshold
        {
            get { return searchThreshold; }
            set { searchThreshold = value; }
        }

        public void AddItem(AutoCompleteEntry entry)
        {
            autoCompletionList.Add(entry);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != comboBox.SelectedItem)
            {
                insertText = true;
                ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
                textBox.Text = cbItem.Content.ToString();
            }
        }

        #endregion

        #region Constructor
        public AutoCompleteTextBox()
        {
            controls = new VisualCollection(this);
            InitializeComponent();

            autoCompletionList = new ObservableCollection<AutoCompleteEntry>();
            searchThreshold = 2;        // default threshold to 2 char

            // set up the key press timer
            keypressTimer = new System.Timers.Timer();
            keypressTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);

            // set up the text box and the combo box
            comboBox = new ComboBox();
            comboBox.IsSynchronizedWithCurrentItem = true;
            comboBox.IsTabStop = false;
            comboBox.SelectionChanged += new SelectionChangedEventHandler(comboBox_SelectionChanged);

            textBox = new System.Windows.Controls.TextBox();
            textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
            textBox.VerticalContentAlignment = VerticalAlignment.Center;

            controls.Add(comboBox);
            controls.Add(textBox);
            //myChenge
                Foreground = new SolidColorBrush(Color.FromArgb( 128 , 83, 83, 83));
                textBox.FontFamily = new FontFamily("Roboto");
                textBox.MouseEnter += TextBox_MouseEnter;
                textBox.MouseLeave += TextBox_MouseLeave;
                _defaultText = "  Enter policy name";
                textBox.Text = _defaultText;
                textBox.FontStyle = FontStyles.Italic;


        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if(textBox.Text==String.Empty)
            {
                textBox.Text = DefaultText;
                Foreground = new SolidColorBrush(Color.FromArgb(128, 83, 83, 83));
                textBox.FontFamily = new FontFamily("Roboto");
                textBox.FontStyle = FontStyles.Italic;
            }
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (textBox.Text == DefaultText)
            {
                textBox.Text = String.Empty;
                Foreground = new SolidColorBrush(Colors.Black);
                textBox.FontStyle = FontStyles.Normal;
            }
        }
        #endregion

        #region Methods
        

        private void TextChanged()
        {
            try
            {
                comboBox.Items.Clear();
                if (textBox.Text.Length >= searchThreshold)
                {
                    foreach (AutoCompleteEntry entry in autoCompletionList)
                    {
                        foreach (string word in entry.KeywordStrings)
                        {
                            if (word.StartsWith(textBox.Text, StringComparison.CurrentCultureIgnoreCase))
                            {
                                ComboBoxItem cbItem = new ComboBoxItem();
                                cbItem.Content = entry.ToString();
                                comboBox.Items.Add(cbItem);
                                break;
                            }
                        }
                    }
                    comboBox.IsDropDownOpen = comboBox.HasItems;
                }
                else
                {
                    comboBox.IsDropDownOpen = false;
                }
            }
            catch { }
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            keypressTimer.Stop();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new TextChangedCallback(this.TextChanged));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // text was not typed, do nothing and consume the flag
            if (insertText == true) insertText = false;

            // if the delay time is set, delay handling of text changed
            else
            {
                if (delayTime > 0)
                {
                    keypressTimer.Interval = delayTime;
                    keypressTimer.Start();
                }
                else TextChanged();
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            textBox.Arrange(new Rect(arrangeSize));
            comboBox.Arrange(new Rect(arrangeSize));
            return base.ArrangeOverride(arrangeSize);
        }

        protected override Visual GetVisualChild(int index)
        {
            return controls[index];
        }

        protected override int VisualChildrenCount
        {
            get { return controls.Count; }
        }
        #endregion
    }

  

    public partial class AutoCompleteTextBox
    {
        public AutoCompleteTextBox Clone()
        {
            return (AutoCompleteTextBox)this.MemberwiseClone();
        }
        public bool ReadOnly
        {
            get
            {
                return textBox.IsReadOnly;
            }
            set
            {
                textBox.IsReadOnly = value;
            }
        }
    }
}
