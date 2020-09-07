using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridApp
{
    public class MainWindowViewModel
    {
        public ObservableCollection<DataGridViewModel> ItemList { get; }

        public MainWindowViewModel()
        {
            ItemList = new ObservableCollection<DataGridViewModel>()
            {
                new DataGridViewModel()
                {
                    Name = "Text1"
                },
                new DataGridViewModel()
                {
                    Name = "Text2",
                    ChangeColor = true
                },
                new DataGridViewModel()
                {
                    Name = "Text3"
                }
            };
        }
    }

    public class DataGridViewModel : INotifyPropertyChanged
    {
        private string _Name = "text1";
        private bool _ChangeColor = false;

        public string Name 
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public bool ChangeColor
        {
            get => _ChangeColor;
            set
            {
                _ChangeColor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
