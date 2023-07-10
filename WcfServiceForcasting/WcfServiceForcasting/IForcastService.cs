using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceForcasting.models;

namespace WcfServiceForcasting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IForcastService" in both code and config file together.
    [ServiceContract]
    public interface IForcastService
    {
        [OperationContract]
        WeatherForecast GetWeatherForecast(string city);
    }

   
}
