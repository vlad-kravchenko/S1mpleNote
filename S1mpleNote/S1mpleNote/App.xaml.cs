using S1mpleNote.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace S1mpleNote
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "notes.db";
        public static NoteRepository database;

        public static NoteRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new MainPage());
            navigationPage.BarBackgroundColor = Color.LightBlue;
            navigationPage.BarTextColor = Color.Black;
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}