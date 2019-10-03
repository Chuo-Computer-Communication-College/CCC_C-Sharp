using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace KitchenTimer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private bool _blActuated = false;

        private int _intRemainingMilliSec = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var buttonAdd10Min = FindViewById<Button>(Resource.Id.ButtonAdd10Min);

            buttonAdd10Min.Click += ButtonAdd10Min_Click;

            var buttonAdd1Min = FindViewById<Button>(Resource.Id.ButtonAdd1Min);

            buttonAdd1Min.Click += (s, e) =>
            {
                _intRemainingMilliSec += 60 * 1000;

                ShowRemainingTime();
            };

            var buttonAdd10Sec = FindViewById<Button>(Resource.Id.ButtonAdd10Sec);

            buttonAdd10Sec.Click += ButtonAdd10Sec_Click;

            var buttonAdd1Sec = FindViewById<Button>(Resource.Id.ButtonAdd1Sec);

            buttonAdd1Sec.Click += (s, e) =>
            {
                AddRemainingTime(1);
            };

            var buttonClear = FindViewById<Button>(Resource.Id.ButtonClear);

            buttonClear.Click += (s, e) =>
            {
                _blActuated = false;

                _intRemainingMilliSec = 0;

                ShowRemainingTime();
            };
        }

        private void ButtonAdd10Min_Click(object sender, System.EventArgs e)
        {
            _intRemainingMilliSec += 600 * 1000;

            ShowRemainingTime();
        }

        private void ButtonAdd10Sec_Click(object sender, System.EventArgs e)
        {
            AddRemainingTime(10);
        }

        private void ShowRemainingTime()
        {
            var vrSecond = _intRemainingMilliSec / 1000;

            FindViewById<TextView>(Resource.Id.RemainingTimeTextView).Text = string.Format("{0:f0}:{1:d2}", vrSecond / 60, vrSecond % 60);
        }

        private void AddRemainingTime(int second)
        {
            _intRemainingMilliSec += second * 1000;

            ShowRemainingTime();
        }
    }
}