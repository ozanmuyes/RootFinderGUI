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

        // To be changed in run-time
        private string _theExpression = string.Empty;

        public Form1() {
            InitializeComponent();

            // TODO Obtain calculated roots from the dll
            _calculatedRoots = new[] {
                -3.0000000000000000d,
                -3.5000000000000000d,
                -3.7500000000000000d,
                -3.6250000000000000d,
                -3.6875000000000000d,
                -3.6562500000000000d,
                -3.6406250000000000d,
                -3.6328125000000000d,
                -3.6367187500000000d,
                -3.6386718750000000d,
                -3.6376953125000000d,
                -3.6381835937500000d,
                -3.6379394531250000d,
                -3.6380615234375000d,
                -3.6380004882812500d,
                -3.6379699707031250d,
                -3.6379547119140625d,
                -3.6379623413085938d,
                -3.6379585266113281d,
                -3.6379566192626953d,
                -3.6379575729370117d,
                -3.6379580497741699d,
                -3.6379578113555908d,
                -3.6379579305648804d,
                -3.6379579901695251d,
                -3.6379579603672028d,
                -3.6379579752683640d,
                -3.6379579678177834d,
                -3.6379579640924931d,
                -3.6379579659551382d,
                -3.6379579668864608d,
                -3.6379579673521221d,
                -3.6379579675849527d,
                -3.6379579674685374d,
                -3.6379579675267451d,
                -3.6379579675558489d,
                -3.6379579675704008d,
                -3.6379579675631248d,
                -3.6379579675594869d,
                -3.6379579675613058d,
                -3.6379579675603964d,
                -3.6379579675608511d,
                -3.6379579675610785d,
                -3.6379579675611922d,
                -3.6379579675612490d,
                -3.6379579675612774d,
                -3.6379579675612916d,
                -3.6379579675612845d,
                -3.6379579675612810d,
                -3.6379579675612828d
            };
        }

        private void Draw(ZedGraphControl zgc, string expression, double from, double to, double step = 0.01f) {
            // Obtain GraphPane from ZedGraphControl
            GraphPane pane = zgc.GraphPane;

            int compileResult = LibraryBridge.CompileExpression(expression);

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
            int pointsCount = LibraryBridge.CalculatePointsCount(startValue, endValue, step);
            double[] points = new double[pointsCount];
            IntPtr pointsPtr = LibraryBridge.GetFunctionPoints(startValue, endValue, step);
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
            }

            // Add the list to GraphPane
            pane.AddCurve(expression, list1, Color.Blue, SymbolType.None);

            // Finally make ZedGraphControl to re-draw itself
            zgc.AxisChange();
            zgc.Invalidate();
        }

        private void Draw2(ZedGraphControl zgc, string expression, double from, double to, double step = 0.1f) {
            // Obtain GraphPane from ZedGraphControl
            GraphPane pane = zgc.GraphPane;

            _theExpression = expression;

            // from MUST be less than to, ensure that
            if (from.CompareTo(to) > 1) {
                double temp = from;
                from = to;
                to = temp;
            }

            // Create the list...
            PointPairList list1 = new PointPairList();
            // ... and add points to the list.
            for (double i = from; i < to; i += step) {
                list1.Add(i, LibraryBridge.F(i));
            }

            // Add the list to GraphPane
            pane.AddCurve(_theExpression, list1, Color.Blue, SymbolType.Square);

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

        private void zed_MouseEnter(object sender, EventArgs e) {
            zed.Focus();
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
