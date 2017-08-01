using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Minesweeper.Properties;
using System;
using System.Windows.Input;

namespace Minesweeper.ViewModel
{
    public class SettingsViewModel:ViewModelBase
    {
        public const int defaultCountOfCells = 6;
        public const Difficult difficultDefault = Difficult.Medium;
        private int countOfCells;

        public int CountOfCells
        {
            get { return countOfCells; }
            set
            {
                countOfCells = value;
                RaisePropertyChanged();
            }
        }
        private Difficult difficult;

        public Difficult Difficult
        {
            get { return difficult; }
            set
            {
                difficult = value;
                RaisePropertyChanged();
            }
        }
        public SettingsViewModel()
        {
            CountOfCells = Settings.Default.Number_of_cells;
            string temp = Settings.Default.Difficult;
            var values = Enum.GetValues(typeof(Difficult));
            foreach (var value in values)
            {
                if (value.ToString() == temp)
                {
                    Difficult = (Difficult)value;
                }
            }
            changeSettings = new RelayCommand(NewSetting);
            resetSettings = new RelayCommand(Reset);
        }

        private void Reset()
        {
            Settings.Default.Number_of_cells = defaultCountOfCells; 
            Settings.Default.Difficult = difficultDefault.ToString();
            Settings.Default.Save();
        }
        private void NewSetting()
        {
            Settings.Default.Number_of_cells = countOfCells;
            Settings.Default.Difficult = difficult.ToString();
            Settings.Default.Save();
        }

        public ICommand ChangeSettings => changeSettings;
        private RelayCommand changeSettings;

        public ICommand ResetSettings => resetSettings;
        private RelayCommand resetSettings;
    }
    public enum Difficult
    {
        Easy,
        Medium,
        Hard
    }
}
