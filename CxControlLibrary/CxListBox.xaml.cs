using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for CxListBox.xaml
    /// </summary>
    public partial class CxListBox : UserControl, INotifyPropertyChanged
    {
        #region Constructor

        public CxListBox()
        {
            InitializeComponent();
            UsersItems = new ObservableCollection<Users>();
            OptionsItems = new ObservableCollection<Options>();
            ListArrow = new ObservableCollection<BindingImage>();
            DataContext = this;
            Height = 0;
            Arrow.Visibility = Visibility.Collapsed;
            //ArrowList.ItemsSource = ListArrow;
        }

        #endregion

        #region Field

        private static int arrowCounter = 0;

        private ObservableCollection<Users> _users;
        private ObservableCollection<Options> _options;

        private string _actionsLabel;
        private string _rolesLabel;
        private string _rolesLabelCopy;

        private bool _isOpening = false;
        private bool _dropLeftListShadow;
        private bool _dropRightListShadow;
        private ObservableCollection<BindingImage> _listArrow;

        #endregion

        #region Property
        public bool IsOpened
        {
            get
            {
                return _isOpening;
            }
            set
            {
                _isOpening = value;
                if(value)
                {
                    SetArrow();
                }
            }
        }
        public ObservableCollection<Users> UsersItems
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                Notify("UsersItems");
            }
        }
        public ObservableCollection<Options> OptionsItems
        {
            get
            {
               
                return _options;
            }
            set
            {
                _options = value;
                Notify("OptionsItems");
            }
        }
        public ObservableCollection<BindingImage> ListArrow
        {
            get
            {
                return _listArrow;
            }
            set
            {
                _listArrow = value;
                Notify("ListArrow");
            }
        }
        public ItemCollection ListOptionsItems
        {
            get
            {
                return ListBoxOpions.Items;
            }
        }
        public ItemCollection ListUserItems
        {
            get
            {
                return ListBoxUsers.Items;
            }
        }
        public ListBox ListOptions
        {
            get
            {
                return ListBoxOpions;
            }
        }
        public ListBox ListUsers
        {
            get
            {
                return ListBoxUsers;
            }
        }
        public object SelectedUser
        {
            get
            {
                return ListBoxUsers.SelectedItem as CxListBoxItem;
            }
            set
            {
                ListBoxUsers.SelectedItem = value;

            }
        } //Selected Left List
        public object SelectedOptions
        {
            get
            {
                return ListBoxOpions.SelectedItem as CxListBoxItem;
            }
            set
            {
                ListBoxOpions.SelectedItem = value;
            }
        } //Selected Right List
        public string ActionsLabel
        {
            get
            {
                return _actionsLabel;
            }
            set
            {
                ActionsTextBlock.Text = value;
                _actionsLabel = value;
            }
        }
        public string RolesLabel
        {
            get
            {
                return _rolesLabel;
            }
            set
            {
                RolesTextBlockRoles.Text = value;
                _rolesLabel = value;
            }
        }
        public string RolesLabelCopy
        {
            get
            {
                return _rolesLabel;
            }
            set
            {
                RolesTextBlockCopy.Text = value;
                _rolesLabelCopy = value;
            }
        }
        public CxListBoxItem OldUserItem { get; set; }// = null;
        public CxListBoxItem NewUserItem { get; set; }// = null;
        public int OldUserIndex { get; set; }// = null;
        public int NewUserIndex { get; set; }
        public CxListBoxItem OldOptionsItem { get; set; }// = null;
        public CxListBoxItem NewOptionsItem { get; set; }// = null;
        public int SelectedUserIndex
        {
            get
            {
                return ListBoxUsers.SelectedIndex;
            }
            set
            {
                ListBoxUsers.SelectedIndex = value;
                ListArrow[value].ShowImage();
            }
        }
        public int SelectedOptionsIndex
        {
            get
            {
                return ListBoxOpions.SelectedIndex;
            }
            set
            {
                ListBoxOpions.SelectedIndex = value;
            }
        }
        public bool DropLeftListShadow
        {
            get
            {
                return _dropLeftListShadow;
            }
            set
            {
                if (value)
                {
                    ShadowOptions.OnDropShadow(ListBoxOpions);
                }
                else
                {
                    ShadowOptions.OffDropShadow(ListBoxOpions);
                }
                _dropLeftListShadow = value;
            }
            
        }  //DropShadow in Left List
        public bool DropRightListShadow
        {
            get
            {
                return _dropRightListShadow;
            }
            set
            {
                if(value)
                {
                    ShadowOptions.OnDropShadow(ListBoxUsers);
                }
                else
                {
                    ShadowOptions.OffDropShadow(ListBoxUsers);
                }
                _dropRightListShadow = value;
            }
        } //DropShadow in Right List
        public int SelectionArrowIndex
        {
            get
            {
                return _selectionArrowIndex;
            }
            set
            {
                _selectionArrowIndex = value;

            }
        }
        #endregion

        #region DependesyProperty
        public static DependencyProperty ListHeightProperty = DependencyProperty.Register("ListHeight", typeof(double), typeof(CxListBox));
        //public double ListHeight
        //{
        //    get
        //    {
        //        //return _listHeight;
        //        return (double)GetValue(ListHeightProperty);
        //    }
        //    set
        //    {
        //        if (value > 0)
        //        {
        //            ListOptions.MinHeight = value;
        //            ListOptions.MaxHeight = 195;
        //            ListUsers.MinHeight = value;
        //            ListUsers.MaxHeight = 195;
        //        }
        //        else
        //        {
        //            ListOptions.MinHeight = Math.Abs(value);
        //            ListOptions.Height = Math.Abs(value);
        //            ListUsers.MinHeight = Math.Abs(value);
        //            ListUsers.Height = Math.Abs(value);
        //        }
        //        Height = value+85;
        //        ListOptions.Height = value;
        //        ListUsers.Height = value;
        //        SetValue(ListHeightProperty, value);
        //    }
        //}

        //public double ActualListHeight
        //{
        //    get
        //    {
        //        return _actualListHeight;
        //    }
        //    set
        //    {
        //        ListOptions.MinHeight = value;
        //        ListUsers.MinHeight = value;
        //        ListOptions.MaxHeight = value;
        //        ListUsers.MaxHeight = value;
        //        _actualListHeight = value;
        //    }
        //}
        #endregion

        #region EventAndHandlers


        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event SelectionChangedEventHandler SelectionChangedOptions;
        private void ListBoxOpions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                SelectedOptionsIndex = ListBoxOpions.SelectedIndex;
                SelectedOptions = ListBoxOpions.SelectedItem as CxListBoxItem;
            //create nulloptions if new options null
            if (NewOptionsItem == null)
            {
                NewOptionsItem = new Options(OptionsItems[0].Option,
                    new SolidColorBrush(Colors.Black),
                    new SolidColorBrush(Colors.White), 0).CxListBoxItem;
                SelectedOptionsIndex = ListBoxOpions.SelectedIndex;
                SelectedOptions = OptionsItems[0].CxListBoxItem;
            }

                
                //create old Options
                OldOptionsItem = NewOptionsItem;
               // var tmp = NewOptionsItem;
                NewOptionsItem = SelectedOptions as CxListBoxItem;


            (SelectedOptions as CxListBoxItem ).Selected= true;
            OldOptionsItem.Selected = false;

            //Hendled Event
            if (SelectionChangedOptions != null)
            {
                SelectionChangedOptions.Invoke(this, e);
            }

        }
        int secondSet = 0;
        private int _selectionArrowIndex;
        private double _actualListHeight;

        public event SelectionChangedEventHandler SelectionChangedUsers;
        private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUserIndex = ListBoxUsers.SelectedIndex;
            SelectedUser = ListBoxUsers.SelectedItem as CxListBoxItem;

            if (NewUserItem == null)
            {
                NewUserItem = new Users(UsersItems[0].User,
                UsersItems[0].Image, 0).CxListBoxItem;
            }

                
                OldUserItem = NewUserItem;

            // hide arrow
                OldUserIndex = ListUsers.Items.IndexOf(OldUserItem);
            //if (OldUserIndex != -1)
            //{
            //    (ListBoxUsers.Items[OldUserIndex] as CxListBoxItem).HideArrow();
            //}

            // show arrow
            NewUserItem = SelectedUser as CxListBoxItem;
           
            NewUserIndex = ListUsers.Items.IndexOf(NewUserItem);
            //(ListBoxUsers.Items[NewUserIndex] as CxListBoxItem).ShowArrow();
            SetArrow();
            //if (secondSet>0)
            ////scruling
            //{
            //    ArrowList.IsEnabled = true;
            //    ArrowList.SelectedIndex = ListBoxUsers.SelectedIndex;

            //    var itemUser = GetListBoxItem(ListUsers);
            //    var itemArrow = GetListBoxItem(ArrowList);
            //    itemUser.Focus();
            //    itemArrow.Focus();
            //    ArrowList.IsEnabled = false;
            //    ArrowList.SelectedIndex = -1;
            //}
            //secondSet++;
            ////end scrulling

            if (SelectionChangedUsers != null)
            {
                SelectionChangedUsers.Invoke(this, e);
            }
        }

        private void SearchButton1_Click(object sender, RoutedEventArgs e)
        {
            string value = AutoCompleteOptions.Text;
            CxListBoxItem FocusItem = null;
            if (SearchElementOptions(value) != null)
            {
                FocusItem = SearchElementOptions(value);
            }
            else
            {
                MessageBox.Show("did not match any documents.");
                return;
            }
            ListBoxItem lbi = (ListBoxItem)ListBoxOpions
                .ItemContainerGenerator
                .ContainerFromItem(FocusItem);
            try
            {
                lbi.Focus();
                SelectedOptions = FocusItem;
                FocusItem.Selected = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Dosen't Exist");
            }
        }

        private void SearchButton2_Click(object sender, RoutedEventArgs e)
        {
            string value = AutoCompleteUsers.Text;
            CxListBoxItem FocusItem = null;
            if (SearchElementOptions(value) != null)
            {
                FocusItem = SearchElementUsers(value);
            }
            else
            {
                MessageBox.Show("did not match any documents.");
                return;
            }
            ListBoxItem lbi = (ListBoxItem)ListBoxUsers
                .ItemContainerGenerator
                .ContainerFromItem(FocusItem);
            try
            {
                lbi.Focus();
                SelectedUser = FocusItem;
                FocusItem.Selected = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Dosen't Exist");
            }
        }

        private void AutoCompleteOptions_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            textBox.Text = "";
            textBox.Foreground = new SolidColorBrush(Colors.Black);
            textBox.FontStyle = FontStyles.Normal;
        }
        private void AutoCompleteOptions_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search...";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
                textBox.FontStyle = FontStyles.Italic;
            }
        }
        private void ArrowList_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                   
                }
        #endregion

        #region Method
        public Thickness SetArrowCordinates()
        {
            return new Thickness(0, ( Convert.ToDouble(ListUsers.ActualHeight) / 2 ), 0, 0);
        }
        public void AddOptions(Options options)
        {
            OptionsItems.Add(options);
            ListBoxOpions.Items.Add(options.CxListBoxItem);
        }
        public void AddUsers(Users users)
        {
            UsersItems.Add(users);
            ListBoxUsers.Items.Add(users.CxListBoxItem);
            var bindImg = new BindingImage();
            ListArrow.Add(bindImg);

        }   
        private CxListBoxItem SearchElementOptions(string value)
        {
            Options searchingElement=null;
            foreach (Options op in OptionsItems)
            {
                if (op.Option == value)
                {
                    searchingElement = op;
                    break;
                }
            }
            if (searchingElement == null)
                return new CxListBoxItem();
            else
                return searchingElement.CxListBoxItem;
        }
        private CxListBoxItem SearchElementUsers(string value)
        {
            Users searchingElement = null;
            foreach (Users op in UsersItems)
            {
                if (op.User == value)
                    searchingElement = op;
            }
            if (searchingElement == null)
                return new CxListBoxItem();
            else
                return searchingElement.CxListBoxItem;
        }
        public void AnimationOpening(bool? isOpening) //change this.height to listheisght
        {
            if (isOpening == null)
            {
                this.BeginAnimation(Rectangle.HeightProperty, null);
                return;
            }
            IsOpened = (bool)isOpening;
            //ListHeight = 220;
            DoubleAnimation animation = new DoubleAnimation();
            if ((bool)isOpening)
            {

                //animation.From = this.Height;
                animation.From = this.Height;
                animation.To = 305;
            }
            else
            {
                //animation.From = this.Height;
                animation.From = this.Height;
                animation.To = 0;
            } 
            
            animation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Rectangle.HeightProperty, animation);
        }       
        public static ListBoxItem GetListBoxItem(ListBox listBox)
        {
            object selectedItem = listBox.SelectedItem;
            ListBoxItem selectedListBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(selectedItem) as ListBoxItem;
            return selectedListBoxItem;
        }
        public void HideAllArrow()
        {
            foreach(CxListBoxItem item in ListUserItems)
            {
                item.HideArrow();
            }
        }
        public void SetArrow()
        {
            if (SelectedUserIndex != -1)
            {
                switch (SelectionArrowIndex)
                {
                    case -1:
                        HideAllArrow();
                        CxListBoxItem.HidingArrow = true;
                        Arrow.Visibility = Visibility.Collapsed;
                        break;
                    case -2:

                        HideAllArrow();
                        CxListBoxItem.HidingArrow = true;
                        Arrow.Margin = SetArrowCordinates();
                        Arrow.Visibility = Visibility.Visible;
                        break;
                    default:
                        CxListBoxItem.HidingArrow = false;
                        HideAllArrow();
                        (ListUsers.Items[SelectedUserIndex] as CxListBoxItem).ShowArrow();
                        Arrow.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }
        #endregion

        private void ListBoxUsers_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //BackRectangle.Height=ListBoxUsers.Height + 50;
        }
    }

    public class BindingImage:INotifyPropertyChanged
    {
        #region Constructor
        public BindingImage()
        {
            _img = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("Icon/CxListBox1/ArrowCxList.png", UriKind.Relative);
            bi.EndInit();
            _img.Source = bi;
            _img.Visibility = Visibility.Hidden; ///Hide
            _number = counter++;
        }
        #endregion

        #region Field
        Image _img;
        private bool _haveArrow;
        int _number;
        static int counter = 0;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Handlers
        public void Notify(string property)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion

        #region Property
        public ImageSource ImgSourse
        {
            get
            {
                return _img.Source;
            }
            set
            {
                _img.Source = value;
                Notify("ImgSourse");
            }
        }

        public Visibility ImgVisibility
        {
            get
            {
                return _img.Visibility;
            }
            set
            {
                _img.Visibility = value;
                Notify("ImgVisibility");
            }
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        #endregion

        #region Method
       
        public void ShowImage()
        {
            ImgVisibility = Visibility.Visible;
            
        }
        public void HideImage()
        {
            ImgVisibility = Visibility.Hidden;
        }

        #endregion

    }




}

