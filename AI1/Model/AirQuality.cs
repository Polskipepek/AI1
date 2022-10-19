using AI1.Infrastructure;

namespace AI1.Model {
    internal class AirQuality : IDataType {
        // public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int CO_GT { get; set; }
        public int PT08_S1_CO { get; set; }
        public int NMHC_GT { get; set; }
        public int C6H6_GT { get; set; }
        public int PT08_S2_NMHC { get; set; }
        public int NOx_GT { get; set; }
        public int PT08_S3_NOx { get; set; }
        public int NO2_GT { get; set; }
        public int PT08_S4_NO2 { get; set; }
        public int PT08_S5_O3 { get; set; }
        public int T { get; set; }
        public int RH { get; set; }
        public int AH { get; set; }
    }
}
