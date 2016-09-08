using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudioTutorial01WPF.Commands;

using System.IO;
using System.Windows;

using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace NAudioTutorial01WPF.ViewModels
{
    public class BasicWAVPlayerViewModel : INotifyPropertyChanged
    {
        // Used to initialise a new instance of the BasicWAVPlayerViewModel
        public BasicWAVPlayerViewModel()
        {
            OpenWAVCommand = new OpenWAVCommand(this);
            PlayPauseCommand = new PlayPauseCommand(this);
        }

        private NAudio.Wave.WaveFileReader wave = null;

        private NAudio.Wave.DirectSoundOut output = null;

        public bool PlayPauseEnabled = false;

        public void OpenWAV()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(open.FileName);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();

            PlayPauseEnabled = true;
        }

        public void PlayPause()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
            }
        }

        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (wave != null)
            {
                wave.Dispose();
                wave = null;
            }
        }

        #region Interface Commands

        public ICommand OpenWAVCommand { get; private set; }
        public ICommand PlayPauseCommand { get; private set; }

        #endregion // Interface Commands

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}
