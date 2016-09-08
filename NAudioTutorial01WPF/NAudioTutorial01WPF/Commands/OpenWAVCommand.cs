using System;
using System.Windows.Input;
using NAudioTutorial01WPF.ViewModels;

namespace NAudioTutorial01WPF.Commands
{
    internal class OpenWAVCommand : ICommand
    {
        private readonly BasicWAVPlayerViewModel _viewModel;

        public OpenWAVCommand(BasicWAVPlayerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.OpenWAV();
        }
    }
}
