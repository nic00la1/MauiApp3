using MauiApp3.Model;

namespace MauiApp3.View
{
    public partial class MainPage : ContentPage
    {
        // int count = 0;
        List<UserModel> users = new List<UserModel>();
        public MainPage()
        {
            InitializeComponent();
            Task.Run(LoadMauiAsset);
        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("loginData.txt");
            using var reader = new StreamReader(stream);

            while(reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                users.Add(new UserModel
                {
                    Login = line.Split(' ')[0],
                    Password = line.Split(' ')[1],
                    Name = line.Split(' ')[2],
                    Surname = line.Split(' ')[3]
                });
            }
        }

        public async void LoginMe(object sender, EventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordBox.Text;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                /*  Wykonaj kod, który wyszuka login z listy i 
                 *  sprawdzi hasło. Jeżeli hasło jest poprawne, 
                 *  przenosi do nowego okna i przekazuje Imie i 
                 *  nazwisko, w przeciwnym wypadku powiedz, 
                 *  że hasło jest niepoprawne 
                 */
                foreach(UserModel user in users)
                {
                    if(user.Login == login)
                    {
                        if (user.Password == password)
                        {
                            await Navigation.PushAsync(new SecondPage(
                                new UserModel()
                                {
                                    Name = user.Name,
                                    Surname = user.Surname,
                                    Login = user.Login
                                }
                            ));
                        }
                        else
                            errorText.Text = "Hasło nie jest poprawne!";
                    }
                }
            } else
            {
                errorText.Text = "Login lub hasło jest puste";
            }
        }
    }
}