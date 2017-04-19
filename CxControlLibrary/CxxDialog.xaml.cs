using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CxControlLibrary
{
    public enum CxDialogResultEnum
        {
            OK, Cancel, Yes, No, Abort, etc
        }
    public enum SizeStyleEnum
    {
        Fixed, ResizableVertical, ResiableHorizontal, Resizable
    }
    /// <summary>
    /// Interaction logic for PresentationWindow.xaml
    /// </summary>
    public partial class CxxDialog : Window
    {
        #region Constructor
        public CxxDialog()
        {

            //BeginInit Component
            InitializeComponent();

            InitCxButtonCollection(ref CxClassificationCollection);
            InitCxObjectList(ref CxObjectList);
            InitCxButtonMain(ref SaveButton);
            InitDiscloseButton(ref DiscloseButton);
            InitPlusButton(ref PlusButton);
            InitCxListBox(ref CxLists);
            //EndInit Component

            //Begin hendled event
            Loaded += CxxDialog_Loaded;
            Closed += CxxDialog_Closed;
            SizeStyle = SizeStyleEnum.ResizableVertical;
            CxAnimationListBox += TestCxDialog_CxAnimationListBox;
            CxAnimationObjectListBox += TestCxDialog_CxAnimationObjectListBox;
            //End handled Event;

            // checked animation
            InitIsClassificationButtonCheked();
            Height = 316;
            IsOpeningCxLists = false;

        }

        #endregion

        #region Field
        private SizeStyleEnum _sizeStyle;
        private bool _dropShadow;
        private bool _isShowTaskBar;
        private CxDialogResultEnum _cxDialogResult;
        private Dictionary<string, bool> _isClassificationButtonCheked;
        private bool _isOpeningCxObjectList;
        private bool _isOpeningCxLists;
        //change Size
        private double _OldSizeHeight;
        private double _NewSizeHeight;
        private double _DiffSizeHeight;
        private bool _firstChange = true;
        private double _oldMinHeightWindow;
        private bool _showSeparator;
        private bool _iconExist;
        private bool _titleExist;
        #endregion

        #region Property
        public CxDialogResultEnum CxDialogResult
        {
            get
            {
                return _cxDialogResult;
            }
            set
            {
                _cxDialogResult = value;
            }
        }
        public SizeStyleEnum SizeStyle
        {
            get
            {
                return _sizeStyle;
            }
            set
            {
                switch ((int)value)
                {
                    case 0:
                        {
                            this.ResizeMode = ResizeMode.NoResize;
                            //this.MaxHeight = 318;
                            //this.MaxWidth = 570;
                            break;
                        }
                    case 1:
                        {
                            this.ResizeMode = ResizeMode.CanResize;
                            this.MaxHeight = 1024;
                            this.MaxWidth = 590;
                            this.MinWidth = 590;
                            break;
                        }
                    case 2:
                        {
                            this.ResizeMode = ResizeMode.CanResize;
                            this.MaxHeight = 318;
                            this.MaxWidth = 1024;
                            break;
                        }

                    case 3:
                        {
                            this.ResizeMode = ResizeMode.CanResize;
                            this.MaxHeight = 1024;
                            this.MaxWidth = 1024;
                            break;
                        }
                       
                }
                _sizeStyle = value;
            }
        }
        public bool IsShowTaskBar
        {
            get
            {

                return _isShowTaskBar;
            }
            set
            {
                this.ShowInTaskbar = value;
                _isShowTaskBar = value;
            }
        }
        public string CxTitle
        {
            get
            {
                return TitleText.Text;
            }
            set
            {
                if (value != string.Empty)
                    _titleExist = true;
                else
                    _titleExist = false;
                ShowSeparator = ShowingSeparator();
                TitleText.Text = value;
            }
        }
        public bool DropShadow
        {
            get
            {
                return _dropShadow;
            }
            set
            {
                if (value)
                {
                    ShadowOptions.OnDropShadow(this);
                }
                else
                {
                    ShadowOptions.OffDropShadow(this);
                }
                _dropShadow = value;
            }
        }
        public ImageSource CxIcon
        {
            get
            {
                return ImageIcon.Source;
            }
            set
            {
                if (value != null)
                    _iconExist = true;
                else
                    _iconExist = false;
                ShowSeparator = ShowingSeparator();
                ImageIcon.Source = value;
            }
        }
        public bool IsOpeningCxObjectList
        {
            get
            {
                return _isOpeningCxObjectList;
            }
            set
            {
                _isOpeningCxObjectList = value;
                if (CxAnimationObjectListBox != null)
                {
                    CxAnimationObjectListBox.Invoke(CxObjectList, new EventArgs());
                }

            }
        }
        public bool IsOpeningCxLists
        {
            get
            {
                return _isOpeningCxLists;
            }
            set
            {
                _isOpeningCxLists = value;
                if (CxAnimationListBox != null)
                {
                    CxAnimationListBox.Invoke(CxLists, new EventArgs());
                }
            }
        }
        public bool ShowSeparator
        {
            get
            {
                return _showSeparator;
            }
            set
            {
                if(value)
                {
                    SeparatorTitle.Visibility = Visibility.Visible;
                }
                else
                {
                    SeparatorTitle.Visibility = Visibility.Hidden;
                }
                _showSeparator = value;
            }
        }
       
        #endregion

        #region Method
        public void InitIsClassificationButtonCheked()
        {
            _isClassificationButtonCheked = new Dictionary<string, bool>();
            _isClassificationButtonCheked.Add("CxListBox", false);
            _isClassificationButtonCheked.Add("CxObjectListBox", false);
            _isClassificationButtonCheked.Add("TwoList", false);
        }

        public static void InitCxObjectList(ref
            CxObjectList cxObjectList)
        {
            var dir = Directory.GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetCurrentDirectory())
                .FullName)
                .FullName)
                .FullName;

            var Icon = new BitmapImage();
            Icon.BeginInit();
            Icon.UriSource = new Uri(dir +
                @"\CxControlLibrary\Icon\ObjectListItem\IconObjectListItem.png");
            Icon.EndInit();

            cxObjectList.ObjectlistItemsCollection.Add(
                new CxControlLibrary
                .ObjectListItem()
                {
                    IsCheked = false,
                    AttachmentName = "email_bar_slide_41_minimum_classification_02",
                    Policy = "Policy1",
                    IconSource = Icon,
                    ColorRect = new SolidColorBrush(Colors.Red)

                });
            cxObjectList.ObjectlistItemsCollection.Add(
                new CxControlLibrary
                .ObjectListItem()
                {
                    IsCheked = false,
                    AttachmentName = "Finale Version_slide_28_04",
                    Policy = "Policy1",
                    IconSource = Icon,
                    ColorRect = new SolidColorBrush(Colors.Yellow)

                });
            cxObjectList.ObjectlistItemsCollection.Add(
                new CxControlLibrary
                .ObjectListItem()
                {
                    IsCheked = false,
                    AttachmentName = "email_bar_slide_41_03",
                    Policy = "Policy1",
                    IconSource = Icon,
                    ColorRect = new SolidColorBrush(Colors.White)

                });
        }

        public static void InitCxButtonCollection(ref
            ClassificationButtonCollection cxClassificationButtonCollection)
        {
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                    MarkImage = ClassificationButton.GetIcon("Red"),
                    Text = "Top secret",
                    Name = "Top_secret",
                    SortIndex = 0

                });
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                    MarkImage = ClassificationButton.GetIcon("RedOrange"),
                    Text = "Top guarded long headl...",
                    Name = "Top_guarded_long_headl",
                    SortIndex = 1

                });
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color.FromRgb(250, 157, 46)),
                    MarkImage = ClassificationButton.GetIcon("Orange"),
                    Text = "Guardeded",
                    Name = "Guardeded",
                    SortIndex = 2

                });

            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                    MarkImage = ClassificationButton.GetIcon("Yellow"),
                    Text = "Classified A",
                    Name = "Classified_A",
                    SortIndex = 3


                });
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
                    MarkImage = ClassificationButton.GetIcon("Green"),
                    Text = "Classified B",
                    Name = "Classified_B",
                    SortIndex = 4

                });
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Color
                .FromRgb(114, 238, 249)),
                    MarkImage = ClassificationButton.GetIcon("Blue"),
                    Text = "General",
                    Name = "General",
                    SortIndex = 5

                });
            cxClassificationButtonCollection.AddCollection(
                new ClassificationButton()
                {
                    Color = new SolidColorBrush(Colors.White),
                    MarkImage = ClassificationButton.GetIcon("White"),
                    Text = "None",
                    Name = "None",
                    SortIndex = 6

                });
            cxClassificationButtonCollection.IsUseMore = true;
            cxClassificationButtonCollection.SortedBy = true;
        }

        public void InitCxButtonMain(ref
            CxControlLibrary.CxRoundButton mainButton)
        {
            mainButton.Enabled = true;


            //ImageButton icon save and change
            var dir = Directory.GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetCurrentDirectory())
                .FullName).FullName)
                .FullName;

            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri(dir + @"\CxControlLibrary\Icon\MainButton\ProtectAndSave.png");
            saveIconBitMap.EndInit();

            mainButton.IconRegular = saveIconBitMap;
            mainButton.IconHover = saveIconBitMap;
            mainButton.IconPressed = saveIconBitMap;
            mainButton.IconDisabled = saveIconBitMap;

            //add to Xaml
            mainButton.Margin = new Thickness(5);
            mainButton.CxClick += MainButton_CxClick;
        }

        public static void InitDiscloseButton(ref
            CxControlLibrary.CxRoundButton subButton)
        {
            subButton.Enabled = true;
            subButton.Label = String.Empty;//if string is Empty MainButton convert to SubButton
            subButton.IsToggle = true;
            subButton.Checked = false;
            var dir = Directory.GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetCurrentDirectory())
                .FullName).FullName)
                .FullName;

            var DetailsconBitMap = new BitmapImage();

            DetailsconBitMap.BeginInit();
            DetailsconBitMap.UriSource = new Uri(dir + @"\CxControlLibrary\Icon\RoundButton\Details.png");
            DetailsconBitMap.EndInit();

            subButton.IconRegular = DetailsconBitMap;
            subButton.IconHover = DetailsconBitMap;
            subButton.IconPressed = DetailsconBitMap;
            subButton.IconDisabled = DetailsconBitMap;
        }

        public static void InitPlusButton(ref
            CxControlLibrary.CxRoundButton subButton)
        {
            subButton.Enabled = true;
            subButton.Label = String.Empty;//if string is Empty MainButton convert to SubButton

            //Change Beackgroound
            subButton.BackgroundRegular = new SolidColorBrush(Colors
                .White);

            subButton.BackgroundHover = new SolidColorBrush(Color
                .FromRgb(198, 233, 253));

            subButton.BackgroundPressed = new SolidColorBrush(Color
                .FromRgb(114, 179, 216));

            subButton.BackgroundDisabled = new SolidColorBrush(Color
                .FromRgb(183, 183, 183));

            var dir = Directory.GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetCurrentDirectory())
                .FullName).FullName)
                .FullName;

            var plusIconBitMap = new BitmapImage();

            plusIconBitMap.BeginInit();
            plusIconBitMap.UriSource = new Uri(dir +
                @"\CxControlLibrary\Icon\RoundButton\Plus.png");
            plusIconBitMap.EndInit();

            subButton.IconRegular = plusIconBitMap;
            subButton.IconHover = plusIconBitMap;
            subButton.IconPressed = plusIconBitMap;
            subButton.IconDisabled = plusIconBitMap;

        }

        public static void InitCxListBox(ref
            CxListBox CListBox)
        {
            var GrupCopyBitMap = new BitmapImage();
            GrupCopyBitMap.BeginInit();
            GrupCopyBitMap.UriSource = new Uri("pack://application:,,,/Icon/CxListBox1/GroupCopy.png");
            GrupCopyBitMap.EndInit();

            var UserBitMap = new BitmapImage();

            UserBitMap.BeginInit();
            UserBitMap.UriSource = new Uri("pack://application:,,,/Icon/CxListBox1/user.png");
            UserBitMap.EndInit();

            bool testBool = false;
            Brush color;
            string item = "item";
            BitmapImage image;
            for (int i = 0; i < 10; i++)
            {
                if (testBool)
                {
                    color = new SolidColorBrush(Colors.Red);
                    image = GrupCopyBitMap;
                }
                else
                {
                    color = new SolidColorBrush(Colors.Black);
                    image = UserBitMap;
                }
                testBool = !testBool;
                CListBox.AddOptions(new Options(item + " " + i.ToString(),
                    color, new SolidColorBrush(Colors.White), i));
                CListBox.AddUsers(new Users(item + " " + i.ToString(),
                    image, i));
            }
            
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();
           
        }

        public double GetSizeCxList()
        {
            double sum = CxDialogTitle.Height + CxClassificationCollection.Height +
                 CxObjectList.Height + BorderConditions.Height + BottomStakPanel.Height;
            return this.Height - sum;
        }

        public double ChangeWindowHeight()
        {
            bool L = IsOpeningCxLists;
            bool O = IsOpeningCxObjectList;
            double WindowHeight = 316;

            //Max Height
            if (!L & !O) //00
            {
                WindowHeight = 316;
                if (SizeStyle == SizeStyleEnum.ResizableVertical)
                {
                    WindowHeight = 316 + 15;
                }
            }
            else if (!L && O)//01
            {
                WindowHeight = 458;
            }
            else if (L && !O)//10
            {
                WindowHeight = 622;
                //if (SizeStyle == SizeStyleEnum.ResizableVertical)
                //{
                //    WindowHeight = 622+20;
                //}
            }
            else if (L && O)
            {
                WindowHeight = 664;
                //if (SizeStyle == SizeStyleEnum.ResizableVertical)
                //{
                //    WindowHeight = 622 + 20;
                //}
            }

            return WindowHeight;
        }

        public void ChangeAnimationHeight(double oldHeight,double newHeight,bool isOpen)
        {
            DoubleAnimation animation = new DoubleAnimation();
            if (isOpen)
            {
                animation.From = oldHeight;
                animation.To = newHeight;
            }
            else
            {
                animation.From = oldHeight;
                animation.To = newHeight;
            }
            animation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Rectangle.HeightProperty, animation);
        }

        public bool ShowingSeparator()
        {
           return _iconExist && _titleExist;
        }

        #endregion

        #region Event
        public event EventHandler CxClosed;
        public event RoutedEventHandler CxLoaded;
        public event EventHandler CxAnimationListBox;
        public event EventHandler CxAnimationObjectListBox;
        #endregion

        #region Handlers
        private void MainButton_CxClick(object sender, EventArgs e)
        {
            CxDialogResult = CxDialogResultEnum.Yes;
            MessageBox.Show(CxDialogResult.ToString());
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CxDialogTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
        private void CxxDialog_Closed(object sender, EventArgs e)
        {
            if (CxClosed != null)
            {
                CxClosed.Invoke(this, e);
            }
        }
        private void CxxDialog_Loaded(object sender, RoutedEventArgs e)
        {
            if (CxLoaded != null)
            {
                CxLoaded.Invoke(this, e);
            }
        }
        private void TestCxDialog_CxAnimationObjectListBox(object sender, EventArgs e)
        {
            double oldHeight = this.Height;

            var list = sender as CxObjectList;
            list.AnimationOpening(IsOpeningCxObjectList);

            double newHeight = ChangeWindowHeight();
            ChangeAnimationHeight(oldHeight, newHeight, IsOpeningCxObjectList);
        }
        private void TestCxDialog_CxAnimationListBox(object sender, EventArgs e)
        {
            double oldHeight = this.Height;
            DiscloseButton.Checked = !DiscloseButton.Checked;
            var list = sender as CxListBox;
            CxLists.AnimationOpening(IsOpeningCxLists);
            ChangeWindowHeight();
            double newHeight = ChangeWindowHeight();
            ChangeAnimationHeight(oldHeight, newHeight, IsOpeningCxLists);
        }
        private void CxClassificationCollection_CxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as CxControlLibrary.ClassificationButtonCollection;
            if (list.SelectedItem.Name == "Classified_B")
            {
                IsOpeningCxObjectList = !IsOpeningCxObjectList;
            }
            else if (list.SelectedItem.Name == "None")
            {
                CustomMessageBox.Show();
            }
        }
        private void DiscloseButton_CxClick(object sender, EventArgs e)
        {
            IsOpeningCxLists = !IsOpeningCxLists;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CxLists.AnimationOpening(null);
            if (IsOpeningCxLists)
            {
                CxLists.Height = HeightListChanged.ActualHeight;

                //CxLists.ActualListHeight = CxLists.Height;
            }
        }
        private void StackLayout_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (!_firstChange)
            //{
            //    if (_oldMinHeightWindow > StackLayout.ActualHeight)
            //    {
            //        // this.MinHeight = _oldMinHeightWindow;
            //        this.Height = StackLayout.ActualHeight;
            //        // this.MaxHeight = StackLayout.ActualHeight;
            //    }
            //    else
            //    {
            //        //_oldMinHeightWindow = this.MinHeight;
            //        this.MinHeight = StackLayout.ActualHeight;
            //        // this.MaxHeight = StackLayout.ActualHeight;
            //    }
            //}
        }

        #endregion

       
    }
}
