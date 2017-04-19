using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for AddUserButton.xaml
    /// </summary>
    public partial class AddUserButton : UserControl, INotifyPropertyChanged
    {
        #region Constructor

        public AddUserButton()
        {
            InitializeComponent();
            FactoryIconPathSourse();
            InitializeDefaultValue();
        }

        #endregion

        #region private field
        private ImageSource _iconHover;
        private ImageSource _iconRegular;
        private ImageSource _iconPressed;
        private ImageSource _iconDisabled;

        private bool _enabled;
        private ImageSource _beckUpIcon;
        #endregion

        #region Property
        public ImageSource IconHover
        {
            get
            {
                return _iconHover;
            }
            set
            {
                _iconHover = value;
                Notify("IconHover");

            }
        }
        public ImageSource IconRegular
        {
            get
            {
                return _iconRegular;
            }
            set
            {
                _iconRegular = value;
                Notify("IconRegular");

            }
        }
        public ImageSource IconDisabled
        {
            get
            {
                return _iconDisabled;
            }
            set
            {
                _iconDisabled = value;
                Notify("IconDisabled");

            }
        }
        public ImageSource IconPressed
        {
            get
            {
                return _iconPressed;
            }
            set
            {
                _iconPressed = value;
                Notify("IconPressed");

            }
        }

        public bool Enabled
        {
            get
            {
                return ThisButton.IsEnabled;
            }
            set
            {
                _enabled = value;
                if ((bool)_enabled)
                {
                    IconRegular = _beckUpIcon;
                    ThisButton.IsEnabled = true;
                }
                else
                {
                    IconRegular = IconDisabled;
                    ThisButton.IsEnabled = false;
                }
            }
        }

        public Dictionary<ButtonStateType, string> IconPathSourse { get; set; }
        #endregion

        #region Method
        public void FactoryIconPathSourse()
        {
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            IconPathSourse = new Dictionary<ButtonStateType, string>();
            IconPathSourse.Add(ButtonStateType.Dissabled, "pack://application:,,,/Icon/AddUserButton/AddUserDissavled.png");
            IconPathSourse.Add(ButtonStateType.Hover, "pack://application:,,,/Icon/AddUserButton/AddUserHover.png");
            IconPathSourse.Add(ButtonStateType.Pressed, "pack://application:,,,/Icon/AddUserButton/AddUserPressed.png");
            IconPathSourse.Add(ButtonStateType.Regular, "pack://application:,,,/Icon/AddUserButton/AddUserRegular.png");
        }

        private void InitializeDefaultValue()
        {
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Hover]);
            bitMap.EndInit();
            IconHover = bitMap;

            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Regular]);
            bitMap.EndInit();
            IconRegular = bitMap;

            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Pressed]);
            bitMap.EndInit();
            IconPressed = bitMap;

            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Dissabled]);
            bitMap.EndInit();
            IconDisabled = bitMap;
            
            _beckUpIcon = IconRegular;
            this.Height = 43;
            this.Width = 45;
        }
        #endregion

        #region eventAnd EventHandler
        private void Notify(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler CxClick;
        private void ThisButton_Click(object sender, RoutedEventArgs e)
        {
            if (CxClick != null)
            {
                CxClick.Invoke(this, e);
            }
            else
            {
                CustomMessageBox.ShowMessageHandler("Click");
            }
        }
        #endregion
    }
}
