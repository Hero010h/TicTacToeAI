namespace TicTacToe;

internal class Map
{
    private Symbol[,] _field;
    public Symbol[,] Field { get => _field; }

    public Map()
    {
        Symbol T = Symbol.None;
        _field = new Symbol[3, 3]
        {
        { T, T, T},
        { T, T, T},
        { T, T, T}
        };
    }

    //����� ��������� �������. �� ��� ��������� ������ �� �� �� �����, �� �� �������� �������� �������
    //�� ������� ���� ������, ����� �� ����� ���� �������
    public void SetSymbol(int Y, int X, Symbol sym)
    {
        if (sym != Symbol.None &&
            Y < 3 && Y >= 0 && 
            X < 3 && X >= 0)
        {
            if (_field[Y, X] == Symbol.None)
            {
                _field[Y, X] = sym;
            }
            else
            {
                Console.WriteLine($"�� ����� ������� ������ ����� ����?! �� ������, � �� ���� � ����� ������...");
            }
        }
        else
        {
            Console.WriteLine("׸� �����-�� ����� ����������. ������� ������� ������ � void SetSumbol(..) � class Map");
        }
    }

    //��������� ��� ��������� ���������� ������ � ������� ������ ����������. ���� ����� �� �������, ������� ������ ������
    public Symbol CheckWiners()
    {
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            if (_field[y, 0] == _field[y, 1] && _field[y, 0] == _field[y, 2])
            {
                return _field[y, 0];
            }
        }
        for (int x = 0; x < _field.GetLength(0); x++)
        {
            if (_field[0, x] == _field[1, x] && _field[0, x] == _field[2, x])
            {
                return _field[0, x];
            }
        }
        if (_field[0, 0] == _field[1, 1] && _field[0, 0] == _field[2, 2] ||
            _field[0, 2] == _field[1, 1] && _field[0, 2] == _field[2, 0])
        {
            return _field[1, 1];
        }
        return Symbol.None;
    }

    //���������� �� ���� �� �������� Symbol.None
    public void ResetField()
    {
        Symbol T = Symbol.None;
        _field = new Symbol[3, 3]
        {
        { T, T, T},
        { T, T, T},
        { T, T, T}
        };
    }
}

//�������� ������ � ����� ������� - ������, �������, �����, �����������(������� ��� �����)
public enum Symbol
{
    None,
    Zero,
    Cross
}