using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZedGraph;

namespace RootFinderGUI {
    public partial class Form1 : Form {
        private double[] _calculatedRoots;
        private int _stepIndex;
        private double _verticalGuideLineHeight;

        public Form1() {
            InitializeComponent();

            // Initialize ZedGraph axis
            Console.WriteLine(zed.GraphPane.XAxis.Scale);
            Console.WriteLine(zed.GraphPane.X2Axis.Scale);
            Console.WriteLine(zed.GraphPane.YAxis.Scale);
            Console.WriteLine(zed.GraphPane.Y2Axis.Scale);

            // TODO Obtain calculated roots from the dll
            _calculatedRoots = new[] {
                1.5000000000000000d,
                1.7500000000000000d,
                1.6250000000000000d,
                1.6875000000000000d,
                1.7187500000000000d,
                1.7343750000000000d,
                1.7265625000000000d,
                1.7304687500000000d,
                1.7324218750000000d,
                1.7314453125000000d,
                1.7319335937500000d,
                1.7321777343750000d,
                1.7320556640625000d,
                1.7319946289062500d,
                1.7320251464843750d,
                1.7320404052734375d,
                1.7320480346679687d,
                1.7320518493652344d,
                1.7320499420166016d,
                1.7320508956909180d,
                1.7320504188537598d,
                1.7320506572723389d,
                1.7320507764816284d,
                1.7320508360862732d,
                1.7320508062839508d,
                1.7320508211851120d,
                1.7320508137345314d,
                1.7320508100092411d,
                1.7320508081465960d,
                1.7320508072152734d,
                1.7320508076809347d,
                1.7320508074481040d,
                1.7320508075645193d,
                1.7320508076227270d,
                1.7320508075936232d,
                1.7320508075790713d,
                1.7320508075717953d,
                1.7320508075681573d,
                1.7320508075699763d,
                1.7320508075690668d,
                1.7320508075686121d,
                1.7320508075688394d,
                1.7320508075689531d,
                1.7320508075688963d,
                1.7320508075688679d,
                1.7320508075688821d,
                1.7320508075688750d,
                1.7320508075688785d,
                1.7320508075688767d
            };
        }

