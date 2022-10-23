using AI1.Infrastructure;

namespace AI1.Model {
    internal class AirQuality : IDataType {
        // public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double CO_GT { get; set; }
        public double PT08_S1 { get; set; }
        public double NMHC_GT { get; set; }
        public double C6H6_GT { get; set; }
        public double PT08_S2 { get; set; }
        public double NOx_GT { get; set; }
        public double PT08_S3 { get; set; }
        public double NO2_GT { get; set; }
        public double PT08_S4 { get; set; }
        public double PT08_S5 { get; set; }
        public double T { get; set; }
        public double RH { get; set; }
        public double AH { get; set; }
    }
}
