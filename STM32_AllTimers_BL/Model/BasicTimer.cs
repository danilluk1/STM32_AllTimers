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

        public string Error => throw new NotImplementedException();

        public string this[string columnName] {
            get {
                string error = String.Empty;
                switch (columnName) {
                    case "InputFrequency":
                    error = InputFrequency <= 0 ?
                        "Входная частота должна быть больше 0 и меньше 100" : String.Empty;
                    break;

                    case "Prescaler":
                    error = (Prescaler <= 0 || Prescaler >= 65535) ? 
                        "Делитель должен находиться в пределах от 0 до 65535" : String.Empty;
                    break;

                    case "CounterPeriod":
                    error = (CounterPeriod <= 0 || CounterPeriod >= 65535) ?
                        "Период счётчика должен находиться в пределах от 0 до 65535" : String.Empty;
                    break;
                }
                return error;
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
