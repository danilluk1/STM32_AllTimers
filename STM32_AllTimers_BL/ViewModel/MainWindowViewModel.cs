using STM32_AllTimers_BL.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace STM32_AllTimers_BL.ViewModel {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private BasicTimer basicTimer;

        public BasicTimer BasicTimer {
            get => basicTimer; 
            set {
                basicTimer = value;
                OnPropertyChanged("BasicTimer");
            }
        }

        public MainWindowViewModel() {
            basicTimer = new BasicTimer();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
