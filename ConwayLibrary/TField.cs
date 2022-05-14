namespace ConwayLibrary;

public class TField
{
    public int Size { get; set; } = 500;
    public int Check(int value) => (value % Size + Size) % Size;
    public TCell[,] Cells = new TCell[,] { };

    public TCell this [int x,int y]
    {
        get { return Cells[Check(x), Check(y)]; }
        set { Cells[Check(x), Check(y)] = value; }
    }

    public void CreateCells()
    {
        Cells = new TCell[Size,Size];
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Cells[i, j] = new TCell() { X = i, Y = j, State = TCell.KindOfState.Dead };
            }
        }
    }
    public void RandomFill(int percent = 50)
    {
        Random r = new Random();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (r.Next(100)<percent)
                {
                    this[i,j].State = TCell.KindOfState.Live;
                }
                else this[i, j].State = TCell.KindOfState.Dead;
            }
        }
    }
    public void RandomFillSymmetry(int percent = 50)
    {
        Random r = new Random();
        for (int i = 0; i < Size/2; i++)
        {
            for (int j = 0; j < Size/2; j++)
            {
                TCell.KindOfState st = new TCell.KindOfState();
                if (r.Next(100) < percent)
                {
                    st = TCell.KindOfState.Live;
                }
                else st = TCell.KindOfState.Dead;

                this[i, j].State = st;
                this[i, -j].State = st;
                this[-i, j].State = st;
                this[-i, -j].State = st;
                this[j, i].State = st;
                this[-j, i].State = st;
                this[j, -i].State = st;
                this[-j, -i].State = st;
            }
        }
    }

    public int Near(int x, int y)
    {
        return (int)(this[x-1, y-1].State)+ (int)(this[x-1, y].State) + (int)(this[x-1, y+1].State) +
               (int)(this[x, y-1].State) + (int)(this[x, y].State) + (int)(this[x, y+1].State) +
               (int)(this[x+1, y-1].State) + (int)(this[x+1, y].State) + (int)(this[x+1, y+1].State)
               - (int)(this[x, y].State);
    }

    public void NextStep(TField prev)
    {
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                int n = prev.Near(x,y);

                if (prev[x,y].State == TCell.KindOfState.Dead)
                {
                    if (n==3)
                    {
                        this[x, y].State = TCell.KindOfState.Live;
                        continue;
                    }
                }
                if (prev[x, y].State == TCell.KindOfState.Live)
                {
                    if ((n < 2 )||(n>3))
                    {
                        this[x, y].State = TCell.KindOfState.Dead;
                        continue;
                    }
                }

                this[x, y].State = prev[x, y].State;
            }
        }
    }
}