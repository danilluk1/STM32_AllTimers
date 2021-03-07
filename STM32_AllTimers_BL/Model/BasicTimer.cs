using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace STM32_AllTimers_BL.Model {
    public class BasicTimer : IBasicTimer {
        private int inputfreq;
        private int prescaler;
        private int counterperiod;
        private int ticksperseconds;
        /// <summary>
        /// Входная частота таймера в ГЦ.
        /// </summary>
        public int InputFrequency { 
            get => inputfreq; 
            set
            {
                if (value <= 0) throw new ArgumentException("Входная частота должна быть > 0"); 
                inputfreq = value;
                OnPropertyChanged("InputFrequency");
            }
        }

        /// <summary>
        /// Делитель частоты таймера.
        /// Задаётся по формуле: Необходимое значение - 1.
        /// </summary>
        public int Prescaler {
            get => prescaler;
            set {
                if (value <= 0) throw new ArgumentException("Делитель должен быть > 0");
                prescaler = value;
                OnPropertyChanged("Prescaler");
            }
        }

        /// <summary>
        /// Задаёт значение, до которого будет считать таймер.
        /// </summary>
        public int CounterPeriod {
            get => counterperiod;
            set {
                if (value <= 0) throw new ArgumentException("Counter Period должен быть > 0");
                counterperiod = value;
                OnPropertyChanged("CounterPeriod");
            }
        }
        /// <summary>
        /// Скорость работы таймера в тиках за секунду.
        /// Формула расчёта: InputFrequency / (Prescaler + 1)
        /// </summary>
        public int TicksPerSecond {
            get => ticksperseconds;
            set {
                ticksperseconds = value;
                OnPropertyChanged("TicksPerSeconds");
            }
        }      

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        ///<summary>
        ///<retval>
        ///Период для заданной конфигурации таймера в мс
        ///</retval>
        ///</summary>
        public float CalculatePeriodMs() {
            TicksPerSecond = InputFrequency / (Prescaler + 1);
            float periodinms = SecondsConverter.ConvertSecondsToMs((float)CounterPeriod / TicksPerSecond);
            return periodinms;
        }
    }
}
