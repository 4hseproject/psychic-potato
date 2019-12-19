using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetUI
{
    /// <summary>
    /// Логика взаимодействия для Mary_tries_graphs.xaml
    /// </summary>
    public partial class Mary_tries_graphs : Window
    {
        public Mary_tries_graphs()
        {
            InitializeComponent();
            SizeChanged += UpdateGraph;
        }
        double func(double x) => // should be injected from VM
        Math.Sin(x);

        double minX = -2 * Math.PI; // should be injected from VM
        double maxX = 2 * Math.PI; // should be injected from VM

        double minY = -1.5; // should be injected from VM
        double maxY = 1.5; // should be injected from VM

        void UpdateGraph(object sender, SizeChangedEventArgs e)
        {
            var pixelWidth = Graph.ActualWidth;
            var pixelHeight = Graph.ActualHeight;
            PointCollection points = new PointCollection((int)pixelWidth + 1);
            for (int pixelX = 0; pixelX < pixelWidth; pixelX++)
            {
                var x = MapFromPixel(pixelX, pixelWidth, minX, maxX);
                var y = func(x);
                var pixelY = pixelHeight - MapToPixel(y, minY, maxY, pixelHeight);
                points.Add(new Point(pixelX, pixelY));
            }
            Graph.Points = points;
        }

        double MapFromPixel(double pixelV, double pixelMax, double minV, double maxV) =>
            minV + (pixelV / pixelMax) * (maxX - minX);

        double MapToPixel(double v, double minV, double maxV, double pixelMax) =>
            (v - minV) / (maxV - minV) * pixelMax;
    }
}
