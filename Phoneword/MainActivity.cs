using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

// This is a main screen (activity) of the Phoneword Android app

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    //^ could be [Activity(Lable1 = "PhoneWord", MainLauncher = true)]

    public class MainActivity : Activity
        //^ previous version public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        //v OnCreate method, ets.

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           

            //v Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //v New code will go here

            //v Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            //v Add method to translate number
            string translatedNumber = string.Empty;
            //^ could be omitted if we declare string translatedNumber bellow in method translateButton.Click += (sender, e) =>
            translateButton.Click += (sender, e) =>
            {
                //v Translate user's alphanumeric phone number to numeric

                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                //^ could be string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                //^ if we do not declare string variable before method declaration translateButton.click += (sender, e) => 

                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = "";
                    //^ could be translatedPhoneWord.Text = string.Empty;

                }//^ if

                else
                {
                    //v code for one MainActivity only
                    translatedPhoneWord.Text = translatedNumber;
                    //v code for TranslationHistoryActivity
                    phoneNumbers.Add(translatedNumber);
                    //v code for TranslationHistoryActivity
                    translationHistoryButton.Enabled = true;

                }//^ else

            };//^ translateButton.Click += (sender, e) =>


            //v Add method to wire up the Translation History button
            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);

            };//^ translationHistoryButton.Click += (sender, e) =>

        }//^ protected override void OnCreate(Bundle savedInstanceState)

    }//^ public class MainActivity : AppCompatActivity

}//^ namespace Phoneword