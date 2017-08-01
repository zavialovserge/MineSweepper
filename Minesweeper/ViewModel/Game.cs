using GalaSoft.MvvmLight;
using Minesweeper.Properties;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Minesweeper.ViewModel
{
    public class Game:ViewModelBase
    {
        public ObservableCollection<Cell> cells { get; set; }
        private int bombCounter;

        public int BombCounter
        {
            get { return bombCounter; }
            set {
                bombCounter = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel viewModel { get; set; }
        public Game(MainViewModel ViewModel)
        {
            this.viewModel = ViewModel;
            cells = new ObservableCollection<Cell>();
            //TODO MAKE IT GLOBAL
            double globalCount = Math.Pow(Settings.Default.Number_of_cells,2);
            for (int i = 0; i < globalCount; i++)
            {
                cells.Add(new Cell(this));
            }
            AddBomb();
            CountOfNearBombs();
            bombCounter= cells.Where(x => x.IsBomb).Count();
        }

        private void CountOfNearBombs()
        {
            int lenght = (int)Math.Sqrt(cells.Count) + 2;
            Cell[,] tempArray = new Cell[lenght, lenght];
            int temp = 0;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (i==0 || j ==0|| j== lenght-1|| i == lenght-1)
                    {
                        tempArray[i, j] = new Cell(this);
                    }
                    else
                    {
                        tempArray[i, j] = cells[temp];
                        temp++;
                    }
                }
            }
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (tempArray[i,j].IsBomb)
                    {
                        tempArray[i-1, j-1].bombCounter++;
                        tempArray[i - 1, j].bombCounter++;
                        tempArray[i - 1, j+1].bombCounter++;
                        tempArray[i, j-1].bombCounter++;
                        tempArray[i, j +1].bombCounter++;
                        tempArray[i+1, j - 1].bombCounter++;
                        tempArray[i+1, j].bombCounter++;
                        tempArray[i+1, j +1].bombCounter++;
                    }
                }
            }
            cells.Clear();
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (i != 0 && j != 0 && j != lenght-1 && i != lenght-1)
                    {
                        cells.Add(tempArray[i, j]);

                    }
                    
                }
            }

        }

        private void AddBomb()
        {
            //TODO GLOBAL variable defined by difficult
            double ver = 0.3;
            int countOfBombs = (int)(ver * cells.Count);
            int index = 0;
            Random rand = new Random();
            for (int i = 0; i < countOfBombs; i++)
            {
                do
                {
                    index = rand.Next(0, cells.Count);
                } while (cells[index].IsBomb);
                cells[index].IsBomb = true;
            }
            

        }
       
    }
}
