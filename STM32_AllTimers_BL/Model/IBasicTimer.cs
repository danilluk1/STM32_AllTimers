using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_BL.Model {
    public interface IBasicTimer : ISTMTimer {
        float CalculatePeriodMs();
    }
}
