using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FixedPoint;
using NUnit.Framework;

namespace FPTesting {
    public class plotting {
        [Test]
        public void Atan_Plottting() {
            var tans = new List<double>();
            var correctValue = new List<double>();
            var approxValue1 = new List<double>();
            var approxValue2 = new List<double>();
            var approxValueError1 = new List<double>();
            var approxValueError2 = new List<double>();
            for (var i = 0; i < 2000; i++) {
                var tan = (2 * i / 2000f) - 1;
                tans.Add(tan);
            }
 
            foreach (var tan in tans) {
                var correctTan = Math.Atan(tan);
                correctValue.Add(correctTan);
                var aprox1Tan = fixmath.Atan(fp.ParseUnsafe((float) tan)).AsDouble;
                approxValue1.Add(aprox1Tan);
                approxValueError1.Add(correctTan - aprox1Tan);
                var aprox2Tan = fixmath.AtanApproximated(fp.ParseUnsafe((float) tan)).AsDouble;
                approxValue2.Add(aprox2Tan);
                approxValueError2.Add(correctTan - aprox2Tan);
            }

            var plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(tans.ToArray(), correctValue.ToArray(), Color.CadetBlue, 0.01f, 1, "Math.Atan");
            plt.PlotScatter(tans.ToArray(), approxValue1.ToArray(), Color.Firebrick, 0.01f, 1f, "fixmath.Atan");
            plt.PlotScatter(tans.ToArray(), approxValue2.ToArray(), Color.FromArgb(74, 178, 67), 0.01f, 1, "fixmath.Atan_2");
            plt.AxisAuto();
            plt.SaveFig("Atan.png");
            
            plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(tans.ToArray(), approxValueError1.ToArray(), Color.Firebrick,             0.01f, 1f, "fixmath.Atan");
            plt.PlotScatter(tans.ToArray(), approxValueError2.ToArray(), Color.FromArgb(74, 178, 67), 0.01f, 1,  "fixmath.Atan_2");
            plt.AxisAuto();
            plt.SaveFig("Atan_error.png");
        }
        
        [Test]
        public void Atan2_Plottting() {
            var xValues           = new List<double>();
            var correctValue      = new List<double>();
            var approxValue1      = new List<double>();
            var approxValueError1 = new List<double>();
            for (var i = 0; i < 2000; i++) {
                var tan = (2 * i / 2000f) - 1;
                xValues.Add(tan);
            }
 
            foreach (var tan in xValues) {
                var correctTan = Math.Atan2(tan, 1);
                correctValue.Add(correctTan);
                var aprox1Tan = fixmath.Atan2(fp.ParseUnsafe((float) tan), fp._1).AsDouble;
                approxValue1.Add(aprox1Tan);
                approxValueError1.Add(correctTan - aprox1Tan);
            }

            var plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(xValues.ToArray(), correctValue.ToArray(), Color.CadetBlue,             0.01f, 1,  "Math.Atan2");
            plt.PlotScatter(xValues.ToArray(), approxValue1.ToArray(), Color.Firebrick,             0.01f, 1f, "fixmath.Atan2");
            plt.AxisAuto();
            plt.SaveFig("Atan2.png");
            
            plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(xValues.ToArray(), approxValueError1.ToArray(), Color.Firebrick,             0.01f, 1f, "fixmath.Atan2");
            plt.AxisAuto();
            plt.SaveFig("Atan2_error.png");
        }
        
        [Test]
        public void Exp_Plottting() {
            var xValues           = new List<double>();
            var correctValue      = new List<double>();
            var approxValue2 = new List<double>();
            var approxValue3 = new List<double>();
            var approxValueError2 = new List<double>();
            var approxValueError3 = new List<double>();
            for (var i = 1; i < 2000; i++) {
                var val = 24 * i / 2000f;
                xValues.Add(val);
            }

            for (var i = 0; i < xValues.Count; i++) {
                var val        = xValues[i];
                var correctVal = Math.Exp(val);
                correctValue.Add(correctVal);

                var aprox3Val = fixmath.Exp(fp.ParseUnsafe((float) val)).AsDouble;
                approxValue3.Add(aprox3Val);
                approxValueError3.Add(correctVal - aprox3Val);
            }

            var plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(xValues.ToArray(), correctValue.ToArray(), Color.CadetBlue,             0.01f, 1,  "Math.Pow2");
            plt.PlotScatter(xValues.ToArray(), approxValue2.ToArray(), Color.FromArgb(82, 178, 67), 0.01f, 1f, "fixmath.Pow2_2");
            plt.PlotScatter(xValues.ToArray(), approxValue2.ToArray(), Color.FromArgb(35, 25, 178), 0.01f, 1f, "fixmath.Pow2_2");
            plt.SaveFig("Exp.png");
            
            plt = new ScottPlot.Plot(2048, 2048);
            plt.PlotScatter(xValues.ToArray(), approxValueError2.ToArray(), Color.FromArgb(82, 178, 67), 0.01f, 1f, "fixmath.Pow2_2");
            plt.PlotScatter(xValues.ToArray(), approxValueError2.ToArray(), Color.FromArgb(35, 25, 178), 0.01f, 1f, "fixmath.Pow2_2");
            plt.SaveFig("Exp_error.png");
        }
    }
}