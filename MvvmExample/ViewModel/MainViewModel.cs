using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MvvmExample.Model;
using Prism.Commands;
using Prism.Mvvm;

namespace MvvmExample.ViewModel
{
    public class MainViewModel : BindableBase
    {
        readonly Data _data = new Data();

        public MainViewModel()
        {
            _data.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };

            AddCommand = new DelegateCommand<string> (str => {
                int ival;
                if (int.TryParse(str, out ival)) _data.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i =>
           {
               if (i.HasValue) _data.RemoveValue(i.Value);
           });
        }

        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public int Sum => _data.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _data.MyPublicValues;
    }
}
