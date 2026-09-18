using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Project3.Classes
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Select = false;
        public bool Black = false;
        public Grid Figure { get; set; }
        public Pawn(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;
        }
        public void SelectFigure(object? sender, PointerPressedEventArgs e)
        {
            bool attack = false;

            Pawn SelectPawn = MainWindow.mainWindow.Pawns.Find(x => x.Select == true);

            if (SelectPawn != null)
            {
                if (this.Black && this.Y - 1 == SelectPawn.Y && (this.X - 1 == SelectPawn.X || this.X == SelectPawn.X || this.X + 1 == SelectPawn.X))
                {
                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);
                    Grid.SetColumn(SelectPawn.Figure, this.X);
                    Grid.SetRow(SelectPawn.Figure, this.Y);
                    SelectPawn.X = this.X;
                    SelectPawn.Y = this.Y;
                    SelectPawn.SelectFigure(null, null);
                    attack = true;
                }
            }
            if (!attack)
            {
                MainWindow.mainWindow.OnSelect(this);
                if (this.Select)
                {
                    if (this.Black)
                        this.Figure.Background = new ImageBrush(new Bitmap("avares://Project3/Images/Pawn (black).png"));
                    else
                        this.Figure.Background = new ImageBrush(new Bitmap("avares://Project3/Images/Pawn.png"));
                    this.Select = false;
                }
                else
                {
                    this.Figure.Background = new ImageBrush(new Bitmap("avares://Project3/Images/Pawn (select).png"));
                    this.Select = true;
                }
            }
        }
        public void Transform(int X, int Y)
        {
            if (X != this.X)
            {
                SelectFigure(null, null);
                return;
            }
            if ((!Black && ((this.Y == 1 && this.Y + 2 == Y) || this.Y + 1 == Y)) || (Black && ((this.Y == 6 && this.Y - 2 == Y) || this.Y - 1 == Y)))
            {
                Grid.SetColumn(this.Figure, X);
                Grid.SetRow(this.Figure, Y);
                this.X = X;
                this.Y = Y;
            }
            SelectFigure(null, null);
        }
    }
}