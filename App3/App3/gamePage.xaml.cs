using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class gamePage : ContentPage
	{
		public gamePage ()
		{

            try
            {
                InitializeComponent();
                Public.guessed = "";
                Public.word = Public.ReadFile();
                Console.WriteLine(Public.word);
                printBlankSpaces(Public.word);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }



        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }

    

        public void changeImage(int letterCounter)
        {
            
            switch(letterCounter)
            {
                case 0:
                    image.Source = "hangman1.png";
                    break;
                case 1:
                    image.Source = "hangman2.png";
                    break;
                case 2:
                    image.Source = "hangman3.png";
                    break;
                case 3:
                    image.Source = "hangman4.png";
                    break;
                case 4:
                    image.Source = "hangman5.png";
                    break;
                case 5:
                    image.Source = "hangman6.png";
                    break;
                case 6:
                    image.Source = "hangman7.png";
                    break;
                default:
                    break;
            }
        }

        

        public void printBlankSpaces(string word)
        {
            
            
            int lenght = word.Length;

            for(int i=0; i<word.Length;i++)
            {
                Guessed.Text += "_ ";
            }
        }

        public void changeSpacesToLetters(string word, string letter)
        {

            letter = entry.Text.ToLower();
            char[] wordArray = word.ToCharArray();
            char[] guessedArray = Guessed.Text.ToCharArray();
            char[] publicGuessedArray = Public.guessed.ToCharArray();
            if (word.Contains(letter))
            {
                
                for(int i=0; i<word.Length;i++)
                {
                    if(letter[0]==wordArray[i])
                    {
                        if(i==0)
                        {
                            guessedArray[0] = letter[0];
                        }
                        else
                        {
                            guessedArray[i * 2] = letter[0];
                        }

                        publicGuessedArray[i] = letter[0];
                    }
                }



                Public.guessed = new string(publicGuessedArray);
                Guessed.Text = new string(guessedArray);


                
            }


        }

        private async void won_game()
        {
            
            if (Public.word==Public.guessed)
            {
                await DisplayAlert("CONGRATULATIONS", "You Win.", "OK");
                await Navigation.PushAsync(new MainPage());
            }
        }

        public int addBadLetters(string word, string letter, int letterCounter)
        {

            letter = entry.Text.ToLower();
            if(!(word.Contains(letter)))
                {
                Missed.Text += letter + " ";
                letterCounter++;
                }

            return letterCounter;

        }

      

        private bool Check_entry()
        {
            

            if (entry!=null)
            {
                
                null_alert.IsVisible = false;
            }
            else
            {
                null_alert.IsVisible = true;
            }

            if(entry.Text.Length>1)
            {
                
                bad_characters.IsVisible = true;
            }
            else
            {
                bad_characters.IsVisible = false;
                return true;
            }
            return false;
       
                
        }

        private async void lose_game()
        {

            if (Public.letterCounter == 6)
            {
                await DisplayAlert("GAME OVER", "You Lose.", "OK");
                await Navigation.PushAsync(new MainPage());
            }
        }


        private void Add_letter_Clicked(object sender, EventArgs e)
        {

            try
            {
                string letter = "";


                if (Check_entry() == true)
                {
                    Public.letterCounter = addBadLetters(Public.word, letter, Public.letterCounter);
                    changeSpacesToLetters(Public.word, letter);
                    changeImage(Public.letterCounter);
                    entry.Text = "";
                    lose_game();
                    won_game();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }
    }



}