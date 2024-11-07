using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace L212
{
    public partial class VecGraph : Form
    {
        public VecGraph()
        {
            InitializeComponent();
        }

        public void Draw(Vec2[] vectors)
        {

            Series NewSeries = new Series
            {
                Name = "Vectors",
                Color = Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
            };
            for (int i = 0; i < vectors.Length; i++)
            {
                NewSeries.Points.AddXY(0, 0);
                NewSeries.Points.AddXY(vectors[i].x, vectors[i].y);
            }

            ChartArea chartArea = new ChartArea
            {
                Name = "VectorArea",
                AxisX =
                {
                    Minimum = -10,
                    Maximum = 10,
                    Interval = 1,
                    IsMarksNextToAxis = false,
                    IsLabelAutoFit = false,
                    Crossing = 0,
                    LineWidth = 1,
                    MajorGrid = {  Interval = 1, LineColor = Color.LightBlue, LineWidth = 1 },
                    Enabled = AxisEnabled.True,
                },
                AxisY =
                {
                    Minimum = -10,
                    Maximum = 10,
                    Interval = 1,
                    IsMarksNextToAxis = false,
                    IsLabelAutoFit = false,
                    Crossing = 0,
                    LineWidth = 1,
                    MajorGrid = {  Interval = 1, LineColor = Color.LightBlue, LineWidth = 1 },
                    Enabled = AxisEnabled.True,
                },
            };

            Graph.ChartAreas.Add(chartArea);
            Graph.Series.Add(NewSeries);
            Graph.ChartAreas["VectorArea"].Visible = true;
        }
    }
}
