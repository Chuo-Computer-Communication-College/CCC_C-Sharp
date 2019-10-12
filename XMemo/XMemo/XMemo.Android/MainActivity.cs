using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XMemo.Droid
{
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            MemoHolder.Current.Memo = new Memo()
            {
                Date = DateTime.Now,
                Subject = "",
                Text = "",
            };

            DisplayMemo();

            var EditTextSubject = FindViewById<EditText>(Resource.Id.EditTextSubject);

            EditTextSubject.TextChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Subject = EditTextSubject.Text;
            };

            var EditTextMemo = FindViewById<EditText>(Resource.Id.EditTextMemo);

            EditTextMemo.TextChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Subject = EditTextMemo.Text;
            };

            FindViewById<EditText>(Resource.Id.EditTextDate).Click += EditTextDate_Click;
        }

        private void EditTextDate_Click(object sender, EventArgs e)
        {
            var vrDatePicker = new MyDatePicker();

            vrDatePicker.InitialDate = MemoHolder.Current.Memo.Date;

            vrDatePicker.Selected += (s2, e2) =>
            {
                MemoHolder.Current.Memo.Date = e2.SelectedDate;

                DisplayMemo();
            };

            vrDatePicker.Show(FragmentManager, "tag");
        }

        private void DisplayMemo()
        {
            var vrMemo = MemoHolder.Current.Memo;

            FindViewById<EditText>(Resource.Id.EditTextDate).Text = string.Format("{0:yyyy/MM/dd}", vrMemo.Date);
            FindViewById<EditText>(Resource.Id.EditTextSubject).Text = vrMemo.Subject;
            FindViewById<EditText>(Resource.Id.EditTextMemo).Text = vrMemo.Text;
        }
    }
}


