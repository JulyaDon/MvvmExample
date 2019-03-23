using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample.Model
{
    public class Data : BindableBase
    {
        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> MyPublicValues;

        public Data()
        {
            MyPublicValues = new ReadOnlyObservableCollection<int>(_myValues);
        }

        public void AddValue(int value)
        {
            _myValues.Add(value);
            RaisePropertyChanged("Sum");
        }

        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _myValues.Count)
            {
                _myValues.RemoveAt(index);
                RaisePropertyChanged("Sum");
            }
        }

        public int Sum => MyPublicValues.Sum();
    }
}
