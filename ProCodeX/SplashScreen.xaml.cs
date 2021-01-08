using System;
using System.Threading;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.Resources;

namespace ProCodeX
{


    public partial class SplashScreen : Window
    {
         public SplashScreen()
        {

            //I had to put all the code in a function so that i can add delay without fucking up the window rendering.
            InitializeComponent();
            SplashScreenFunc();


        }
        public async void SplashScreenFunc()
        {
            string[] memes = { "Press F to pay respect", "Winner Winner Chicken Dinner",
                "I hate java", "Assembly is the language of men",
                "Xamarin is a waste of time, use WPF or android studio instead.",
                "I love you", "It's a free real estate", "Pay 1$ to unlock the next screen. -EA",
                "Adobe is overpriced", "If Apple made a car, Would it have Windows?" };

            ProgressBar1.Value = 0;
            await Task.Delay(2000);
            ProgressBar1.Value = 35;
            LoadingLabel.Content = "Loading: Random APIs and libraries that gave me headaches";
            await Task.Delay(3500);
            ProgressBar1.Value = 75;
            LoadingLabel.Content = "Loading: Main Screen images and stuff";
            await Task.Delay(1500);
            Random rand = new Random();
            int index = rand.Next(memes.Length);
            ProgressBar1.Value = 1000;
            LoadingLabel.Content = memes[index];
            //load a random meme
            await Task.Delay(1000);

            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();


        }
        private void RadProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //I added this so the program doesn't crash.
        }
    }
}
