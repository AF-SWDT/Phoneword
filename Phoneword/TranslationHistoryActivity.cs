using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;

// this is the second screen (activity) of the Phoneword Android app 

namespace Phoneword
{
    [Activity(Label = "@string/translationHistory")]

    public class TranslationHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //v Create your application here
            
            
            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);

        } //^ protected override void OnCreate(Bundle bundle)

    } //^ public class TranslationHistoryActivity : ListActivity

} //^ namespace Phoneword