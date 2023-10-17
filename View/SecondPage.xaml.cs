using MauiApp3.Model;

namespace MauiApp3.View;

public partial class SecondPage : ContentPage
{
	UserModel user;
	public SecondPage()
	{
		InitializeComponent();
	}

	public SecondPage(UserModel user)
	{
		InitializeComponent();
		this.user = user;

		welcomeText.Text = $"Witaj, {user.Name} {user.Surname}";
	}

	public void generateAnObject(PizzaModel pizza) { 
		
	}
}