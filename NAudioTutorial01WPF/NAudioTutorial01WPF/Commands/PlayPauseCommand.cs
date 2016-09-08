using System;
using System.Windows.Input;
using NAudioTutorial01WPF.ViewModels;

namespace NAudioTutorial01WPF.Commands
{
    internal class PlayPauseCommand : ICommand
    {
        private readonly BasicWAVPlayerViewModel _viewModel;

        public PlayPauseCommand(BasicWAVPlayerViewModel viewModel)
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
            return _viewModel.PlayPauseEnabled;
        }

        public void Execute(object parameter)
        {
            _viewModel.PlayPause();
        }
    }
}
