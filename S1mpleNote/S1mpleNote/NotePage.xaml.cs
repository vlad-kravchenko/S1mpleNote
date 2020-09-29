using S1mpleNote.Domain;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S1mpleNote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotePage : ContentPage
	{
		public NotePage ()
		{
			InitializeComponent();
		}

        private void SaveNote_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (!string.IsNullOrEmpty(note.Text))
            {
                App.Database.SaveItem(note);
            }
            this.Navigation.PopAsync();
        }

        private async void DeleteNote_ClickedAsync(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Удаление заметки", "Вы уверенны, что хотите удалить заметку?", "Да", "Нет");
            if (!result) return;

            var note = (Note)BindingContext;
            App.Database.DeleteItem(note.Id);
            await this.Navigation.PopAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}