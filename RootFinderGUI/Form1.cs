using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using DynamicExpresso;
using ZedGraph;

namespace RootFinderGUI {
    public partial class Form1 : Form {
        private Interpreter _theInterpreter;
        private double[] _calculatedRoots;
        private int _stepIndex;

        // To be changed in run-time
        private string _theExpression = string.Empty;

        public Form1() {
            InitializeComponent();

            InitializeInterpreter();

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

        private void InitializeInterpreter() {
            // Write tinyexpr compatible functions as C# functions
            Func<double, double> abs = Math.Abs;
            Func<double, double> acos = Math.Acos;
            Func<double, double> asin = Math.Asin;
            Func<double, double> atan = Math.Atan;
            Func<double, double> ceil = Math.Ceiling;
            Func<double, double> cos = Math.Cos;
            Func<double, double> cosh = Math.Cosh;
            Func<double, double> exp = Math.Exp;
            Func<double, double> floor = Math.Floor;
            Func<double, double> ln = Math.Log;
            Func<double, double> log = Math.Log10;
            Func<double, double> sin = Math.Sin;
            Func<double, double> sinh = Math.Sinh;
            Func<double, double> sqrt = Math.Sqrt;
            Func<double, double> tan = Math.Tan;
            Func<double, double> tanh = Math.Tanh;
            Func<double, double, double> pow = Math.Pow;

            // Create the Interpreter
            _theInterpreter = new Interpreter();

            // Map written tinyexpr compatible functions to Interpreter functions
            _theInterpreter.SetFunction("abs", abs);
            _theInterpreter.SetFunction("acos", acos);
            _theInterpreter.SetFunction("asin", asin);
            _theInterpreter.SetFunction("atan", atan);
            _theInterpreter.SetFunction("ceil", ceil);
            _theInterpreter.SetFunction("cos", cos);
            _theInterpreter.SetFunction("cosh", cosh);
            _theInterpreter.SetFunction("exp", exp);
            _theInterpreter.SetFunction("floor", floor);
            _theInterpreter.SetFunction("ln", ln);
            _theInterpreter.SetFunction("log", log);
            _theInterpreter.SetFunction("sin", sin);
            _theInterpreter.SetFunction("sinh", sinh);
            _theInterpreter.SetFunction("sqrt", sqrt);
            _theInterpreter.SetFunction("tan", tan);
            _theInterpreter.SetFunction("tanh", tanh);
            _theInterpreter.SetFunction("pow", pow);
        }

        // ReSharper disable once InconsistentNaming
        private double f(double x) {
            // FIX Do NOT create new Parameter object for every evaluation
            return (double) _theInterpreter.Eval(_theExpression, new Parameter("x", x));
        }

        private void Draw(ZedGraphControl zgc, string expression, double from, double to, double step = 0.1f) {
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
                list1.Add(i, f(i));
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
                double.Parse(nmFrom.Value.ToString(CultureInfo.InvariantCulture)),
                double.Parse(nmTo.Value.ToString(CultureInfo.InvariantCulture))
                );

            _theLine = DrawVerticalGuideLine(_calculatedRoots[0]);
        }

        // Draws vertical guide line on x-axis on point given parameter x
        private LineItem DrawVerticalGuideLine(double x, double yMin = -1d, double yMax = 1d) {
            // Get Pane reference from ZedGraphControl
            GraphPane thePane = zed.GraphPane;

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
        private void UpdateVerticalGuideLine(LineItem theLine, double x, double yMin = -1d, double yMax = 1d) {
            if (null == theLine) {
                throw new NullReferenceException("Line to update is uninitialized. Please use DrawVerticalGuideLine method instead.");
            }

            // Get Pane reference from ZedGraphControl
            GraphPane thePane = zed.GraphPane;

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
    }
}
