using CxControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace TestCCPControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CxxDialog win = new CxxDialog();
            win.SizeToContent = SizeToContent.Width;
            win.IsShowTaskBar = true;


            win.DropShadow = true;
            
            //this.Hide();
          //  win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           // win.Close();
            FirstInit();
            //SecondInit();
            win.Show();
            //win.CxLoaded += Win_CxLoaded;
            //win.CxClosed += Win_CxClosed;


        }

  



      

        /// <summary>
        /// How Create Control in C#
        /// </summary>
        public void FirstInit()
        {
            //InitializeCustomListBox();
            //InitializeClassificationButton(); //How Crate Classification Button
            //InitializeClassificationButton1();
            //InitializeClasificationButtonCollection(); //How Create Clasification Button Collection
            //InitializeClasificationButtonCollection2();
            //InitializeMainButton(); //How Create MainButton
            //InitializeMainButton2();
            ////InitializeMainButton3();
            //InitializeSubButton(); //How Create Sub Button
            //InitializeAddUserButton(); //How Create AddUserButton
            IntializeCxListBox();
           // InitializeTextBox(); //How Crate TextBox

            //InitializeRectComboBoxes(); //How Create RectComboBox
            //InitializeRoundComboBoxes(); //How Create RoundComboBox
           // InitializeObjectList(); //How Create ObjectList
            //InintializeClassificationBar();
        }
        #region Method

        private void InintializeClassificationBar()
        {
            var classificationBar = new ClassificationBar();
            classificationBar.EmailBodyText = "Hey email body";
            classificationBar.ClassificationText = "Hey classification text";
            classificationBar.PolicyText = "Hey Policy text";
            XAMLStackPanel.Children.Add(classificationBar); 

        }
        private void IntializeCxListBox()
        {
            var CListBox = new CxListBox();
            CListBox.HorizontalAlignment = HorizontalAlignment.Center;
            CListBox.ActionsLabel = "Actions Label";
            CListBox.RolesLabel = "Roles Label";
            CListBox.RolesLabelCopy = "Roles Label Copy";

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
            BitmapImage image=null;
            for (int i = 0; i < 15; i++)
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

                CListBox.SelectedOptions = CListBox.ListOptionsItems[0] as CxListBoxItem;
                CListBox.SelectedUser = CListBox.ListUserItems[0] as CxListBoxItem;

                //CListBox.ListOptions.SelectedItem;
            }
            CListBox.AddUsers(new Users(item + " " + 11.ToString(),
                    image, 11));
            // var a = CListBox.UsersItems;
            XAMLStackPanel.Children.Add(CListBox);


            CListBox.DropLeftListShadow = true;
            CListBox.DropRightListShadow = false;

            
            CListBox.Background = new SolidColorBrush(Colors.Red);

            CListBox.ActionsLabel = "MyAction";
            CListBox.RolesLabel = "MyRoles";
            CListBox.RolesLabelCopy = "MyRoles Copy";


            //CListBox.ListHeight = 222;
            CListBox.SelectionArrowIndex = -2;
            CListBox.IsOpened = true;
           // CListBox.FactoryArrowList(CListBox.UsersItems.Count);
        }
        private void InitializeClassificationButton()
        {
            var ClassificationButton = new ClassificationButton();
            ClassificationButton.HorizontalAlignment = HorizontalAlignment.Left;
            ClassificationButton.VerticalAlignment = VerticalAlignment.Center;
            ClassificationButton.Color = new SolidColorBrush(Colors.Green);

            // add to Xaml
            ClassificationButton.Text = "ClassificationButtonTest";
            ClassificationButton.Name = "ClassificationButton";
            ClassificationButton.Margin = new Thickness(5);
           // ClassificationButton.Highlighted = true;
            ClassificationButton.Background = new SolidColorBrush(Colors.Black);

            //ClassificationButton.CxMouseEnter += ClassificationButton_CxMouseEnter;
            //ClassificationButton.CxMouseLeave += ClassificationButton_CxMouseLeave;
            //ClassificationButton.CxClick += ClassificationButton_CxClick;
            //ClassificationButton.CxRightClick += ClassificationButton_CxRightClick;
            //ClassificationButton.CxDoubleClick += ClassificationButton_CxDoubleClick;

            ClassificationButton.DropShadow = false;

            XAMLStackPanel.Children.Add(ClassificationButton); 

        }
        private void InitializeClassificationButton1()
        {
            var ClassificationButton1 = new ClassificationButton();
            ClassificationButton1.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButton1.VerticalAlignment = VerticalAlignment.Center;
            ClassificationButton1.Color = new SolidColorBrush(Colors.Green);

            // add to Xaml
            ClassificationButton1.Text = "ClassificationButtonTest";
            ClassificationButton1.Name = "ClassificationButton";
            ClassificationButton1.Margin = new Thickness(5);
            ClassificationButton1.Highlighted = false;

            XAMLStackPanel.Children.Add(ClassificationButton1);

        }
        private void InitializeClasificationButtonCollection()
        {
            var ClassificationButtonCollection = new CxControlLibrary.ClassificationButtonCollection();
            ClassificationButtonCollection.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButtonCollection.VerticalAlignment = VerticalAlignment.Center;

            ClassificationButtonCollection.Title = "My Title";

            ClassificationButtonCollection.BackgroundColor = new SolidColorBrush(Colors.Black);

            

            ClassificationButtonCollection.DropShadow = false;

            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "ATop secret",
                Name = "testBtn1",
                SortIndex = 6,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2",
                SortIndex = 5,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3",
                SortIndex = 4,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //4
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                Text = "Guarded",
                Name = "testBtn4",
                SortIndex = 3,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //5
            {
                Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
                Text = "Classified B",
                Name = "testBtn5",
                SortIndex = 2,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "Top secret",
                Name = "None",
                SortIndex = 1,
                Container = ClassificationButtonCollection
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "None",
                Name = "None",
                SortIndex = 0,
                Container = ClassificationButtonCollection
            });

            
            XAMLStackPanel.Children.Add(ClassificationButtonCollection); // add to Xaml
            
            ClassificationButtonCollection.Name = "ClassificationButtonCollection";
            ClassificationButtonCollection.Margin = new Thickness(5);
            ClassificationButtonCollection.IsUseMore = false; //visible or hiden button more

        }
        private void InitializeClasificationButtonCollection2()
        {
            var ClassificationButtonCollection2 = new CxControlLibrary.ClassificationButtonCollection();
            ClassificationButtonCollection2.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButtonCollection2.VerticalAlignment = VerticalAlignment.Center;


            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top secret",
                Name = "testBtn1"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //4
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                Text = "Guarded",
                Name = "testBtn4"
            });
            ClassificationButtonCollection2.Title = "Hey Title";


            XAMLStackPanel.Children.Add(ClassificationButtonCollection2); // add to Xaml
            ClassificationButtonCollection2.Name = "ClassificationButtonCollection2";
            ClassificationButtonCollection2.Margin = new Thickness(5);
            ClassificationButtonCollection2.IsUseMore = true; //visible or hiden button more

        }
        private void InitializeMainButton()
        {
            var MainButton = new CxControlLibrary.CxRoundButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;


            //ImageButton icon save and change
           var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri("pack://application:,,,/Icon/MainButton/ProtectAndSave.png");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);


            MainButton.ToolTip = "Hey i am ToolTip";

            MainButton.Tag = "MyTag";

            MainButton.BackgroundDisabled = new SolidColorBrush(Colors.Red);


            MainButton.Label = String.Empty;

            MainButton.DropShdow = true;



        }
        private void InitializeMainButton2()
        {
            var MainButton = new CxControlLibrary.CxRoundButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;
            MainButton.Width = 300;
            MainButton.Label = "Hello how you do?";
            MainButton.FixedWidth = 5;
            //ImageButton icon save and change
            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri("pack://application:,,,/tempIco.PNG");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);
        }
        private void InitializeMainButton3()
        {
            var MainButton = new CxControlLibrary.CxRoundButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;


            //ImageButton icon save and change
            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri(@"C:\\Users\Yuriy\Desktop\temp2.PNG");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);
            MainButton.Width = 1000;
        }
        private void InitializeSubButton()
        {
            var SubButton = new CxControlLibrary.CxRoundButton();
            SubButton.HorizontalAlignment = HorizontalAlignment.Center;
            SubButton.Enabled = true;
            SubButton.Label = String.Empty;//if string is Empty MainButton convert to SubButton

            //Change Beackgroound
            SubButton.BackgroundRegular = new SolidColorBrush(Colors.White);
            SubButton.BackgroundHover = new SolidColorBrush(Color.FromRgb(198, 233, 253));
            SubButton.BackgroundPressed = new SolidColorBrush(Color.FromRgb(114, 179, 216));
            SubButton.BackgroundDisabled = new SolidColorBrush(Color.FromRgb(183, 183, 183));

            XAMLStackPanel.Children.Add(SubButton); //add to Xaml

            SubButton.Name = "SubButton";
            SubButton.Margin = new Thickness(5);
        }
        private void InitializeAddUserButton()
        {
            var AddUserButton = new CxControlLibrary.AddUserButton();
            AddUserButton.HorizontalAlignment = HorizontalAlignment.Center;
            AddUserButton.Enabled = true;

            XAMLStackPanel.Children.Add(AddUserButton); //add to Xaml

            AddUserButton.Name = "AddUserButton";
            AddUserButton.Margin = new Thickness(5);

        }
        private void InitializeTextBox()
        {
            var textBox = new CxControlLibrary.CxTextBox();
            textBox.HorizontalAlignment = HorizontalAlignment.Center;

            XAMLStackPanel.Children.Add(textBox); //add to Xaml

            textBox.Name = "TextBoxes";

            textBox.Label = "Hey Label";

            textBox.ShadowTextLabel = "Hiddent String";

            textBox.Margin = new Thickness(5);

            //TextBox.ShadowTextLabel = true;
            //TextBox.Width = 1000;
            //TextBox.Height = 1000;
            //TextBox.AutoCompleteCollection =
            //    new System.Collections.ObjectModel.ObservableCollection<AutoCompleteEntry>()
            //    { new AutoCompleteEntry("item1", "key") ,new AutoCompleteEntry("item2", "key") ,new AutoCompleteEntry("item3", "key") };
            var tmp = textBox.AutoCompleteCollection;
            textBox.IsAutoComplete = true;
            for (int i = 0; i < 5; i++)
                textBox.AddItem(new AutoCompleteEntry("item " + i, "items"));

            
        }
        private void InitializeRectComboBoxes()
        {
            var RectComboBoxes = new CxControlLibrary.CxComboBox();
            RectComboBoxes.CxWidth = 100;
            //RectComboBoxes.IsAutoComplete = true;
            RectComboBoxes.HorizontalAlignment = HorizontalAlignment.Center;
            RectComboBoxes.ReadOnly = false;

            RectComboBoxes.CxStype = CxStype.Rectangle;

           // RectComboBoxes.ReadOnly = true;

            //RectComboBoxes.IsAutoComplete = false;

            //RectComboBoxes.AutoComplete = null;
           // RectComboBoxes.AutoComplete = true;
           // RectComboBoxes.IsRound = false;
            //RectComboBoxes.Background = new SolidColorBrush(Colors.Red);

            //AddItemComboBox
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "My Item",
                Tag = "Hey Tag",
                Font = new FontFamily("Roboto"),
                Color = new SolidColorBrush(Colors.Blue),
                Enabled = true,
                DropShadow = true,
               // Color = new SolidColorBrush(Colors.Azure),
                BackColor = new SolidColorBrush(Colors.Black),
                Width = 100

            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item2",
                Enabled = false,
                Font = new FontFamily("Roboto"),
                FontSize = 10,
                Color = new SolidColorBrush(Colors.Blue),
                Width = 100

            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item3",
                Enabled = true,
                Font = new FontFamily("Roboto"),
                Color = new SolidColorBrush(Colors.BlueViolet),
                Width = 100
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item4",
                Enabled = true,
                Font = new FontFamily("Roboto"),
                Color = new SolidColorBrush(Colors.DeepSkyBlue),
                Width = 100
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item5",
                Enabled = true,
                Font = new FontFamily("Roboto"),
                Color = new SolidColorBrush(Colors.DarkViolet),
                Width = 100
            });

            RectComboBoxes.DropShadow = true;

            XAMLStackPanel.Children.Add(RectComboBoxes); //add to Xaml

            RectComboBoxes.Name = "RectComboBoxes";
            RectComboBoxes.Margin = new Thickness(5);
            RectComboBoxes.DropShadow = false;

          /// RectComboBoxes.ArrowColor = ColorArr.Gray;
           RectComboBoxes.Background = new SolidColorBrush(Colors.White);


        }
        private void InitializeRoundComboBoxes()
        {
            var RoundComboBoxes = new CxControlLibrary.CxComboBox();
            RoundComboBoxes.HorizontalAlignment = HorizontalAlignment.Center;
            RoundComboBoxes.ReadOnly = true;
            //RoundComboBoxes.AutoComplete = false;
            //   RoundComboBoxes.IsRound = true;
            RoundComboBoxes.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));
            RoundComboBoxes.ArrowColor = ColorArr.Gray;
           // RoundComboBoxes.Foreground = RoundComboBoxes.ArrowColor;


            //AddItemComboBox
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item1",
                Enabled = true,
                Color = new SolidColorBrush(Colors.Azure),
                Width = 1000
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item2",
                Enabled = false,
                Color = new SolidColorBrush(Colors.Blue),
                Width = 1000
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item3",
                Enabled = true,
                Color = new SolidColorBrush(Colors.BlueViolet),
                Width = 1000
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item4",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DeepSkyBlue),
                Width = 1000
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item5",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DarkViolet),
                Width = 1000
            });
            RoundComboBoxes.CxStype = CxStype.Round;
            XAMLStackPanel.Children.Add(RoundComboBoxes); //add to Xaml
            RoundComboBoxes.Name = "RoundComboBoxes";
            RoundComboBoxes.Margin = new Thickness(5);
            RoundComboBoxes.CxWidth = 1000;
            RoundComboBoxes.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
            RoundComboBoxes.ArrowColor = ColorArr.Blue;
        }
        private void InitializeObjectList()
        {
            var ObjectList = new CxControlLibrary.CxObjectList();

            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name1",
                Policy = "Policy1",
                ColorRect = new SolidColorBrush(Colors.Red)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = false,
                AttachmentName = "Attachment Name2",
                Policy = "Policy2",
                ColorRect = new SolidColorBrush(Colors.Green)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name3",
                Policy = "Policy3",
                ColorRect = new SolidColorBrush(Colors.Blue)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name4",
                Policy = "Policy1",
                ColorRect = new SolidColorBrush(Colors.Yellow)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = false,
                AttachmentName = "Attachment Name5",
                Policy = "Policy2",
                ColorRect = new SolidColorBrush(Colors.Tomato)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name6",
                Policy = "Policy3",
                ColorRect = new SolidColorBrush(Colors.Tan)
            });


            XAMLStackPanel.Children.Add(ObjectList);
            ObjectList.Name = "ObjectList";

            ObjectList.Title = "ATTACHMENT NAME(Choose attachment to edit)";
            ObjectList.CxTitlePolicy = "Title Policy";

            ObjectList.CheckForAllItems = true;
            var tmp = ObjectList.ObjectlistItemsCollection;
            ObjectList.Tag = "My Tag";
            // ObjectList.CxOnSelectionChange += ObjectList_CxOnSelectionChange;
            ObjectList.ShowTitles = false;

        }       
        private void InitializeCustomListBox()
        {
            var CList = new ClassificationList();
            CList.HorizontalAlignment = HorizontalAlignment.Center;
            CList.VerticalAlignment = VerticalAlignment.Center;

            CList.AddCollection(new ClassificationButton(CList)
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top secret1",
                Name = "testBtn1",
                SortIndex = 6
            });
            CList.AddCollection(new ClassificationButton(CList)
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2",
                SortIndex = 5
            });
            CList.AddCollection(new ClassificationButton(CList)
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3",
                SortIndex = 4
            });
            CList.AddCollection(new ClassificationButton(CList)
            //4
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                Text = "Guarded",
                Name = "testBtn4",
                SortIndex = 3
            });
            CList.AddCollection(new ClassificationButton(CList)
            //5
            {
                Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
                Text = "Classified B",
                Name = "testBtn5",
                SortIndex = 2
            });
            CList.AddCollection(new ClassificationButton(CList)
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "Top secretFirst",
                Name = "None",
                SortIndex = 1
            });
            CList.AddCollection(new ClassificationButton(CList)
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "None",
                Name = "None",
                SortIndex = 0
            });


            XAMLStackPanel.Children.Add(CList); // add to Xaml

            CList.Name = "CList";
            CList.Margin = new Thickness(5);
            CList.IsUseMore = true;

        }

        #endregion
    }
}