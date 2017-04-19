using System;
using System.Collections.Generic;
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
    /// Interaction logic for ObjectListItem.xaml
    /// </summary>
    public partial class ObjectListItem : UserControl
    {
        static FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(
            new PropertyChangedCallback(ChangedCallbackMethod));

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected",
            typeof(bool),
            typeof(ObjectListItem),
            metadata);

        private static void ChangedCallbackMethod(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ObjectListItem This = d as ObjectListItem;

            if ((bool)(e.NewValue as bool?))
            {
                This.Body.Style = (Style)This.FindResource("ChekedGrid");
                This.AttachmentNames.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                This.Policys.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                This.Body.Style = (Style)This.FindResource("UnChekedGrid");
                This.AttachmentNames.Foreground = new SolidColorBrush(Color.FromRgb(83, 83, 83));
                This.Policys.Foreground = new SolidColorBrush(Color.FromRgb(83, 83, 83));

            }
        }

        public ObjectListItem()
        {
            InitializeComponent();
        }

        public ObjectListItem(bool? isCheked,
            string attachmentName, string policy, Brush color)
        {
            InitializeComponent();
            IsCheked = isCheked;
            AttachmentName = attachmentName;
            Policy = policy;
            ColorRect = color;
        }


        public bool? IsCheked
        {
            get
            {
                return ChekBoxs.IsCheked;
            }
            set
            {
                ChekBoxs.IsCheked = value;
            }
        }
        public string AttachmentName
        {
            get
            {
                return AttachmentNames.Text;
            }
            set
            {
                AttachmentNames.Text = value;
            }
        }
        public string Policy
        {
            get
            {
                return Policys.Text;
            }
            set
            {
                Policys.Text = value;
            }
        }
        public Brush ColorRect
        {
            get
            {
                return Rect.Fill;
            }
            set
            {
                Rect.Fill = value;
            }
        }
        public bool IsSelected
        {
            get
            {
                return (bool)(GetValue(IsSelectedProperty) as bool?);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
        public ImageSource IconSource
        {
            get
            {
                return Icon.Source;
            }
            set
            {
                Icon.Source = value;
            }

        }
    }
}
