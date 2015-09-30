using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Connectivity.Plugin;
using Connectivity.Plugin.Abstractions;
using System;
using System.Linq;

namespace VideoPlayerDemo.Droid
{
    [Activity(Label = "VideoPlayerDemo.Droid",
        MainLauncher = true,
        Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string VideoPositionKey = "VideoPosition";
        private const int MediaControllerTimeout = 3000;

        private VideoView videoPlayer;
        private MediaController mediaController;
        private ProgressBar videoProgressBar;
        private TextView statusMessageTextView;
        private int startingPosition;

        #region Overrides
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            startingPosition = (bundle != null) ? bundle.GetInt(VideoPositionKey) : 0;

        }

        protected override void OnStart()
        {
            base.OnStart();

            InitializeVideoPlayer();
            RegisterEvents();
            UpdateVideoPlayerState(false);
            LaunchVideo();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnregisterEvents();
            if (mediaController != null)
            {
                mediaController.Dispose();
                mediaController = null;
            }
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            UpdateVideoPlayerState(false);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            startingPosition = (videoPlayer.IsPlaying) ? videoPlayer.CurrentPosition : startingPosition;
            outState.PutInt(VideoPositionKey,startingPosition);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            if (!videoPlayer.IsPlaying)
            {
                startingPosition = (savedInstanceState != null) ? savedInstanceState.GetInt(VideoPositionKey) : 0;

                UpdateVideoPlayerState(false);
                LaunchVideo();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (videoPlayer.IsPlaying)
            {
                startingPosition = videoPlayer.CurrentPosition;
            }
        }

        private void OnCurrentConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            UpdateVideoPlayerState(false);
            LaunchVideo();
        }

        #endregion

        #region Private Methods

        private void InitializeVideoPlayer()
        {
            videoPlayer = FindViewById<VideoView>(Resource.Id.PlayerVideoView);
            videoProgressBar = FindViewById<ProgressBar>(Resource.Id.VideoProgressBar);
            statusMessageTextView = FindViewById<TextView>(Resource.Id.StatusMessageTextView);
            mediaController = new MediaController(this, true);
            videoPlayer.SetMediaController(mediaController);
        }

        private void LaunchVideo()
        {
            if (IsConnectedToWifi && !videoPlayer.IsPlaying)
            {
                //do the guys in this video look familiar?
                string videoUri = "http://bitly.com/1MC3Gig"; 
                videoPlayer.SetVideoURI(Android.Net.Uri.Parse(videoUri));
                videoPlayer.SeekTo(startingPosition);
                videoPlayer.Start();
            }
        }

        private void RegisterEvents()
        {
            videoPlayer.Prepared += OnVideoPlayerPrepared;
            CrossConnectivity.Current.ConnectivityChanged += OnCurrentConnectivityChanged;
        }

        private void UnregisterEvents()
        {
            videoPlayer.Prepared -= OnVideoPlayerPrepared;
            CrossConnectivity.Current.ConnectivityChanged -= OnCurrentConnectivityChanged;
        }

        private void UpdateVideoPlayerState(bool playVideo)
        {
            if (!IsConnectedToWifi)
            {
                statusMessageTextView.Visibility = ViewStates.Visible;
                videoProgressBar.Visibility = ViewStates.Gone;
                videoPlayer.Visibility = ViewStates.Gone;
            }
            else if (!videoPlayer.IsPlaying)
            {
                statusMessageTextView.Visibility = ViewStates.Gone;
                videoProgressBar.Visibility = (playVideo) ? ViewStates.Gone : ViewStates.Visible;
                videoPlayer.Visibility = ViewStates.Visible;
            }

        }

        private bool IsConnectedToWifi
        {
            get
            {
                return CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi);
            }
        }
        #endregion

        #region Event handlers
        private void OnVideoPlayerPrepared(object sender, EventArgs e)
        {
            UpdateVideoPlayerState(true);

            mediaController.SetAnchorView(videoPlayer);

            //show media controls for 3 seconds when video starts to play
            mediaController.Show(MediaControllerTimeout);
        }

        #endregion
    }
}

