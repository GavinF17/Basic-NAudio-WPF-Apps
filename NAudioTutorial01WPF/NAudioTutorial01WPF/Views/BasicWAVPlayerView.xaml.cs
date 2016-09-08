using NAudioTutorial01WPF.ViewModels;

namespace NAudioTutorial01WPF.Views
{
    public partial class BasicWAVPlayerView
    {
        public BasicWAVPlayerView()
        {
            InitializeComponent();
            DataContext = new BasicWAVPlayerViewModel();
        }
    }
}