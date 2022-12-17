using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    async void BtnRegister_Clicked(object sender, EventArgs e)
    {
		var response = await ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);

        while (Navigation.ModalStack.Count > 0)
        {
            await Navigation.PopModalAsync();
        }

        if (response)
		{
			await DisplayAlert("", "Your account has been created", "OK");
			await Navigation.PushModalAsync(new LoginPage());
		}
		else
		{
            await DisplayAlert("", "Oops, something went wrong..", "OK");
        }
    }

    async void TapLogin_Tapped(object sender, TappedEventArgs e)
    {
        while (Navigation.ModalStack.Count > 0)
        {
            await Navigation.PopModalAsync();
        }

        await Navigation.PushModalAsync(new LoginPage());
    }
}