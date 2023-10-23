class MyMatrix
{
    private double[,] matrix;
    private int M; // строка m
    private int N;

    // конструктор, заполняющий матрицу случайными числами
    public MyMatrix(int rows, int cols, int min, int max)
    {
        this.M = rows;
        this.N = cols;
        matrix = new double[rows, cols];
        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(min, max);
            }
        }
    }

    public double this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    // Оператор сложения
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        // Проверка матриц на одинаковую размерность
        if (a.M != b.M || a.N != b.N)
            throw new ArgumentException("Matrices must have the same dimensions");

        MyMatrix result = new MyMatrix(a.M, a.N, 0, 0);

        for (int i = 0; i < a.M; i++)
        {
            for (int j = 0; j < a.N; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }

        return result;
    }

    // Оператор вычитания
    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        // Проверка матриц на одинаковую размерность
        if (a.M != b.M || a.N != b.N)
            throw new ArgumentException("Matrices must have the same dimensions");

        MyMatrix result = new MyMatrix(a.M, a.N, 0, 0);

        for (int i = 0; i < a.M; i++)
        {
            for (int j = 0; j < a.N; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }

        return result;
    }

    // Оператор умножения
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.N != b.M)
            throw new ArgumentException("Number of columns in first matrix must match number of rows in second matrix");

        MyMatrix result = new MyMatrix(a.M, b.N, 0, 0);

        for (int i = 0; i < a.M; i++) // по строкам из первой
        {
            for (int j = 0; j < b.N; j++) // по столбцам из второй
            {
                for (int k = 0; k < a.N; k++) // в выбранных строках и столбцах попарно умножаем элементы и складываем
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    // Оператор умножение на скаляр
    public static MyMatrix operator *(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.M, a.N, 0, 0);

        for (int i = 0; i < a.M; i++)
        {
            for (int j = 0; j < a.N; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }

        return result;
    }

    // Оператор деление на скаляр
    public static MyMatrix operator /(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.M, a.N, 0, 0);

        for (int i = 0; i < a.M; i++)
        {
            for (int j = 0; j < a.N; j++)
            {
                result[i, j] = a[i, j] / scalar;
            }
        }

        return result;
    }

    public void Print()
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                // Console.Write(matrix[i, j] + " ");
                double h = matrix[i, j];
                if (h - Math.Round(h, 1) == 0)
                    Console.Write(matrix[i, j] + " ");
                else
                    Console.Write(Math.Round(h, 1) + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program1
{
    static void Main(string[] args)
    {
        int rows = 3;
        int cols = 3;
        int min = 1;
        int max = 10;

        MyMatrix a = new MyMatrix(rows, cols, min, max);
        MyMatrix b = new MyMatrix(rows, cols, min, max);

        Console.WriteLine("Matrix A:");
        a.Print();
        Console.WriteLine();

        Console.WriteLine("Matrix B:");
        b.Print();
        Console.WriteLine();

        Console.WriteLine("A + B:");
        (a + b).Print();
        Console.WriteLine();

        Console.WriteLine("A - B:");
        (a - b).Print();
        Console.WriteLine();

        Console.WriteLine("A * B:");
        (a * b).Print();
        Console.WriteLine();

        Console.WriteLine("A * 2:");
        (a * 2).Print();
        Console.WriteLine();

        Console.WriteLine("A / 2:");
        (a / 3).Print();
        Console.WriteLine();
    }
}