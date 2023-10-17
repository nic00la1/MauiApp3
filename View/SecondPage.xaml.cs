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
		generateAnObject(new PizzaModel
		{
			Zdjecie = "pizza1.jpg",
			Nazwa = "Pizza",
			Skladniki = "Ser, pieczarki",
			Cena = 30.00,
			Rozmiar = 24
		});
	}

	public void generateAnObject(PizzaModel pizza) 
	{ 
		HorizontalStackLayout view = new HorizontalStackLayout();
		VerticalStackLayout dataView = new VerticalStackLayout();
		
		Image image = new Image();
		image.Source = pizza.Zdjecie;
		image.HeightRequest = 120;
		image.Margin = new Thickness(8, 4, 8, 4);

		Label nazwa = new Label();
        Label skladniki = new Label();
        Label rozmiar = new Label();
        Label cena = new Label();

		nazwa.Text = pizza.Nazwa;
		skladniki.Text = pizza.Skladniki;
		rozmiar.Text = pizza.Rozmiar.ToString();
		cena.Text = pizza.Cena.ToString();

		dataView.Add(nazwa);
		dataView.Add(skladniki);
		dataView.Add(rozmiar);
		dataView.Add(cena);

		view.Add(image);
		view.Add(dataView);

		allView.Add(view);


    }
}