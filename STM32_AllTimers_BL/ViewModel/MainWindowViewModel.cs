using STM32_AllTimers_BL.Commands;
using STM32_AllTimers_BL.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace STM32_AllTimers_BL.ViewModel {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private IBasicTimer basicTimer;
        private IGeneralTimer generalTimer;

        public IBasicTimer BasicTimer {
            get => basicTimer; 
            set {
                basicTimer = value;
                OnPropertyChanged("BasicTimer");
            }
        }

        public IGeneralTimer GeneralTimer {
            get => generalTimer;
            set {
                generalTimer = value;
                OnPropertyChanged("GeneralTimer");
            }
        }

        #region Commands
        private RelayCommand gtModeChangeCommand;
        private RelayCommand gtBitsChangeCommand;
        private RelayCommand gtFastModeChangeCommand;
        private RelayCommand gtPolarityChangeCommand;
        private RelayCommand gtCalculatePWMCommand;
        public RelayCommand GtModeChangeCommand {
            get {
                return gtModeChangeCommand ??
                    (gtModeChangeCommand = new RelayCommand(o => {
                        var mode = o as string;
                        GeneralTimer.Mode = mode.Equals("Mode 1")
                            ? PWMMode.Mode_1 : PWMMode.Mode_2;

                    }));
            }
        }

        public RelayCommand GtBitsChangeCommand {
            get {
                return gtBitsChangeCommand ??
                    (gtBitsChangeCommand = new RelayCommand(o => {
                        GeneralTimer.Is32Bits = (bool)o;
                    }));
            }
        }

        public RelayCommand GtFastModeChangeCommand {
            get {
                return gtFastModeChangeCommand ??
                    (gtFastModeChangeCommand = new RelayCommand(o => {
                        var fm = o as string;
                        GeneralTimer.IsFastMode = fm.Equals("Enabled") ? true : false;
                    }));
            }
        }
        public RelayCommand GtPolarityChangeCommand {
            get {
                return gtPolarityChangeCommand ??
                    (gtPolarityChangeCommand = new RelayCommand(o => {
                        var fm = o as string;
                        GeneralTimer.Polarity = fm.Equals("High") ? CHPolarity.High : CHPolarity.Low;
                    }));
            }
        }

        public RelayCommand GtCalculatePWMCommand {
            get {
                return gtCalculatePWMCommand ??
                    (gtCalculatePWMCommand = new RelayCommand(o => {
                        GeneralTimer.CalculatePWM();
                    }));
            }
        }
        #endregion Commands

        public MainWindowViewModel() {
            basicTimer = new BasicTimer();
            generalTimer = new GeneralTimer();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