        private void Draw(ZedGraphControl zgc, string expression, double from, double to, double step = 0.01f) {
            // Obtain GraphPane from ZedGraphControl
            GraphPane pane = zgc.GraphPane;

            int compileResult = RootFinderLibrary.CompileExpression(expression);

            if (0 != compileResult) {
                MessageBox.Show(string.Format(@"Expression error on col {0}", compileResult), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbExpression.Focus();

                return;
            }

            // from MUST be less than to, ensure that
            if (from.CompareTo(to) > 1) {
                double temp = from;
                from = to;
                to = temp;
            }

            double startValue = from,
                endValue = to;

            // Go to the library and get points
            int pointsCount = RootFinderLibrary.CalculatePointsCount(startValue, endValue, step);
Console.WriteLine(pointsCount);
            double[] points = new double[pointsCount];
            IntPtr pointsPtr = RootFinderLibrary.GetFunctionPoints(startValue, endValue, step);
            Marshal.Copy(pointsPtr, points, 0, pointsCount);

            // Create the list...
            PointPairList list1 = new PointPairList();
            // ... and add points to the list.
            // ReSharper disable once TooWideLocalVariableScope
            double thePoint;
            for (int i = 0; i < pointsCount; i++) {
                thePoint = startValue + (step * i);

                if (thePoint > endValue) {
                    thePoint = endValue;
                }

                list1.Add(thePoint, points[i]);
//Console.WriteLine(@"{0} {1}", thePoint, points[i]);
            }

            // Add the list to GraphPane
            pane.AddCurve(expression, list1, Color.Blue, SymbolType.None);

            // Finally make ZedGraphControl to re-draw itself
            zgc.AxisChange();
            zgc.Invalidate();
        }

        private void btDraw_Click(object sender, EventArgs e) {
            Draw(
                zed,
                tbExpression.Text,
                double.Parse(nmFrom.Text.ToString(CultureInfo.InvariantCulture)),
                double.Parse(nmTo.Text.ToString(CultureInfo.InvariantCulture)),
                double.Parse(nmStep.Text.ToString(CultureInfo.InvariantCulture))
                );

            _theLine = DrawVerticalGuideLine(_calculatedRoots[0]);
        }

        // Draws vertical guide line on x-axis on point given parameter x
        private LineItem DrawVerticalGuideLine(double x, double yMin = double.NaN, double yMax = double.NaN) {
            // Get Pane reference from ZedGraphControl
            GraphPane thePane = zed.GraphPane;

            _verticalGuideLineHeight = zed.GraphPane.YAxis.Scale.MajorStep * 2;
            if (double.IsNaN(yMin)) {
                yMin = _verticalGuideLineHeight * -1;
            }
            if (double.IsNaN(yMax)) {
                yMax = _verticalGuideLineHeight;
            }

            LineItem newLine = new LineItem(string.Empty, new[] {x, x}, new[] {yMin, yMax}, Color.Black, SymbolType.None) {
                Line = {
                    Style = DashStyle.Dash,
                    Width = 1f
                }
            };

            // Add new line
            thePane.CurveList.Add(newLine);

            /**
             * Do NOT call AxisChange() here,
             * just force to re-draw
             */
            zed.Invalidate();

            return newLine;
        }

        // Updates given vertical guide line
        private void UpdateVerticalGuideLine(LineItem theLine, double x, double yMin = double.NaN, double yMax = double.NaN) {
            if (null == theLine) {
                throw new NullReferenceException("Line to update is uninitialized. Please use DrawVerticalGuideLine method instead.");
            }

            // Get Pane reference from ZedGraphControl
            GraphPane thePane = zed.GraphPane;

            _verticalGuideLineHeight = zed.GraphPane.YAxis.Scale.MajorStep * 2;
            if (double.IsNaN(yMin)) {
                yMin = _verticalGuideLineHeight * -1;
            }
            if (double.IsNaN(yMax)) {
                yMax = _verticalGuideLineHeight;
            }

            // Remove the old one...
            int index = thePane.CurveList.IndexOf(theLine);
            if (-1 < index) {
                thePane.CurveList.RemoveAt(index);
            }

            // Update the line
            theLine.Points = new PointPairList(new[] {x, x}, new[] {yMin, yMax});

            // Add new line
            thePane.CurveList.Add(theLine);

            /**
             * Do NOT call AxisChange() here,
             * just force to re-draw
             */
            zed.Invalidate();
        }

        #region Step Buttons

        private LineItem _theLine;

        private void btNextStep_Click(object sender, EventArgs e) {
            // Increment step index if applicable
            if (_calculatedRoots.Length - 1 == _stepIndex) {
                _stepIndex = _calculatedRoots.Length - 1;
            } else {
                _stepIndex += 1;
            }

            if (null == _theLine) {
                _theLine = DrawVerticalGuideLine(_calculatedRoots[_stepIndex]);
            } else {
                UpdateVerticalGuideLine(_theLine, _calculatedRoots[_stepIndex]);
            }

            lbRoot.Text = _calculatedRoots[_stepIndex].ToString(CultureInfo.CurrentCulture);
        }

        private void btPreviousStep_Click(object sender, EventArgs e) {
            // Decrement step index if applicable
            if (0 == _stepIndex) {
                _stepIndex = 0;
            } else {
                _stepIndex -= 1;
            }

            if (null == _theLine) {
                _theLine = DrawVerticalGuideLine(_calculatedRoots[_stepIndex]);
            } else {
                UpdateVerticalGuideLine(_theLine, _calculatedRoots[_stepIndex]);
            }

            lbRoot.Text = _calculatedRoots[_stepIndex].ToString(CultureInfo.CurrentCulture);
        }

        #endregion

        private void zed_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.ControlKey) {
                zed.IsShowCursorValues = true;
            }
        }

        private void zed_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.ControlKey) {
                zed.IsShowCursorValues = false;
            }
        }

        private void zed_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState) {
            if (null == _theLine) {
                return;
            }

            _verticalGuideLineHeight = zed.GraphPane.YAxis.Scale.MajorStep * 2;

            UpdateVerticalGuideLine(
                _theLine,
                _theLine.Points[0].X,
                _verticalGuideLineHeight * -1,
                _verticalGuideLineHeight
                );
        }
    }
}
