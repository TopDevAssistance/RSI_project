using System.Drawing;
using TradingPlatform.BusinessLayer;

namespace rsi_indicator
{
    public class CustomRsiIndicator : Indicator
    {
        [InputParameter("RSI Period", 0, 1, 100, 1, 0)]
        public int rsiPeriod = 14;

        [InputParameter("EMA Period", 1, 1, 100, 1, 0)]
        public int emaPeriod = 39;

        [InputParameter("SMA Period", 2, 1, 100, 1, 0)]
        public int smaPeriod = 9;

        private Indicator rsiIndicator;
        private Indicator emaIndicator;
        private Indicator smaIndicator;

        public CustomRsiIndicator()
        {
            Name = "Custom RSI with EMA39 and SMA9";
            Description = "RSI with EMA39 and SMA9, colorized RSI levels";

            AddLineSeries("RSI", Color.Cyan, 1, LineStyle.Solid);
            AddLineSeries("EMA39", Color.Red, 1, LineStyle.Dash);
            AddLineSeries("SMA9", Color.Green, 1, LineStyle.Dot);
        }

        protected override void OnInit()
        {
            // Initialize sub-indicators for RSI, EMA, and SMA
            rsiIndicator = Core.Indicators.BuiltIn.RSI(rsiPeriod, PriceType.Close, RSIMode.Exponential, MaMode.SMA, 1); // Adjust parameters as per your need
            AddIndicator(rsiIndicator);

            emaIndicator = Core.Indicators.BuiltIn.EMA(emaPeriod, PriceType.Close);
            AddIndicator(emaIndicator);

            smaIndicator = Core.Indicators.BuiltIn.SMA(smaPeriod, PriceType.Close);
            AddIndicator(smaIndicator);
        }

        protected override void OnUpdate(UpdateArgs args)
        {
            // Ensure enough data is available
            if (Count < rsiPeriod || Count < emaPeriod || Count < smaPeriod)
                return;

            // Get the RSI value
            double rsiValue = rsiIndicator.GetValue(0);

            // Calculate EMA and SMA based on RSI values
            // Directly using the calculated value instead of AddValue
            double emaValue = emaIndicator.GetValue(0);
            double smaValue = smaIndicator.GetValue(0);

            // Set values for display
            SetValue(rsiValue, 0);
            SetValue(emaValue, 1);
            SetValue(smaValue, 2);
        }

        public override void OnPaintChart(PaintChartEventArgs args)
        {
            for (int i = 0; i < Count; i++)
            {
                double rsiValue = GetValue(0, i);

                Color color;
                if (rsiValue >= 85)
                    color = Color.Blue;
                else if (rsiValue >= 67)
                    color = Color.Blue;
                else if (rsiValue >= 63)
                    color = Color.White;
                else if (rsiValue >= 50)
                    color = Color.Gray;
                else if (rsiValue >= 38)
                    color = Color.Blue;
                else if (rsiValue >= 34)
                    color = Color.White;
                else
                    color = Color.Gray;

                args.Graphics.DrawLine(new Pen(color), i, 0, i, (float)rsiValue);
            }
        }
    }
}
