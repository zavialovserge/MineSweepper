using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        ////TODO RENAME PATH
        //private const string defaultImageUri = ;

        private Game Game { get; set; }
        public Cell(Game game)
        {
            this.Game = game;
            Random rand = new Random();
            IsEnable = true;
            this.imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\space.png";
            leftClick = new RelayCommand(ChangeUri,()=>!flag);
            rightClick = new RelayCommand(ChangeFlagUri);
            bombCounter = 0;
        }

        private void ChangeFlagUri()
        {
            flag = flag ? false : true;
            this.imageUri = flag ? @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\flag.png"
                                 : @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\space.png";
            if (flag)
            {
                Game.BombCounter--;
            }

            else
            {
                Game.BombCounter++;
            }
            
        }

        private void ChangeUri()
        {
            if (isBomb)
            {
                imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\explosion.png";
                foreach (var cell in Game.cells)
                {
                    cell.IsEnable = false;//stopGame
                }
            }
            else
            {
                switch (bombCounter)
                {
                    case 0:
                        imageUri = @"C:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\"+0+".png";
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

        public ICommand LeftClick => leftClick;
        private RelayCommand leftClick;
        public ICommand RightClick => rightClick;
        private RelayCommand rightClick;
    }
}
