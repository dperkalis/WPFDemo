using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFApp.Infrastructure
{
    class RelayCommand : ICommand
    {
        #region Members

        private readonly Func<Boolean> _canExecute;
        private readonly Action _execute;

        #endregion

        #region Constructors

        public RelayCommand(Action execute) : this(execute, null)
        {

        }

        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
