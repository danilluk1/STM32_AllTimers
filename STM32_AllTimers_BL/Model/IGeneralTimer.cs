using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_BL.Model {
    public interface IGeneralTimer : ISTMTimer {
        float CalculatePeriodMs();
        void CalculatePWM();

        bool Is32Bits { get; set; }

        PWMMode Mode { get; set; }

        int Pulse { get; set; }

        bool IsFastMode { get; set; }

        int Completion { get; set; }

        CHPolarity Polarity { get; set; }

        CounterMode CounterMode { get; set; }


    }
}
