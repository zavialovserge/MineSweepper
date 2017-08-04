using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper.ViewModel
{
    public class Cell: ViewModelBase
    {
        private string _imageUri;

        public string imageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                RaisePropertyChanged();
            }
        }
        private bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private bool isBomb;

        public bool IsBomb
        {
            get { return isBomb; }
            set { isBomb = value; }
        }
        public int bombCounter { get; set; }
        private bool isEnable;

        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                RaisePropertyChanged();
            }
        }
        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                RaisePropertyChanged();
            }
        }
        ////TODO RENAME PATH
        //private const string defaultImageUri = ;

        private Game Game { get; set; }
        public Cell(Game game)
        {
            this.Game = game;
            IsEnable = true;
            this.imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\space.png";
            leftClick = new RelayCommand(ChangeUri,()=>!flag);
            rightClick = new RelayCommand(ChangeFlagUri);
            bombCounter = 0;
        }

        private void ChangeFlagUri()
        {

            flag = flag ? false : true;
            if (!isOpen)
            {
                this.imageUri = flag ? @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\flag.png"
                                 : @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\space.png";
            }
            
            if (flag && Game.BombCounter!=0 && !IsOpen)
            {
                Game.BombCounter--;
            }

            else if(!IsOpen)
            {
                Game.BombCounter++;
            }
            
        }

        private void ChangeUri()
        {
            if (Game.Timer == null)
            {
                Game.Timer = new Timer() { Interval = 1000 };
                DateTime dateTime = new DateTime();
                Game.Timer.Elapsed += (sender, args) =>
                {
                    dateTime = dateTime.AddSeconds(1);
                    Game.time = $"{dateTime.Hour.ToString("D2")}:{dateTime.Minute.ToString("D2")}:{dateTime.Second.ToString("D2")}";
                    RaisePropertyChanged("time");
                };
                Game.Timer.Start();
            }
            
            if (isBomb)
            {
                imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\explosion.png";
                foreach (var cell in Game.cells)
                {
                    cell.IsEnable = false;//stopGame
                    Game.Timer?.Stop();
                    if (cell.Flag && !cell.isBomb && cell != this)
                    {
                        cell.imageUri =  @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\broken_flag.png";
                    }
                }
            }
            else
            {
                //Проверка на выигрыш
                bool isWin =true;
                foreach (var cell in Game.cells)
                {
                    if ((!cell.Flag && cell.isBomb) && (cell.Flag && !cell.isBomb))
                    {
                        isWin=false;
                    }
                    
                }
                if (Game.BombCounter == 0 && isWin)
                {
                    MessageBox.Show("Поздравляю Вы выиграли!!! Ваше время" + Game.time);
                    Game.viewModel.StartNewGame();
                    return;
                }
                IsOpen = true;

                //TODO WIN
                switch (bombCounter)
                {
                    case 0:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\"+0+".png";
                        OpenNearCells();
                        break;
                    case 1:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\"+1+".png";
                        break;
                    case 2:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\"+2+".png";                    
                        break;
                    case 3:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 3 + ".png";
                        break;
                    case 4:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 4 + ".png";
                        break;
                    case 5:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 5 + ".png";
                        break;
                    case 6:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 6 + ".png";
                        break;
                    case 7:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 7 + ".png";
                        break;
                    case 8:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\" + 8 + ".png";
                        break;
                }
            }
           
            
        }

        private void OpenNearCells()
        {
           
            int lenght = (int)Math.Sqrt(Game.cells.Count) + 2;
            Cell[,] tempArray = new Cell[lenght, lenght];
            int temp = 0;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (i == 0 || j == 0 || j == lenght - 1 || i == lenght - 1)
                    {
                        tempArray[i, j] = new Cell(Game);
                    }
                    else
                    {
                        tempArray[i, j] = Game.cells[temp];
                        temp++;
                    }
                }
            }
            Game.cells.Clear();
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (i != 0 && j != 0 && j != lenght - 1 && i != lenght - 1)
                    {
                        Game.cells.Add(tempArray[i, j]);

                    }

                }
            }
        }

        public ICommand LeftClick => leftClick;
        private RelayCommand leftClick;
        public ICommand RightClick => rightClick;
        private RelayCommand rightClick;
    }
}
