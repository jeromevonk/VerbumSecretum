using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         // Source (http://world.std.com/~reinhold/diceware.html)

         // Not the greatest way to generate random numbers, but... (http://stackoverflow.com/questions/1234094/how-can-i-generate-truly-not-pseudo-random-numbers-with-c)
         rnd = new Random(Guid.NewGuid().GetHashCode());
      }

      private Random rnd;

      private void btGenerate_Click(object sender, RoutedEventArgs e)
      {
         if ( rbDiceware.IsChecked == true )
         {
            int iHowManyWords = comboWords.SelectedIndex + 4;

            String strPassword = "";

            for (int i = 0; i < iHowManyWords; i++ )
            {
               if ( rbEnglish.IsChecked == true )
               { 
                  strPassword += Wordlist_en.getWord( rnd.Next(0, 7776) );
               }
               else 
               {
                  strPassword += Wordlist_pt.getWord( rnd.Next(0, 7776) );
               }

               if ( i < iHowManyWords-1 )
               {
                  if ( cbSpaces.IsChecked == true)
                  {
                     strPassword += " "; // don't add a space to the end
                  }
                  
               }
            }

            // Diceware mode
            tbPwdResult.Text = strPassword;
         }
         else 
         {
            String strPassword = "";

            if ( cbAddSpecial.IsChecked == true )
            {
               strPassword += SpecialDigit.getDigit( rnd.Next(0, 36) );
            }

            for (int i = 0; i < 2; i++ )
            {
               strPassword += Wordlist_pt.getWord( rnd.Next(0, 7776) );
            }

            // Change one of the letters to upper
            for (int i = 0; i < strPassword.Length; i++ )
            {
               if ( strPassword[i] >= 'a' && strPassword[i] <='z')
               {
                  char[] array = strPassword.ToCharArray();
                  array[i] = char.ToUpper(array[i]);
                  strPassword = new string (array);
                  break;
               }
            }
            
            if ( cbAddNumbers.IsChecked == true )
            {
               strPassword += rnd.Next(100, 1000);
            }


            // Mixed mode
            tbPwdResult.Text = strPassword;
         }
      }

      private void btCopy_Click(object sender, RoutedEventArgs e)
      {
         Clipboard.SetText(tbPwdResult.Text);
      }

      private void OpenWebPage(string target)
      {
         try
         {
            System.Diagnostics.Process.Start(target);
         }
         catch ( System.ComponentModel.Win32Exception noBrowser )
         {
            if (noBrowser.ErrorCode==-2147467259)
            {
               MessageBox.Show(noBrowser.Message);
            }
         }
         catch (System.Exception other)
         {
            MessageBox.Show(other.Message);
         }
      }

      private void diceware_click(object sender, RoutedEventArgs e)
      {
         OpenWebPage("http://world.std.com/~reinhold/diceware.html");
      }

      private void howsecure_click(object sender, RoutedEventArgs e)
      {
         OpenWebPage("https://howsecureismypassword.net/");
      }

      private void kaspersky_click(object sender, RoutedEventArgs e)
      {
         OpenWebPage("https://password.kaspersky.com/");
      }

      private void xkcd_click(object sender, RoutedEventArgs e)
      {
         OpenWebPage("https://xkcd.com/936/");
      }
   }
}
