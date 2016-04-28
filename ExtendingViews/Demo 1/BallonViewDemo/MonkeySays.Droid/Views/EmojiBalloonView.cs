using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace EmojiMe.Droid.Views
{
    public class EmojiBalloonView : View
    {
        private int _triangleHeight;
        private Color _balloonColor;

        public EmojiBalloonView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            TypedArray typeArray = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.EmojiBalloonView, 0, 0);
            BalloonColor = typeArray.GetColor(Resource.Styleable.EmojiBalloonView_balloonColor, Color.AntiqueWhite);
            TriangleHeight = typeArray.GetInt(Resource.Styleable.EmojiBalloonView_triangleHeight, 40);
        }

        public Color BalloonColor
        {
            get { return _balloonColor; }
            set
            {
                _balloonColor = value;
                RequestLayout();
                Invalidate();
            }
        }

        public int TriangleHeight
        {
            get { return _triangleHeight; }
            set
            {
                _triangleHeight = value;
                RequestLayout();
                Invalidate();
            }
        }

        public override void Draw(Canvas canvas)
        {
            var backgroundPaint = new Paint { Color = BalloonColor };
            RectF r = new RectF(0, 0, MeasuredWidth, MeasuredHeight - TriangleHeight);

            canvas.DrawRoundRect(r, 30f, 30f, backgroundPaint);

            //draw triangle starting at the center and bottom of the rectangle
            Point startingPoint = new Point(MeasuredWidth / 2, (int)r.Bottom);
            Point firstLine = new Point(MeasuredWidth / 2, MeasuredHeight);
            Point secondLine = new Point((MeasuredWidth / 2) - (TriangleHeight / 2), MeasuredHeight - TriangleHeight);

            Path path = new Path();
            path.MoveTo(startingPoint.X, startingPoint.Y);
            path.LineTo(firstLine.X, firstLine.Y);
            path.LineTo(secondLine.X, secondLine.Y);

            canvas.DrawPath(path, backgroundPaint);
        }
    }
}