using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GraphicsViewTester.StartupPage;
using Font = Microsoft.Maui.Graphics.Font;

namespace GraphicsViewTester
{
    internal class StartupPage : ContentPage
    {
        GraphicsDrawable graphicsDrawable;
        public StartupPage()
        {
            var topLabel = new Label { Text = "LabelText", FontSize = 30 };

            var graphic = new GraphicsView();
            graphicsDrawable = new GraphicsDrawable();
            graphic.Drawable = graphicsDrawable;

            var topGrid = new Grid();
            topGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            topGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            topGrid.Add(topLabel,0,0);
            topGrid.Add(graphic, 0,0);

            var bottomLabel = new Label { Text = "LabelText", FontSize = 30 };
            var bottomGrid = new Grid();
            bottomGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            bottomGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            bottomGrid.Add(bottomLabel, 0, 0);

            var layout = new VerticalStackLayout { Children = { topGrid , bottomGrid}};

            Content = layout;

        }

        public class GraphicsDrawable : IDrawable
        {

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {

                PathF path = new PathF();
                path.MoveTo(dirtyRect.Left, dirtyRect.Top + dirtyRect.Height/2);
                path.LineTo(dirtyRect.Left + dirtyRect.Width/2, dirtyRect.Top + dirtyRect.Height / 2);
                canvas.StrokeColor = Colors.Blue.MultiplyAlpha(0.5f);
                canvas.FillColor = Colors.LightBlue.MultiplyAlpha(0.5f);
                canvas.StrokeSize = 2;
                canvas.DrawPath(path);

                canvas.FontColor = Colors.Black;
                canvas.FontSize = 10;
                canvas.Font = Font.Default;


                canvas.DrawString("GraphicsText", dirtyRect.Left + dirtyRect.Width / 2, dirtyRect.Top + dirtyRect.Height / 2, HorizontalAlignment.Left);
            }
        }
    }
}
