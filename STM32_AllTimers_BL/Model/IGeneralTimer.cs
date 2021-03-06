using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_BL.Model {
    interface IGeneralTimer : ISTMTimer {
        float CalculatePeriodMs();
        int CalculatePWM();
    }
}
