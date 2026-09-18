using System.Collections.Generic;
using Avalonia.Controls;
using Project3.Classes;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Project3;

public partial class MainWindow : Window
{
    public static MainWindow mainWindow;
    public List<Classes.Pawn> Pawns = new List<Classes.Pawn>();

    public MainWindow()
    {
        InitializeComponent();
        MainWindow.mainWindow = this;
        Pawns.Add(new Classes.Pawn(0, 1, false));
        Pawns.Add(new Classes.Pawn(1, 1, false));
        Pawns.Add(new Classes.Pawn(2, 1, false));
        Pawns.Add(new Classes.Pawn(3, 1, false));
        Pawns.Add(new Classes.Pawn(4, 1, false));
        Pawns.Add(new Classes.Pawn(5, 1, false));
        Pawns.Add(new Classes.Pawn(6, 1, false));
        Pawns.Add(new Classes.Pawn(7, 1, false));

        Pawns.Add(new Classes.Pawn(0, 6, true));
        Pawns.Add(new Classes.Pawn(1, 6, true));
        Pawns.Add(new Classes.Pawn(2, 6, true));
        Pawns.Add(new Classes.Pawn(3, 6, true));
        Pawns.Add(new Classes.Pawn(4, 6, true));
        Pawns.Add(new Classes.Pawn(5, 6, true));
        Pawns.Add(new Classes.Pawn(6, 6, true));
        Pawns.Add(new Classes.Pawn(7, 6, true));
        CreateFigure();
    }
    public void CreateFigure()
    {
        foreach (Classes.Pawn Pawn in Pawns)
        {
            Pawn.Figure = new Grid()
            {
                Width = 50,
                Height = 50
            };
            if (Pawn.Black)
                Pawn.Figure.Background = new ImageBrush(new Bitmap(AssetLoader.Open(new System.Uri("avares://Project3/Images/Pawn (black).png"))));
            else
                Pawn.Figure.Background = new ImageBrush(new Bitmap(AssetLoader.Open(new System.Uri("avares://Project3/Images/Pawn.png"))));
            Grid.SetColumn(Pawn.Figure, Pawn.X);
            Grid.SetRow(Pawn.Figure, Pawn.Y);
            Pawn.Figure.PointerPressed += Pawn.SelectFigure;
            gameBoard.Children.Add(Pawn.Figure);
        }
    }
    public void OnSelect(Classes.Pawn SelectPawn)
    {
        foreach (Classes.Pawn Pawn in Pawns)
        {
            if (Pawn != SelectPawn)
            {
                if (Pawn.Select)
                {
                    Pawn.SelectFigure(null, null);
                }
            }
        }
    }
    private void SelectTile(object sender, PointerPressedEventArgs e)
    {
        Grid Tile = sender as Grid;

        if (Tile == null) return;

        int X = Grid.GetColumn(Tile);
        int Y = Grid.GetRow(Tile);

        Classes.Pawn SelectPawn = Pawns.Find(x => x.Select == true);

        if (SelectPawn != null)
        {
            SelectPawn.Transform(X, Y);
        }
    }
}