using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using CustomBalloon;

namespace MonkeySays.Droid
{
    [Activity(Label = "MonkeySays.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MyBalloonView _balloonView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _balloonView = FindViewById<MyBalloonView>(Resource.Id.MonkeyBalloon);
            InitializeBalloonView();
        }

        private void InitializeBalloonView()
        {
            _balloonView.BalloonColor = Color.Purple;
            _balloonView.AccentColor = Color.Pink;
            _balloonView.TextColor = Color.White;
            _balloonView.TriangleHeight = 30;
            _balloonView.ShowEmojis = true;
            _balloonView.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Dip, 16f, Resources.DisplayMetrics);

            _balloonView.Text = "Good afternoon!";
        }
    }
}