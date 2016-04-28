using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CustomBalloon
{
    public class MyBalloonView : View
    {
        private readonly Regex re = new Regex(@"\:(\w+)\:", RegexOptions.Compiled);

        private readonly Dictionary<string, int> _emojis =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "grin", 0x1F601 },
            { "joy", 0x1F602 },
            { "smile", 0x1F603 },
            { "smiling", 0x1F604 },
            { "sweat_smile", 0x1F605 },
            { "laugh", 0x1F606 }
        };

        private readonly List<string> monkeyPhrases =
            new List<string>() {
             "Xamarin Evolve rocks my rainbow socks!",
             "Have you visited the Darwin Lounge?",
             "Is Woz in the house?",
             "What's in your swag bag?",
             "I learned a lot this week!",
             "Did you get a selfie with James?",
             "How much coffee did you drink today?",
             "I'm ready to create awesome apps!",
             "A banana split would be good right now"
        };

        private Paint _textPaint;
        private Paint _backgroundPaint;
        private bool _showEmojis;
        private string _text;
        private float _textSize;
        private int _triangleHeight;
        private Color _balloonColor;
        private Color _textColor;
        private Color _accentColor;
        private bool _useAccentColor;

        //at a minimum you must provide a constructor that takes a Context and an AttributeSet object as parameters
        public MyBalloonView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitializePaint();
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = FormatText(value);
                InvalidateAndRedraw();
            }
        }

        public float TextSize
        {
            get { return _textSize; }
            set
            {
                _textSize = value;
                _textPaint.TextSize = _textSize;
                InvalidateAndRedraw();
            }
        }

        public bool ShowEmojis
        {
            get { return _showEmojis; }
            set
            {
                _showEmojis = value;
                InvalidateAndRedraw();
            }
        }

        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                InvalidateAndRedraw();
            }
        }

        public Color BalloonColor
        {
            get { return _balloonColor; }
            set
            {
                _balloonColor = value;
                InvalidateAndRedraw();
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                _textPaint.Color = _textColor;
                InvalidateAndRedraw();
            }
        }

        public int TriangleHeight
        {
            get { return _triangleHeight; }
            set
            {
                _triangleHeight = value;
                InvalidateAndRedraw();
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            _useAccentColor = (e.Action == MotionEventActions.Down);
            if (e.Action == MotionEventActions.Up)
            {
                this.Text = GetRandomPhrase();
            }
            InvalidateAndRedraw();
            return true;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            float textMeasurement = _textPaint.MeasureText(this.Text);
            SetMeasuredDimension((int)textMeasurement + 50, MeasuredHeight);
        }

        protected override void OnDraw(Canvas canvas)
        {
            _backgroundPaint.Color = (_useAccentColor) ? AccentColor : BalloonColor;

            float textMeasurement = _textPaint.MeasureText(this.Text);
            float balloonCenterX = MeasuredWidth / 2;
            int triangleStart = 80;

            RectF r = new RectF(0, 0, MeasuredWidth, MeasuredHeight - TriangleHeight);
            canvas.DrawRoundRect(r, 30f, 30f, _backgroundPaint);

            Point startingPoint = new Point(triangleStart, (int)r.Bottom);
            Point firstLine = new Point(triangleStart, MeasuredHeight);
            Point secondLine = new Point(triangleStart - (TriangleHeight / 2), MeasuredHeight - TriangleHeight);

            Path path = new Path();
            path.MoveTo(startingPoint.X, startingPoint.Y);
            path.LineTo(firstLine.X, firstLine.Y);
            path.LineTo(secondLine.X, secondLine.Y);

            float textX = balloonCenterX - textMeasurement / 2;
            float textY = MeasuredHeight / 2;

            canvas.DrawPath(path, _backgroundPaint);
            canvas.DrawText(this.Text, textX, textY, _textPaint);
        }

        private void InvalidateAndRedraw()
        {
            Invalidate();
            RequestLayout();
        }

        private string FormatText(string text)
        {
            string formattedText = text;

            if (ShowEmojis && !string.IsNullOrEmpty(text))
            {
                formattedText = re.Replace(text,
                    match => GetEmoji(match.Groups[1].Value, match.Value));
            }

            return formattedText;
        }

        private string GetEmoji(string key, string originalText)
        {
            string emojified = _emojis.ContainsKey(key)
                 ? new string(Character.ToChars(_emojis[key]))
                 : originalText;

            return emojified;
        }

        private string GetRandomPhrase()
        {
            int maxValue = monkeyPhrases.Count - 1;
            int maxEmojiValue = _emojis.Count - 1;

            Random randomPhrase = new Random();
            int randomIndex = randomPhrase.Next(0, maxValue);
            string phrase = monkeyPhrases.ElementAt(randomIndex);

            Random randomEmoji = new Random();
            int randomEmojiIndex = randomEmoji.Next(0, maxEmojiValue);
            string emoji = _emojis.Keys.ElementAt(randomEmojiIndex);

            return $"{phrase} :{emoji}:";
        }

        private void InitializePaint()
        {
            _textPaint = new Paint();
            _backgroundPaint = new Paint();
        }
    }
}