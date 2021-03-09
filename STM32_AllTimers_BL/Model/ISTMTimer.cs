using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_BL.Model {
    public interface ISTMTimer : INotifyPropertyChanged, IDataErrorInfo {
        int InputFrequency { get; set; }
        int Prescaler { get; set; }
        int CounterPeriod { get; set; }
        int TicksPerSecond { get; set; }
       
    }
}
