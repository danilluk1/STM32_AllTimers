using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace STM32_AllTimers_BL.Model {
    public sealed class GeneralTimer : IGeneralTimer {

        private bool is32bits;
        private PWMMode mode;
        private int pulse;
        private bool isFastMode;
        private CHPolarity polarity;
        private CounterMode counterMode;

        private int inputfreq;
        private int prescaler;
        private int counterperiod;
        private int ticksperseconds;
        private int completion;
        /// <summary>
        /// Входная частота таймера в ГЦ.
        /// </summary>
        public int InputFrequency {
            get => inputfreq;
            set {
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
        public string this[string columnName] {
            get {
                string error = String.Empty;
                return error;
            }
        }

        public bool Is32Bits {
            get => is32bits;
            set {
                is32bits = value;
                OnPropertyChanged("Is32Bits");
            }
        }

        public PWMMode Mode {
            get => mode;
            set {
                mode = value;
                OnPropertyChanged("Mode");
            }
        }

        public int Pulse {
            get => pulse;
            set {
                pulse = value;
                OnPropertyChanged("Pulse");
            }
        }

        public bool IsFastMode {
            get => isFastMode;
            set {
                isFastMode = value;
                OnPropertyChanged("IsFastMode");
            }
        }

        public CHPolarity Polarity {
            get =>polarity;
            set {
                polarity = value;
                OnPropertyChanged("Polarity");
            }
        }

        public CounterMode CounterMode {
            get => counterMode;
            set {
                counterMode = value;
                OnPropertyChanged("CounterMode");
            }
        }

        public string Error => throw new NotImplementedException();

        public int Completion {
            get => completion;
            set {
                completion = value;
                OnPropertyChanged("Completion");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public float CalculatePeriodMs() {
            TicksPerSecond = InputFrequency / (Prescaler + 1);
            float periodinms = SecondsConverter.ConvertSecondsToMs((float)CounterPeriod / TicksPerSecond);
            return periodinms;
        }

        public void CalculatePWM() {
            int completion;
            if (Mode == PWMMode.Mode_1) {
                completion = CounterPeriod / Pulse;
            }
            else {
                completion = 100 - CounterPeriod / Pulse;
            }
            Completion = completion;
        }
    }
}
