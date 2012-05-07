using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFApp.Infrastructure
{
    class RelayCommand<T> : ICommand
    {
        #region Members

        private readonly Func<Boolean> _canExecute;
        private readonly Action<T> _execute;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute) : this(execute, null)
        {

        }

        public RelayCommand(Action<T> execute, Func<Boolean> canExecute)
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
            _execute((T)parameter);
        }
    }
}
