using System;
//using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Rebellic;
using WebService;

namespace Rebellic
{
    class BookingHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Frame frame = (Frame)Window.Current.Content;
        public const string ServerUrl = "http://localhost:51992/";

        private bool _progressRingActive;

        public bool ProgressRingActive
        {
            get { return _progressRingActive; }
            set
            {
                _progressRingActive = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TextBlock> ProductCategories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Grid> GridCollection { get; set; }
        public int SelectedProductCategory { get; set; }
        private string _category_Desc;
        public string Category_Desc
        {
            get { return _category_Desc; }
            set
            {
                _category_Desc = value;
                OnPropertyChanged();
            }
        }
        private Dictionary<int, string> Productlist = new Dictionary<int, string>();
        private string _totalPrice;
        public string TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<StackPanel> EmployeeCollection { get; set; }
        public ObservableCollection<StackPanel> AvailableTimeCollection { get; set; }
        public ObservableCollection<DatePicker> DatePickers { get; set; }
        public ObservableCollection<DatePicker> BirthDayDatePickerOC { get; set; }
        #region ColorsForGui
        private SolidColorBrush _videreTilMedarbejder;

        public SolidColorBrush VidereTilMedarbejder
        {
            get
            {
                return _videreTilMedarbejder;
            }
            set
            {
                _videreTilMedarbejder = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush _videreTilKontakt;

        public SolidColorBrush VidereTilKontakt
        {
            get
            {
                return _videreTilKontakt;
            }
            set
            {
                _videreTilKontakt = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush _videreTilKontaktInfo;

        public SolidColorBrush VidereTilKontaktInfo
        {
            get
            {
                return _videreTilKontaktInfo;
            }
            set
            {
                _videreTilKontaktInfo = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush _videreTilBekræft;

        public SolidColorBrush VidereTilBekræft
        {
            get
            {
                return _videreTilBekræft;
            }
            set
            {
                _videreTilBekræft = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ContactInfo Properties
        private string _customer_Name;
        public string Customer_Name
        {
            get { return _customer_Name; }
            set
            {
                _customer_Name = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Adress;
        public string Customer_Adress
        {
            get { return _customer_Adress; }
            set
            {
                _customer_Adress = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Zipcode;
        public string Customer_Zipcode
        {
            get { return _customer_Zipcode; }
            set
            {
                _customer_Zipcode = value;
                OnPropertyChanged();
            }
        }

        private string _customer_City;
        public string Customer_City
        {
            get { return _customer_City; }
            set
            {
                _customer_City = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Email;
        public string Customer_Email
        {
            get { return _customer_Email; }
            set
            {
                _customer_Email = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Phone;
        public string Customer_Phone
        {
            get { return _customer_Phone; }
            set
            {
                _customer_Phone = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Gender;
        public string Customer_Gender
        {
            get { return _customer_Gender; }
            set
            {
                _customer_Gender = value;
                OnPropertyChanged();
            }
        }

        private DateTime _customer_BirthDay;
        public DateTime Customer_Birthday
        {
            get { return _customer_BirthDay; }
            set
            {
                _customer_BirthDay = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Password;
        public string Customer_Password
        {
            get { return _customer_Password; }
            set
            {
                _customer_Password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region BookingViewsVisibility

        private Visibility _productViewVisibilty;

        public Visibility ProductViewVisibility
        {
            get { return _productViewVisibilty; }
            set
            {
                _productViewVisibilty = value;
                OnPropertyChanged();
            }
        }
        private Visibility _employeeViewVisibilty;

        public Visibility EmployeeViewVisibilty
        {
            get { return _employeeViewVisibilty; }
            set
            {
                _employeeViewVisibilty = value;
                OnPropertyChanged();
            }
        }
        private Visibility _dateAndTimeViewVisibilty;

        public Visibility DateAndTimeViewVisibilty
        {
            get { return _dateAndTimeViewVisibilty; }
            set
            {
                _dateAndTimeViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        public Visibility _contactViewVisibilty { get; set; }

        public Visibility ContactViewVisibilty
        {
            get { return _contactViewVisibilty; }
            set
            {
                _contactViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        public Visibility _tlfViewVisibilty { get; set; }

        public Visibility TlfViewVisibilty
        {
            get { return _tlfViewVisibilty; }
            set
            {
                _tlfViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        public Visibility _ContactInfoVisibilty { get; set; }

        public Visibility ContactInfoViewVisibilty
        {
            get { return _ContactInfoVisibilty; }
            set
            {
                _ContactInfoVisibilty = value;
                OnPropertyChanged();
            }
        }

        public Visibility _confirmViewVisibilty { get; set; }

        public Visibility ConfirmViewVisibilty
        {
            get { return _confirmViewVisibilty; }
            set
            {
                _confirmViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        private Visibility _bookingProcessViewVisibilty;

        public Visibility BookingProcessViewVisibilty
        {
            get { return _bookingProcessViewVisibilty; }
            set
            {
                _bookingProcessViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        private Visibility _kviteringViewVisibilty;

        public Visibility KviteringViewVisibility
        {
            get { return _kviteringViewVisibilty; }
            set
            {
                _kviteringViewVisibilty = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region LoginHandler Props
        public LoginHandler Lh { get; set; }

        private Visibility _menuProfileVisibility;
        public Visibility MenuProfileVisibilty
        {
            get { return _menuProfileVisibility; }
            set
            {
                _menuProfileVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _menuLoginVisibility;
        public Visibility MenuLoginVisibilty
        {
            get { return _menuLoginVisibility; }
            set
            {
                _menuLoginVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _menuLogoutVisibility;
        public Visibility MenuLogoutVisibility
        {
            get { return _menuLogoutVisibility; }
            set
            {
                _menuLogoutVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region BookingProcessProps / visibility
        private Visibility _arrow1Visibility;

        public Visibility Arrow1Visibility
        {
            get { return _arrow1Visibility; }
            set
            {
                _arrow1Visibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _arrow2Visibility;

        public Visibility Arrow2Visibility
        {
            get { return _arrow2Visibility; }
            set
            {
                _arrow2Visibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _arrow3Visibility;

        public Visibility Arrow3Visibility
        {
            get { return _arrow3Visibility; }
            set
            {
                _arrow3Visibility = value;
                OnPropertyChanged();
            }
        }

        private string _chosenProducts;

        public string ChosenProducts
        {
            get
            {
                return _chosenProducts;
            }
            set
            {
                _chosenProducts = value;
                OnPropertyChanged();
            }
        }

        private string _chosenEmployee;

        public string ChosenEmployee
        {
            get
            {
                return _chosenEmployee;
            }
            set
            {
                _chosenEmployee = value;
                OnPropertyChanged();
            }
        }

        private string _chosenTime;

        public string ChosenTime
        {
            get
            {
                return _chosenTime;
            }
            set
            {
                _chosenTime = value;
                OnPropertyChanged();
            }
        }

        private string _getUser;

        public string GetUser
        {
            get
            {
                return _getUser;
            }
            set
            {
                _getUser = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region BookingInfo Properties
        private int _booking_Id;
        public int Booking_id
        {
            get { return _booking_Id; }
            set
            {
                _booking_Id = value;
                OnPropertyChanged();
            }
        }

        private DateTime _booking_Date;
        public DateTime Booking_Date
        {
            get { return _booking_Date; }
            set
            {
                _booking_Date = value;
                OnPropertyChanged();
            }
        }

        private string _booking_Time;
        public string Booking_Time
        {
            get { return _booking_Time; }
            set
            {
                _booking_Time = value;
                OnPropertyChanged();
            }
        }

        private string _booking_TotalPrice;
        public string Booking_TotalPrice
        {
            get { return _booking_TotalPrice; }
            set
            {
                _booking_TotalPrice = value;
                OnPropertyChanged();
            }
        }

        private string _booking_Product;
        public string Booking_Product
        {
            get { return _booking_Product; }
            set
            {
                _booking_Product = value;
                OnPropertyChanged();
            }
        }

        private string _booking_Employee;
        public string Booking_Employee
        {
            get { return _booking_Employee; }
            set
            {
                _booking_Employee = value;
                OnPropertyChanged();
            }
        }

        private string _booking_Customer;
        public string Booking_Customer
        {
            get { return _booking_Customer; }
            set
            {
                _booking_Customer = value;
                OnPropertyChanged();
            }
        }

        private string _booking_Email;
        public string Booking_Email
        {
            get { return _booking_Email; }
            set
            {
                _booking_Email = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Booking Errormessage/validering
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private Visibility _errorMessageVisibility;

        public Visibility ErrorMessageVisibility
        {
            get { return _errorMessageVisibility; }
            set
            {
                _errorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _noAvailableTimes;

        public Visibility NoAvailableTimes
        {
            get { return _noAvailableTimes; }
            set
            {
                _noAvailableTimes = value;
                OnPropertyChanged();
            }
        }

        private string _tidErrorMessage;

        public string TidErrorMessage
        {
            get { return _tidErrorMessage; }
            set
            {
                _tidErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public string ValidationCode { get; set; }
        #endregion

        #region AdminBackend Properties
        public ObservableCollection<StackPanel> AllBookings { get; set; }
        public ObservableCollection<StackPanel> AllCustomers { get; set; }
        public ObservableCollection<StackPanel> AllEmployees { get; set; }
        public ObservableCollection<StackPanel> AllProducts { get; set; }
        public ObservableCollection<StackPanel> AllProductCategories { get; set; }

        #endregion

        public BookingHandler()
        {
            Lh = new LoginHandler();
            MenuLoginVisibilty = Lh.MenuLoginVisibilty;
            MenuLogoutVisibility = Lh.MenuLogoutVisibility;
            MenuProfileVisibilty = Lh.MenuProfileVisibilty;
            ProductCategories = new ObservableCollection<TextBlock>();
            Products = new ObservableCollection<Product>();
            GridCollection = new ObservableCollection<Grid>();
            EmployeeCollection = new ObservableCollection<StackPanel>();
            AvailableTimeCollection = new ObservableCollection<StackPanel>();
            DatePickers = new ObservableCollection<DatePicker>();
            BirthDayDatePickerOC = new ObservableCollection<DatePicker>();
            GetProductCategories();
            GetEmployees();
            VidereTilMedarbejder = new SolidColorBrush(Colors.LightGray);
            VidereTilKontakt = new SolidColorBrush(Colors.LightGray);
            VidereTilKontaktInfo = new SolidColorBrush(Colors.LightGray);
            VidereTilBekræft = new SolidColorBrush(Colors.LightGray);
            EmployeeViewVisibilty = Visibility.Collapsed;
            DateAndTimeViewVisibilty = Visibility.Collapsed;
            NoAvailableTimes = Visibility.Collapsed;
            ContactViewVisibilty = Visibility.Collapsed;
            ContactInfoViewVisibilty = Visibility.Collapsed;
            ConfirmViewVisibilty = Visibility.Collapsed;
            KviteringViewVisibility = Visibility.Collapsed;
            BookingProcessViewVisibilty = Visibility.Visible;
            Arrow1Visibility = Visibility.Collapsed;
            Arrow2Visibility = Visibility.Collapsed;
            Arrow3Visibility = Visibility.Collapsed;
            ProgressRingActive = false;
            ErrorMessageVisibility = Visibility.Collapsed;
            AllBookings = new ObservableCollection<StackPanel>();
            AllCustomers = new ObservableCollection<StackPanel>();
            AllEmployees = new ObservableCollection<StackPanel>();
            AllProducts = new ObservableCollection<StackPanel>();
            AllProductCategories = new ObservableCollection<StackPanel>();
            ErrorMessageVisibility = Visibility.Collapsed;
            GetAllBookings();
            GetAllCustomers();
            GetAllEmployees();
            GetAllProducts();
            GetAllProdcat();
        }

        public BookingHandler(Visibility menuLoginVisibility, Visibility menuLogoutVisibility, Visibility menuProfileVisibility, LoginHandler lh, ObservableCollection<TextBlock> productsCategories, ObservableCollection<Product> products, ObservableCollection<Grid> gridCollection, ObservableCollection<StackPanel> employeeCollection, ObservableCollection<StackPanel> availableTimeCollection, ObservableCollection<DatePicker> datePickers, ObservableCollection<DatePicker> birthDayDatePickerOc, string categoryDesc, string customerName, string customerAdress, string customerZipcode, string customerCity, string customerEmail, string customerPhone, string customerGender, DateTime customerBirthday, string customerPassword, string tidErrorMessage, string errorMessage, Visibility errorMessageVisibility, string validationCode, ObservableCollection<StackPanel> allBookings, ObservableCollection<StackPanel> allCustomers, ObservableCollection<StackPanel> allEmployees, ObservableCollection<StackPanel> allProducts, ObservableCollection<StackPanel> allProductCategories)
        {

            Lh = lh;
            MenuLoginVisibilty = menuLoginVisibility;
            MenuLogoutVisibility = menuLogoutVisibility;
            MenuProfileVisibilty = menuProfileVisibility;
            EmployeeCollection = employeeCollection;
            ProductCategories = productsCategories;
            Products = products;
            GridCollection = gridCollection;
            AvailableTimeCollection = availableTimeCollection;
            DatePickers = datePickers;
            BirthDayDatePickerOC = birthDayDatePickerOc;
            Category_Desc = categoryDesc;
            Customer_Adress = customerAdress;
            Customer_Zipcode = customerZipcode;
            Customer_City = customerCity;
            Customer_Name = customerName;
            Customer_Email = customerEmail;
            Customer_Phone = customerPhone;
            Customer_Gender = customerGender;
            Customer_Birthday = customerBirthday;
            Customer_Password = customerPassword;
            TidErrorMessage = tidErrorMessage;
            ErrorMessage = errorMessage;
            ErrorMessageVisibility = errorMessageVisibility;
            ValidationCode = validationCode;
            AllBookings = allBookings;
            AllCustomers = allCustomers;
            AllEmployees = allEmployees;
            AllProducts = allProducts;
            AllProductCategories = allProductCategories;
        }

        public void GetProductCategories()
        {
            var pcs = Persistency.ProductCategoryPersistency.LoadProductCategoriesFromJsonAsync().Result;

            foreach (var pc in pcs)
            {
                TextBlock CTb = new TextBlock();
                CTb.Text = pc.Category_Name;
                CTb.AccessKey = pc.Category_Id.ToString();
                CTb.Padding = new Thickness(15, 13, 15, 12);
                CTb.Height = 50;
                CTb.Width = 185;
                CTb.Tapped += GetProductCategory;
                ProductCategories.Add(CTb);
            }
        }

        public void GetProducts()
        {
            GridCollection.Clear();

            var pds = Persistency.ProductPersistency.LoadProductsFromJsonAsync().Result;

            foreach (var pd in pds)
            {
                if (pd.Product_Category == SelectedProductCategory)
                {
                    #region Dynamic XamlControls
                    Grid g = new Grid();
                    //sp.Orientation = Orientation.Horizontal;
                    g.VerticalAlignment = VerticalAlignment.Top;
                    g.Width = 665;
                    GridCollection.Add(g);

                    CheckBox cb = new CheckBox();
                    cb.Content = pd.Product_Name;
                    cb.FontWeight = FontWeights.SemiBold;
                    cb.Width = 665;
                    cb.AccessKey = pd.Product_Id.ToString();
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.Checked += ProductChosen;
                    cb.Unchecked += ProductUnchosen;
                    if (Productlist.ContainsKey(int.Parse(cb.AccessKey)))
                    {
                        Productlist.Remove(int.Parse(cb.AccessKey));
                        cb.IsChecked = true;
                    }

                    TextBlock tb = new TextBlock();
                    tb.Text = pd.Product_Time.Minutes + " minutter";
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.Foreground = new SolidColorBrush(Color.FromArgb(255, 107, 110, 111));
                    tb.FontWeight = FontWeights.SemiBold;
                    tb.TextAlignment = TextAlignment.Right;
                    tb.Margin = new Thickness(0, 0, 0, 0);
                    tb.Width = 400;

                    TextBlock tb2 = new TextBlock();
                    tb2.Text = pd.Product_Price + " kr.";
                    tb2.HorizontalAlignment = HorizontalAlignment.Right;
                    tb2.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                    tb2.FontWeight = FontWeights.SemiBold;
                    tb2.TextAlignment = TextAlignment.Right;
                    tb2.Margin = new Thickness(0, 5, 30, 0);
                    tb2.Width = 50;

                    Grid g2 = new Grid();
                    //sp.Orientation = Orientation.Horizontal;
                    g2.VerticalAlignment = VerticalAlignment.Top;
                    g2.MaxWidth = 665;
                    g2.Margin = new Thickness(0, 0, 0, 15);
                    GridCollection.Add(g2);

                    TextBlock tb3 = new TextBlock();
                    tb3.Text = pd.Product_Desc;
                    tb3.Width = 600;
                    tb3.HorizontalAlignment = HorizontalAlignment.Left;
                    tb3.TextWrapping = TextWrapping.Wrap;
                    tb3.Margin = new Thickness(0, 0, 0, 0);

                    g.Children.Add(cb);
                    g.Children.Add(tb);
                    g.Children.Add(tb2);
                    g2.Children.Add(tb3);
                    #endregion
                }
            }
        }

        private void GetProductCategory(object sender, TappedRoutedEventArgs e)
        {
            SelectedProductCategory = int.Parse(((TextBlock)e.OriginalSource).AccessKey);
            var GetDescOfCate = Persistency.ProductCategoryPersistency.LoadProductCategoriesFromJsonAsync().Result;
            foreach (var productCategory in GetDescOfCate)
            {
                if (productCategory.Category_Id == SelectedProductCategory)
                {
                    if (!string.IsNullOrEmpty(productCategory.Category_Desc))
                    {
                        Category_Desc = productCategory.Category_Desc;
                    }
                    else
                    {
                        Category_Desc = "Ingen beskrivelse";
                    }
                }
            }
            GetProducts();
        }

        private double totalBookingPrice;
        private void ProductChosen(object sender, RoutedEventArgs e)
        {
            ErrorMessageVisibility = Visibility.Collapsed;
            totalBookingPrice = 0;
            ChosenProducts = "";

            int ProductId = int.Parse(((CheckBox)e.OriginalSource).AccessKey);
            string ProductName = ((CheckBox)e.OriginalSource).Content.ToString();

            Productlist.Add(ProductId, " " + ProductName);

            foreach (var product in Productlist)
            {
                ChosenProducts += product.Value;
            }

            var GetChosenProduct = Persistency.ProductPersistency.LoadProductsFromJsonAsync().Result;
            foreach (var product in GetChosenProduct)
            {
                foreach (var p in Productlist)
                {
                    if (product.Product_Id == p.Key)
                    {
                        totalBookingPrice += product.Product_Price;
                        TotalPrice = "I alt: " + totalBookingPrice + " kr";
                    }
                }
            }

            VidereTilMedarbejder = new SolidColorBrush(Colors.DodgerBlue);
        }

        private void ProductUnchosen(object sender, RoutedEventArgs e)
        {
            ChosenProducts = "";
            int ProductId = int.Parse(((CheckBox)e.OriginalSource).AccessKey);

            if (Productlist.ContainsKey(ProductId))
            {
                Productlist.Remove(ProductId);
            }

            if (Productlist.Count > 0)
            {
                foreach (var product in Productlist)
                {
                    ChosenProducts += product.Value;
                }
            }
            else
            {
                VidereTilMedarbejder = new SolidColorBrush(Colors.LightGray);
            }
            var GetChosenProduct = Persistency.ProductPersistency.LoadProductsFromJsonAsync().Result;
            foreach (var product in GetChosenProduct)
            {
                if (product.Product_Id == ProductId)
                {
                    totalBookingPrice -= product.Product_Price;
                    TotalPrice = "I alt: " + totalBookingPrice + " kr";
                }
            }
        }

        public void GetEmployees()
        {
            var eys = Persistency.EmployeePersistency.LoadEmployeesFromJsonAsync().Result;
            foreach (var ey in eys)
            {
                #region Dynamic Employee Controls
                StackPanel sp1 = new StackPanel();
                sp1.Padding = new Thickness(10, 10, 10, 10);
                sp1.Background = new SolidColorBrush(Colors.White);
                sp1.Orientation = Orientation.Horizontal;
                sp1.Margin = new Thickness(50, 15, 50, 0);
                sp1.Width = 700;
                EmployeeCollection.Add(sp1);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                sp1.Children.Add(sp2);

                TextBlock eName = new TextBlock();
                eName.Text = ey.Employee_Name;
                eName.FontWeight = FontWeights.SemiBold;
                eName.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eName.FontSize = 17;
                eName.Margin = new Thickness(0, -7, 0, 0);

                TextBlock eTitle = new TextBlock();
                eTitle.Text = "Professionel Body Piercer";
                eTitle.FontStyle = FontStyle.Oblique;
                eTitle.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eDesc = new TextBlock();
                eDesc.Text =
                    "Udd. Professionel Body Piercet siden 2010 startet i lærer som body piercer i 2008. - 2010.";
                eDesc.TextWrapping = TextWrapping.Wrap;
                eDesc.Width = 400;
                eDesc.HorizontalAlignment = HorizontalAlignment.Left;

                sp2.Children.Add(eName);
                sp2.Children.Add(eTitle);
                sp2.Children.Add(eDesc);

                Rectangle ChooseE = new Rectangle();
                ChooseE.Tapped += BookingVidere;
                ChooseE.Width = 100;
                ChooseE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                ChooseE.Height = 30;
                ChooseE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock ChooseEText = new TextBlock();
                ChooseEText.Text = "VÆLG";
                ChooseEText.AccessKey = ey.Employee_Id.ToString();
                ChooseEText.Margin = new Thickness(-100, 0, 0, 59);
                ChooseEText.Padding = new Thickness(0, 4, 0, 0);
                ChooseEText.Height = 30;
                ChooseEText.Width = 100;
                ChooseEText.TextAlignment = TextAlignment.Center;
                ChooseEText.Foreground = new SolidColorBrush(Colors.White);
                ChooseEText.Tapped += BookingVidere;

                sp1.Children.Add(ChooseE);
                sp1.Children.Add(ChooseEText);
                #endregion
            }

        }

        List<TextBlock> tblist = new List<TextBlock>();
        private DateTime getdate;
        private void GetAvailableTimes(object sender, DatePickerValueChangedEventArgs e)
        {
            AvailableTimeCollection.Clear();
            #region Dynamic Time Stackpanels
            StackPanel timeSp = new StackPanel();
            timeSp.Margin = new Thickness(0, 0, 0, 0);
            timeSp.Orientation = Orientation.Horizontal;
            timeSp.Height = 32;
            timeSp.VerticalAlignment = VerticalAlignment.Top;
            timeSp.Width = 420;
            AvailableTimeCollection.Add(timeSp);

            StackPanel timeSp2 = new StackPanel();
            timeSp2.Margin = new Thickness(0, 10, 0, 0);
            timeSp2.Orientation = Orientation.Horizontal;
            timeSp2.Height = 32;
            timeSp2.VerticalAlignment = VerticalAlignment.Top;
            timeSp2.Width = 420;
            AvailableTimeCollection.Add(timeSp2);
            timeSp2.Children.Clear();

            StackPanel timeSp3 = new StackPanel();
            timeSp3.Margin = new Thickness(0, 10, 0, 0);
            timeSp3.Orientation = Orientation.Horizontal;
            timeSp3.Height = 32;
            timeSp3.VerticalAlignment = VerticalAlignment.Top;
            timeSp3.Width = 420;
            AvailableTimeCollection.Add(timeSp3);

            #endregion
            int count = 1;

            if (e.NewDate.Date > DateTime.Now)
            {
                #region Ledigetider
                getdate = e.NewDate.Date;
                TimeSpan Time = TimeSpan.Parse("16:00:00");

                var BookedeTider = Persistency.BookingPersistency.LoadBookingsFromJsonAsync().Result;

                Dictionary<DateTime, TimeSpan> BookingerPåDato = new Dictionary<DateTime, TimeSpan>();

                BookingerPåDato.Clear();
                foreach (var b in BookedeTider)
                {
                    if (Convert.ToDateTime(b.Booking_Date.Month + "/" + b.Booking_Date.Day + "/" + b.Booking_Date.Year + " " + Time) ==
                        Convert.ToDateTime(getdate.Month + "/" + getdate.Day + "/" + getdate.Year + " " + Time))
                    {
                        BookingerPåDato.Add(b.Booking_Date, b.Booking_Date.TimeOfDay);
                    }
                }

                List<string> LedigeTiderPåValgteDato = new List<string>();
                LedigeTiderPåValgteDato.Clear();
                for (int i = 0; i < 8; i++)
                {
                    if (!BookingerPåDato.ContainsValue(Time))
                    {
                        if (Time.Minutes.ToString() == "0")
                        {
                            LedigeTiderPåValgteDato.Add(Time.Hours + ":" + Time.Minutes + "0");
                        }
                        else
                        {
                            LedigeTiderPåValgteDato.Add(Time.Hours + ":" + Time.Minutes);
                        }
                        Time += TimeSpan.FromMinutes(30);
                    }
                    else
                    {
                        Time += TimeSpan.FromMinutes(30);
                    }
                }
                #endregion

                //foreach (var tid in LedigeTiderMedDato)
                //{
                //    if (tid.Date.Date == getdate)
                //    {
                //        LedigeTiderPåValgteDato.Add(tid.TimeOfDay.ToString());
                //    }
                //}
                if (LedigeTiderPåValgteDato.Count > 0)
                {
                    foreach (var tid in LedigeTiderPåValgteDato)
                    {
                        #region Dynamically adding times to gui
                        Grid TidGrid = new Grid();
                        TidGrid.Name = "TidGrid" + count;
                        TidGrid.AccessKey = count.ToString();
                        TidGrid.Width = 100;
                        TidGrid.Height = 32;
                        TidGrid.HorizontalAlignment = HorizontalAlignment.Left;
                        TidGrid.VerticalAlignment = VerticalAlignment.Top;
                        TidGrid.Background = new SolidColorBrush(Colors.White);
                        TidGrid.Margin = new Thickness(5, 0, 0, 0);
                        if (count <= 4)
                        {
                            timeSp.Children.Add(TidGrid);
                        }
                        if (count >= 5 && count <= 8)
                        {
                            timeSp2.Children.Add(TidGrid);
                        }
                        if (count >= 9 && count <= 12)
                        {
                            timeSp3.Children.Add(TidGrid);
                        }

                        TextBlock TidTekst = new TextBlock();
                        TidTekst.Name = "tb-" + tid;
                        TidTekst.AccessKey = count.ToString();
                        TidTekst.Text = tid;
                        TidTekst.Width = 100;
                        TidTekst.Height = 32;
                        TidTekst.Padding = new Thickness(0, 6, 0, 0);
                        TidTekst.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
                        TidTekst.TextAlignment = TextAlignment.Center;
                        TidTekst.Tapped += VælgTidTapped;
                        TidGrid.Children.Add(TidTekst);
                        tblist.Add(TidTekst);

                        Border TidBorder = new Border();
                        TidBorder.Width = 100;
                        TidBorder.Height = 32;
                        TidBorder.BorderThickness = new Thickness(1);
                        TidBorder.BorderBrush = new SolidColorBrush(Colors.LightGray);
                        TidGrid.Children.Add(TidBorder);
                        count++;
                        #endregion
                    }

                    NoAvailableTimes = Visibility.Collapsed;
                }
                else
                {
                    timeSp.Children.Clear();
                    timeSp2.Children.Clear();
                    timeSp3.Children.Clear();
                    NoAvailableTimes = Visibility.Visible;
                    TidErrorMessage = "Der er desværre ingen ledige tider på valgte dato";
                }
            }
            else
            {
                timeSp.Children.Clear();
                timeSp2.Children.Clear();
                timeSp3.Children.Clear();
                NoAvailableTimes = Visibility.Visible;
                TidErrorMessage = "Den valgte dato skal tidligst være: " + DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            }
        }

        private string getTid;
        private void VælgTidTapped(object sender, TappedRoutedEventArgs e)
        {
            getTid = ((TextBlock)e.OriginalSource).Text;
            ErrorMessageVisibility = Visibility.Collapsed;
            foreach (var textblock in tblist)
            {
                textblock.FontWeight = FontWeights.Normal;
            }

            ((TextBlock)e.OriginalSource).FontWeight = FontWeights.SemiBold;
            VidereTilKontakt = new SolidColorBrush(Colors.DodgerBlue);

            ChosenTime = getdate.ToString("dd/MM yyyy") + " kl: " + ((TextBlock)e.OriginalSource).Text;
            Arrow3Visibility = Visibility.Visible;
        }

        public void CreateUser()
        {
            if (!doesUserExist)
            {
                //Valider bruger (errormessage)
                Customer newCustomer = new Customer();
                newCustomer.Customer_Name = Customer_Name;
                newCustomer.Customer_Adress = Customer_Adress;
                newCustomer.Customer_Zipcode = Customer_Zipcode;
                newCustomer.Customer_City = Customer_City;
                newCustomer.Customer_Email = Customer_Email;
                newCustomer.Customer_Phone = Convert.ToInt32(Customer_Phone);
                newCustomer.Customer_Gender = Customer_Gender;
                newCustomer.Customer_Birthday = Birthday;
                newCustomer.Customer_Password = Customer_Password;

                Persistency.CustomerPersistency.SaveCustomersAsJsonAsync(newCustomer);
            }
            else
            {
                var customers = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;
                var customerToUpdate = (from c in customers where c.Customer_Phone == Convert.ToInt32(Customer_Phone) select c).FirstOrDefault();
                if (customerToUpdate.Customer_Password == Customer_Password)
                {
                    customerToUpdate.Customer_Name = Customer_Name;
                    customerToUpdate.Customer_Adress = Customer_Adress;
                    customerToUpdate.Customer_Zipcode = Customer_Zipcode;
                    customerToUpdate.Customer_City = Customer_City;
                    customerToUpdate.Customer_Email = Customer_Email;
                    customerToUpdate.Customer_Phone = Convert.ToInt32(Customer_Phone);
                    customerToUpdate.Customer_Gender = Customer_Gender;
                    customerToUpdate.Customer_Birthday = Birthday;
                    customerToUpdate.Customer_Password = Customer_Password;
                    Persistency.CustomerPersistency.UpdateCustomersFromJsonAsync(customerToUpdate);
                }
            }
        }

        private bool IsPhoneValid = false;
        public void ValidatePhoneNumber(object sender, TextChangedEventArgs e)
        {
            if (Customer_Phone != "")
            {
                foreach (char c in Customer_Phone)
                {
                    if (c < '0' || c > '9')
                    {
                        VidereTilKontaktInfo = new SolidColorBrush(Colors.LightGray);
                        IsPhoneValid = false;
                        return;
                    }
                    else
                    {
                        ErrorMessageVisibility = Visibility.Collapsed;
                        VidereTilKontaktInfo = new SolidColorBrush(Colors.DodgerBlue);
                        IsPhoneValid = true;
                    }
                }
            }
            else
            {
                VidereTilKontaktInfo = new SolidColorBrush(Colors.LightGray);
                IsPhoneValid = false;
            }
        }

        private bool IsContactInfoValid = false;
        public void ValidateContactInfo()
        {
            ErrorMessageVisibility = Visibility.Collapsed;
            if (!string.IsNullOrEmpty(Customer_Name) && !string.IsNullOrEmpty(Customer_Adress) && !string.IsNullOrEmpty(Customer_Zipcode) && !string.IsNullOrEmpty(Customer_City) && !string.IsNullOrEmpty(Customer_Email) && !string.IsNullOrEmpty(Customer_Gender) && Birthday != Convert.ToDateTime("01/01/1700 00:00:00"))
            {
                VidereTilBekræft = new SolidColorBrush(Colors.DodgerBlue);
                IsContactInfoValid = true;
            }
            else
            {
                VidereTilBekræft = new SolidColorBrush(Colors.LightGray);
                IsContactInfoValid = false;
            }
        }

        private DateTime Birthday = Convert.ToDateTime("01/01/1700 00:00:00");
        public void SetBirthday(object sender, DatePickerValueChangedEventArgs e)
        {
            Birthday = e.NewDate.Date;
            ValidateContactInfo();
        }

        private int count = 1;
        private bool doesUserExist = false;
        public async void BookingVidere(object sender, RoutedEventArgs e)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            ProductViewVisibility = Visibility.Collapsed;
            EmployeeViewVisibilty = Visibility.Collapsed;
            DateAndTimeViewVisibilty = Visibility.Collapsed;
            TlfViewVisibilty = Visibility.Collapsed;
            ContactInfoViewVisibilty = Visibility.Collapsed;
            ContactViewVisibilty = Visibility.Collapsed;
            ConfirmViewVisibilty = Visibility.Collapsed;

            switch (count)
            {
                case 1:
                    if (Productlist.Count > 0)
                    {
                        Arrow1Visibility = Visibility.Visible;
                        EmployeeViewVisibilty = Visibility.Visible;
                        ErrorMessageVisibility = Visibility.Collapsed;
                        count++;
                    }
                    else
                    {
                        ErrorMessageVisibility = Visibility.Visible;
                        ErrorMessage = "Vælg venligst mindst ét produkt";
                        ProductViewVisibility = Visibility.Visible;
                        await Task.Delay(3500);
                        ErrorMessageVisibility = Visibility.Collapsed;
                    }
                    break;
                case 2:
                    #region GetSelectedEmployee
                    using (var client = new HttpClient(handler))
                    {
                        client.BaseAddress = new Uri(ServerUrl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        try
                        {
                            var responce = client.GetAsync("api/Employees").Result;
                            if (responce.IsSuccessStatusCode)
                            {
                                var eys = responce.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                                foreach (var ey in eys)
                                {
                                    if (ey.Employee_Id == int.Parse(((TextBlock)e.OriginalSource).AccessKey))
                                    {
                                        ChosenEmployee = ey.Employee_Name;
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                    #endregion
                    Arrow2Visibility = Visibility.Visible;
                    DatePicker dp = new DatePicker();
                    dp.DateChanged += GetAvailableTimes;

                    foreach (var datePicker in DatePickers)
                    {
                        dp.Date = datePicker.Date;
                    }
                    DatePickers.Clear();
                    DatePickers.Add(dp);
                    DateAndTimeViewVisibilty = Visibility.Visible;
                    count++;
                    break;
                case 3:
                    if (ChosenTime != null)
                    {
                        ErrorMessageVisibility = Visibility.Collapsed;
                        ContactViewVisibilty = Visibility.Visible;
                        TlfViewVisibilty = Visibility.Visible;
                        count++;
                    }
                    else
                    {
                        ErrorMessageVisibility = Visibility.Visible;
                        ErrorMessage = "Vælg venligst en tid";
                        DateAndTimeViewVisibilty = Visibility.Visible;
                        await Task.Delay(3500);
                        ErrorMessageVisibility = Visibility.Collapsed;
                    }
                    break;
                case 4:
                    ContactViewVisibilty = Visibility.Visible;
                    if (IsPhoneValid)
                    {
                        ValidateContactInfo();
                        doesUserExist = false;
                        ErrorMessageVisibility = Visibility.Collapsed;
                        ContactInfoViewVisibilty = Visibility.Visible;

                        #region Add datepicker for birthday to gui
                        BirthDayDatePickerOC.Clear();
                        DatePicker BirthDayDatePicker = new DatePicker();
                        BirthDayDatePicker.Width = 380;
                        BirthDayDatePicker.VerticalAlignment = VerticalAlignment.Center;
                        BirthDayDatePicker.Background = new SolidColorBrush(Colors.White);
                        BirthDayDatePicker.DateChanged += SetBirthday;
                        BirthDayDatePickerOC.Add(BirthDayDatePicker);
                        #endregion
                        count++;
                        #region GetExistingUser  
                        var customers = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;
                        foreach (var c in customers)
                        {
                            if (c.Customer_Phone == Convert.ToInt32(Customer_Phone))
                            {
                                Customer_Name = c.Customer_Name;
                                Customer_Adress = c.Customer_Adress;
                                Customer_Zipcode = c.Customer_Zipcode;
                                Customer_City = c.Customer_City;
                                Customer_Email = c.Customer_Email;
                                Customer_Gender = c.Customer_Gender;
                                Customer_Birthday = c.Customer_Birthday;

                                doesUserExist = true;
                                return;
                            }
                            else
                            {
                                Customer_Name = null;
                                Customer_Adress = null;
                                Customer_Zipcode = null;
                                Customer_City = null;
                                Customer_Email = null;
                                Customer_Gender = null;

                                doesUserExist = false;
                            }
                        }
                        #endregion

                    }
                    else
                    {
                        ErrorMessageVisibility = Visibility.Visible;
                        ErrorMessage = "Indtast venligts et mobilnummer";
                        TlfViewVisibilty = Visibility.Visible;
                        await Task.Delay(3500);
                        ErrorMessageVisibility = Visibility.Collapsed;
                    }
                    break;
                case 5:
                    ContactViewVisibilty = Visibility.Visible;
                    ContactInfoViewVisibilty = Visibility.Visible;
                    var getUsers = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;
                    var getUser =
                        (from user in getUsers where user.Customer_Phone == Convert.ToInt32(Customer_Phone) select user).FirstOrDefault();
                    if (doesUserExist)
                    {
                        if (getUser.Customer_Password == Customer_Password)
                        {
                            if (IsContactInfoValid)
                            {
                                CreateUser();
                                GetUser = Customer_Name;
                                ConfirmViewVisibilty = Visibility.Visible;
                                ContactViewVisibilty = Visibility.Collapsed;
                                ContactInfoViewVisibilty = Visibility.Collapsed;
                                ErrorMessageVisibility = Visibility.Collapsed;
                                count++;
                            }
                            else
                            {
                                ContactViewVisibilty = Visibility.Visible;
                                ContactInfoViewVisibilty = Visibility.Visible;
                                ErrorMessageVisibility = Visibility.Visible;
                                ErrorMessage = "Udfyldt venligst alle felter markeret med *";
                                await Task.Delay(3500);
                                ErrorMessageVisibility = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            ErrorMessageVisibility = Visibility.Visible;
                            ErrorMessage = "Indtast venligst det rigtige kodeord";
                            await Task.Delay(3500);
                            ErrorMessageVisibility = Visibility.Collapsed;
                        }
                    }
                    else if (!doesUserExist)
                    {
                        if (IsContactInfoValid)
                        {
                            CreateUser();
                            GetUser = Customer_Name;
                            ConfirmViewVisibilty = Visibility.Visible;
                            ContactViewVisibilty = Visibility.Collapsed;
                            ContactInfoViewVisibilty = Visibility.Collapsed;
                            ErrorMessageVisibility = Visibility.Collapsed;
                            count++;
                        }
                        else
                        {
                            ContactViewVisibilty = Visibility.Visible;
                            ContactInfoViewVisibilty = Visibility.Visible;
                            ErrorMessageVisibility = Visibility.Visible;
                            ErrorMessage = "Udfyldt venligst alle felter markeret med *";
                            await Task.Delay(3500);
                            ErrorMessageVisibility = Visibility.Collapsed;
                        }
                    }
                    break;
            }
        }

        public void BookingTilbage()
        {
            ProductViewVisibility = Visibility.Collapsed;
            EmployeeViewVisibilty = Visibility.Collapsed;
            DateAndTimeViewVisibilty = Visibility.Collapsed;
            ContactViewVisibilty = Visibility.Collapsed;
            ConfirmViewVisibilty = Visibility.Collapsed;
            switch (count)
            {
                case 2:
                    ProductViewVisibility = Visibility.Visible;
                    count--;
                    break;
                case 3:
                    EmployeeViewVisibilty = Visibility.Visible;
                    count--;
                    break;
                case 4:
                    DateAndTimeViewVisibilty = Visibility.Visible;
                    count--;
                    break;
                case 5:
                    DateAndTimeViewVisibilty = Visibility.Visible;
                    count--;
                    break;
                case 6:
                    ContactViewVisibilty = Visibility.Visible;
                    ContactInfoViewVisibilty = Visibility.Visible;
                    count--;
                    break;
            }
        }

        public void ChangePhoneNumber()
        {
            ContactInfoViewVisibilty = Visibility.Collapsed;
            TlfViewVisibilty = Visibility.Visible;
            count--;
        }

        public void CreateBooking()
        {
            Booking NewBooking = new Booking();
            NewBooking.Booking_Date = Convert.ToDateTime(getdate.Month + "/" + getdate.Day + "/" + getdate.Year + " " + getTid + ":00");
            NewBooking.Booking_Time = TimeSpan.Parse("00:30:00");
            NewBooking.Booking_TotalPrice = totalBookingPrice;
            foreach (var product in Productlist)
            {
                NewBooking.fk_Product_Id = product.Key;
                Booking_Product = product.Value;
            }
            #region Get Employee and Customer
            var GetEmployees = Persistency.EmployeePersistency.LoadEmployeesFromJsonAsync().Result;
            var employee =
                (from e in GetEmployees where e.Employee_Name == ChosenEmployee select e).FirstOrDefault();

            NewBooking.fk_Employee_Id = employee.Employee_Id;
            Booking_Employee = employee.Employee_Name;

            var GetCustomers = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;
            var customer = (from c in GetCustomers where c.Customer_Email == Customer_Email select c).FirstOrDefault();

            NewBooking.fk_Customer_Id = customer.Customer_Id;
            Booking_Customer = customer.Customer_Name;
            Booking_Email = Customer_Email;
            #endregion
            NewBooking.fk_Room_Id = 1;
            Persistency.BookingPersistency.SaveBookingsAsJsonAsync(NewBooking);
        }

        public async void BekræftBooking()
        {
            if (!string.IsNullOrEmpty(ValidationCode) && ValidationCode == "1234")
            {
                CreateBooking();

                var GetBookings = Persistency.BookingPersistency.LoadBookingsFromJsonAsync().Result;
                foreach (var booking in GetBookings)
                {
                    Booking_id = booking.Booking_Id + 1;
                    Booking_Date = Convert.ToDateTime(getdate.Month + "/" + getdate.Day + "/" + getdate.Year + " " + getTid + ":00");
                    Booking_TotalPrice = booking.Booking_TotalPrice + " kr";
                }

                ErrorMessageVisibility = Visibility.Collapsed;

                ConfirmViewVisibilty = Visibility.Collapsed;
                BookingProcessViewVisibilty = Visibility.Collapsed;
                KviteringViewVisibility = Visibility.Visible;
                new MessageDialog("Din booking er blevet oprettet").ShowAsync();
            }
            else
            {
                ErrorMessageVisibility = Visibility.Visible;
                ErrorMessage = "Bekræftelseskoden er forkert";
                await Task.Delay(3500);
                ErrorMessageVisibility = Visibility.Collapsed;
            }
        }

        public void GetAllBookings()
        {

            var GetBookingsCust = Persistency.BookingPersistency.LoadBookingsFromJsonAsync().Result;
            var bookingscust = from b in GetBookingsCust select b;
            //#region Get Employee and Customer
            //var GetEmployees = Persistency.EmployeePersistency.LoadEmployeesFromJsonAsync().Result;
            //var employee =
            //    (from e in GetEmployees select e).FirstOrDefault();

            //bookingscust.First.fk_Employee_Id = employee.Employee_Id;
            //Booking_Employee = employee.Employee_Name;

            //var GetCustomers = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;
            //var customer = (from c in GetCustomers select c).FirstOrDefault();

            //bookingscust.FirstOrDefault().fk_Customer_Id = customer.Customer_Id;
            //Booking_Customer = customer.Customer_Name;
            //Booking_Email = Customer_Email;
            //#endregion
            foreach (var booking in bookingscust)
            { 
                #region Dynamic Customer Booking xaml
                StackPanel spbooking = new StackPanel();
                spbooking.Padding = new Thickness(10, 10, 10, 10);
                spbooking.Background = new SolidColorBrush(Colors.White);
                spbooking.Orientation = Orientation.Horizontal;
                spbooking.Margin = new Thickness(50, 15, 50, 0);
                spbooking.Width = 700;
                AllBookings.Add(spbooking);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                spbooking.Children.Add(sp2);

                TextBlock eDate = new TextBlock();
                eDate.Text = "Dato: " + booking.Booking_Date;
                eDate.FontWeight = FontWeights.SemiBold;
                eDate.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eDate.FontSize = 17;
                eDate.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eTime = new TextBlock();
                eTime.Text = "Tid: " + booking.Booking_Time + " minutter";
                eTime.FontStyle = FontStyle.Normal;
                eTime.Margin = new Thickness(0, 0, 0, 10);

                TextBlock ePrice = new TextBlock();
                ePrice.Text = "Total pris: " + booking.Booking_TotalPrice + " kr.";
                ePrice.FontStyle = FontStyle.Normal;
                ePrice.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eCusName = new TextBlock();
                eCusName.Text = "Kunde: " + Booking_Customer;
                eCusName.FontStyle = FontStyle.Normal;
                eCusName.Margin = new Thickness(0, 0, 0, 10);

                sp2.Children.Add(eDate);
                sp2.Children.Add(eTime);
                sp2.Children.Add(ePrice);
                sp2.Children.Add(eCusName);

                Rectangle EditE = new Rectangle();
                EditE.Width = 100;
                EditE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                EditE.Height = 30;
                EditE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock EditText = new TextBlock();
                EditText.Text = "REDIGER";
                EditText.AccessKey = booking.Booking_Id.ToString();
                EditText.Margin = new Thickness(-100, 0, 0, 59);
                EditText.Padding = new Thickness(0, 4, 0, 0);
                EditText.Height = 30;
                EditText.Width = 100;
                EditText.TextAlignment = TextAlignment.Center;
                EditText.Foreground = new SolidColorBrush(Colors.White);

                spbooking.Children.Add(EditE);
                spbooking.Children.Add(EditText);
                #endregion
            }
            
        }

        public void GetAllCustomers()
        {

            var AllCustomersAdmin = Persistency.CustomerPersistency.LoadCustomersFromJsonAsync().Result;

            var customers = from c in AllCustomersAdmin select c;
            foreach (var customer in customers)
            {
                #region Dynamic Customer Booking xaml
                StackPanel spcust = new StackPanel();
                spcust.Padding = new Thickness(10, 10, 10, 10);
                spcust.Background = new SolidColorBrush(Colors.White);
                spcust.Orientation = Orientation.Horizontal;
                spcust.Margin = new Thickness(50, 15, 50, 0);
                spcust.Width = 700;
                AllCustomers.Add(spcust);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                spcust.Children.Add(sp2);

                TextBlock eName = new TextBlock();
                eName.Text = "Navn: " + customer.Customer_Name;
                eName.FontWeight = FontWeights.SemiBold;
                eName.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eName.FontSize = 17;
                eName.Margin = new Thickness(0, -7, 0, 0);

                TextBlock eAdress = new TextBlock();
                eAdress.Text = "Adresse: " + customer.Customer_Adress;
                eAdress.FontStyle = FontStyle.Normal;
                eAdress.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eZip = new TextBlock();
                eZip.Text = "Postnummer: " + customer.Customer_Zipcode;
                eZip.FontStyle = FontStyle.Normal;
                eZip.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eCity = new TextBlock();
                eCity.Text = "By: " + customer.Customer_City;
                eCity.FontStyle = FontStyle.Normal;
                eCity.Margin = new Thickness(0, 0, 0, 10);

                TextBlock ePhone = new TextBlock();
                ePhone.Text = "Tlf. nr.: " + customer.Customer_Phone;
                ePhone.FontStyle = FontStyle.Normal;
                ePhone.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eMail = new TextBlock();
                eMail.Text = "Email: " + customer.Customer_Email;
                eMail.FontStyle = FontStyle.Normal;
                eMail.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eGend = new TextBlock();
                eGend.Text = "Køn: " + customer.Customer_Gender;
                eGend.FontStyle = FontStyle.Normal;
                eGend.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eBirth = new TextBlock();
                eBirth.Text = "Fødselsdag: " + customer.Customer_Birthday;
                eBirth.FontStyle = FontStyle.Normal;
                eBirth.Margin = new Thickness(0, 0, 0, 10);

                sp2.Children.Add(eName);
                sp2.Children.Add(eAdress);
                sp2.Children.Add(eZip);
                sp2.Children.Add(eCity);
                sp2.Children.Add(ePhone);
                sp2.Children.Add(eMail);
                sp2.Children.Add(eGend);
                sp2.Children.Add(eBirth);

                Rectangle EditE = new Rectangle();
                EditE.Width = 100;
                EditE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                EditE.Height = 30;
                EditE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock EditText = new TextBlock();
                EditText.Text = "REDIGER";
                EditText.AccessKey = customer.Customer_Id.ToString();
                EditText.Margin = new Thickness(-70, 0, 0, 59);
                EditText.Padding = new Thickness(0, 4, 0, 0);
                EditText.Height = 30;
                EditText.Width = 100;
                EditText.TextAlignment = TextAlignment.Center;
                EditText.Foreground = new SolidColorBrush(Colors.White);

                spcust.Children.Add(EditE);
                spcust.Children.Add(EditText);
                #endregion
            }

        }

        public void GetAllEmployees()
        {

            var AllEmployeesAdmin = Persistency.EmployeePersistency.LoadEmployeesFromJsonAsync().Result;

            var employees = from e in AllEmployeesAdmin select e;
            foreach (var employee in employees)
            {
                #region Dynamic Customer Booking xaml
                StackPanel spemployee = new StackPanel();
                spemployee.Padding = new Thickness(10, 10, 10, 10);
                spemployee.Background = new SolidColorBrush(Colors.White);
                spemployee.Orientation = Orientation.Horizontal;
                spemployee.Margin = new Thickness(50, 15, 50, 0);
                spemployee.Width = 700;
                AllEmployees.Add(spemployee);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                spemployee.Children.Add(sp2);

                TextBlock eName = new TextBlock();
                eName.Text = "Navn: " + employee.Employee_Name;
                eName.FontWeight = FontWeights.SemiBold;
                eName.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eName.FontSize = 17;
                eName.Margin = new Thickness(0, 0, 0, 10);

                TextBlock ePhone = new TextBlock();
                ePhone.Text = "Tlf. nr.: " + employee.Employee_Phone;
                ePhone.FontStyle = FontStyle.Normal;
                ePhone.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eMail = new TextBlock();
                eMail.Text = "Tlf. nr.: " + employee.Employee_Email;
                eMail.FontStyle = FontStyle.Normal;
                eMail.Margin = new Thickness(0, 0, 0, 10);

                sp2.Children.Add(eName);
                sp2.Children.Add(ePhone);
                sp2.Children.Add(eMail);

                Rectangle EditE = new Rectangle();
                EditE.Width = 100;
                EditE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                EditE.Height = 30;
                EditE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock EditText = new TextBlock();
                EditText.Text = "REDIGER";
                EditText.AccessKey = employee.Employee_Id.ToString();
                EditText.Margin = new Thickness(-100, 0, 0, 59);
                EditText.Padding = new Thickness(0, 4, 0, 0);
                EditText.Height = 30;
                EditText.Width = 100;
                EditText.TextAlignment = TextAlignment.Center;
                EditText.Foreground = new SolidColorBrush(Colors.White);

                spemployee.Children.Add(EditE);
                spemployee.Children.Add(EditText);
                #endregion
            }

        }

        public void GetAllProducts()
        {

            var AllProductsAdmin = Persistency.ProductPersistency.LoadProductsFromJsonAsync().Result;

            var products = from p in AllProductsAdmin select p;
            foreach (var product in products)
            {
                #region Dynamic Customer Booking xaml
                StackPanel spprod = new StackPanel();
                spprod.Padding = new Thickness(10, 10, 10, 10);
                spprod.Background = new SolidColorBrush(Colors.White);
                spprod.Orientation = Orientation.Horizontal;
                spprod.Margin = new Thickness(50, 15, 50, 0);
                spprod.Width = 700;
                AllProducts.Add(spprod);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                spprod.Children.Add(sp2);

                TextBlock eName = new TextBlock();
                eName.Text = "Produkt: " + product.Product_Name;
                eName.FontWeight = FontWeights.SemiBold;
                eName.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eName.FontSize = 17;
                eName.Margin = new Thickness(0, -7, 0, 0);

                TextBlock eCat = new TextBlock();
                eCat.Text = "Kategori: " + product.Product_Category;
                eCat.FontStyle = FontStyle.Normal;
                eCat.Margin = new Thickness(0, 0, 0, 10);

                TextBlock ePrice = new TextBlock();
                ePrice.Text = "Pris: " + product.Product_Price + " kr.";
                ePrice.FontStyle = FontStyle.Normal;
                ePrice.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eTime = new TextBlock();
                eTime.Text = "Tid: " + product.Product_Time + " minutter";
                eTime.FontStyle = FontStyle.Normal;
                eTime.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eDesc = new TextBlock();
                eDesc.Text = "Beskrivelse: " + product.Product_Desc;
                eDesc.TextWrapping = TextWrapping.Wrap;
                eDesc.Width = 400;
                eDesc.HorizontalAlignment = HorizontalAlignment.Left;

                sp2.Children.Add(eName);
                sp2.Children.Add(eCat);
                sp2.Children.Add(ePrice);
                sp2.Children.Add(eTime);
                sp2.Children.Add(eDesc);

                Rectangle EditE = new Rectangle();
                EditE.Width = 100;
                EditE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                EditE.Height = 30;
                EditE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock EditText = new TextBlock();
                EditText.Text = "REDIGER";
                EditText.AccessKey = product.Product_Id.ToString();
                EditText.Margin = new Thickness(-70, 0, 0, 59);
                EditText.Padding = new Thickness(0, 4, 0, 0);
                EditText.Height = 30;
                EditText.Width = 100;
                EditText.TextAlignment = TextAlignment.Center;
                EditText.Foreground = new SolidColorBrush(Colors.White);

                spprod.Children.Add(EditE);
                spprod.Children.Add(EditText);
                #endregion
            }

        }

        public void GetAllProdcat()
        {

            var AllProdcatAdmin = Persistency.ProductCategoryPersistency.LoadProductCategoriesFromJsonAsync().Result;

            var prodcats = from pc in AllProdcatAdmin select pc;
            foreach (var prodcat in prodcats)
            {
                #region Dynamic Customer Booking xaml
                StackPanel spprodcat = new StackPanel();
                spprodcat.Padding = new Thickness(10, 10, 10, 10);
                spprodcat.Background = new SolidColorBrush(Colors.White);
                spprodcat.Orientation = Orientation.Horizontal;
                spprodcat.Margin = new Thickness(50, 15, 50, 0);
                spprodcat.Width = 700;
                AllProductCategories.Add(spprodcat);

                StackPanel sp2 = new StackPanel();
                sp2.Width = 580;
                sp2.Padding = new Thickness(10, 0, 0, 0);

                spprodcat.Children.Add(sp2);

                //TextBlock eId = new TextBlock();
                //eId.Text = "Id: " + prodcat.Category_Id;
                //eId.FontWeight = FontWeights.SemiBold;
                //eId.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                //eId.FontSize = 17;
                //eId.Margin = new Thickness(0, -7, 0, 0);

                TextBlock eName = new TextBlock();
                eName.Text = "Kategori: " + prodcat.Category_Name;
                eName.FontWeight = FontWeights.SemiBold;
                eName.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                eName.FontSize = 17;
                eName.Margin = new Thickness(0, 0, 0, 10);

                TextBlock eDesc = new TextBlock();
                eDesc.Text = "Beskrivelse: " + prodcat.Category_Desc;
                eDesc.TextWrapping = TextWrapping.Wrap;
                eDesc.Width = 400;
                eDesc.HorizontalAlignment = HorizontalAlignment.Left;

                //sp2.Children.Add(eId);
                sp2.Children.Add(eName);
                sp2.Children.Add(eDesc);

                Rectangle EditE = new Rectangle();
                EditE.Width = 100;
                EditE.Fill = new SolidColorBrush(Colors.DodgerBlue);
                EditE.Height = 30;
                EditE.VerticalAlignment = VerticalAlignment.Top;

                TextBlock EditText = new TextBlock();
                EditText.Text = "REDIGER";
                EditText.AccessKey = prodcat.Category_Id.ToString();
                EditText.Margin = new Thickness(-100, 0, 0, 59);
                EditText.Padding = new Thickness(0, 4, 0, 0);
                EditText.Height = 30;
                EditText.Width = 100;
                EditText.TextAlignment = TextAlignment.Center;
                EditText.Foreground = new SolidColorBrush(Colors.White);

                spprodcat.Children.Add(EditE);
                spprodcat.Children.Add(EditText);
                #endregion

            }

        }


    }
}

