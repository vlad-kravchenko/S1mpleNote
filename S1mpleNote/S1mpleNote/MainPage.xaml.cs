using S1mpleNote.Domain;
using System;
using Xamarin.Forms;

namespace S1mpleNote
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            notesList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void AddNote_ClickedAsync(object sender, EventArgs e)
        {
            Note note = new Note();
            NotePage notePage = new NotePage();
            notePage.BindingContext = note;
            await Navigation.PushAsync(notePage);
            NavigationPage.SetHasBackButton(notePage, true);
        }

        private async void NotesList_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            Note selectedNote = (Note)e.SelectedItem;
            NotePage notePage = new NotePage();
            notePage.BindingContext = selectedNote;
            await Navigation.PushAsync(notePage);
            NavigationPage.SetHasBackButton(notePage, true);
        }
    }
}