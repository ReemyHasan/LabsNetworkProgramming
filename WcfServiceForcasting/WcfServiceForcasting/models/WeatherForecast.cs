using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WcfServiceForcasting.models
{
    [DataContract]
    public class WeatherForecast
    {
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Temperature { get; set; }

        [DataMember]
        public double WindSpeed { get; set; }

        [DataMember]
        public double WindDegree { get; set; }
    }
}