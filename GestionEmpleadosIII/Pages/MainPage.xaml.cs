using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel mainPageModel)
        {
            BindingContext = mainPageModel;
            InitializeComponent();
        }

       
    }
}
