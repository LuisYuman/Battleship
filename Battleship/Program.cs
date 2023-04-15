//Luis Angel Yuman Rodas, 0905-22-6550, Seccion "B"

int[,] tablero = new int[5, 5];

void paso1_crear_tablero()
{
    for(int f=0; f<tablero.GetLength(0); f++)
    {
        for(int c=0; c<tablero.GetLength(1); c++)
        {
            tablero[f,c] = 0;
        }
    }
}

void paso2_colocar_barcos()
{
    tablero[4, 3] = 1;
    tablero[1, 1] = 1;
    tablero[2, 1] = 1;
    tablero[3, 4] = 1;
}

void paso3_imprimir_tablero()
{
    String caracter_imprimir="";
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch(tablero[f,c])
            {
                case 0:
                    caracter_imprimir = "~";
                    break;

                case 1:
                    caracter_imprimir = "-";
                    break;

                case -1:
                    caracter_imprimir = "*";
                    break;

                case -2:
                    caracter_imprimir = "X";
                    break;

                default:
                    caracter_imprimir = "~";
                    break;
            }
            Console.Write(caracter_imprimir + "");
        }
        Console.WriteLine();
    }
}

void paso4_ingreso_coordenadas()
{
    int filas, columna = 0;
    Console.Clear();
    do
    {
        Console.Write("Ingresa la fila: ");
        filas = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingresa la columna: ");
        columna = Convert.ToInt32(Console.ReadLine());

        if (tablero[filas,columna]==1)
        {
            Console.Beep();
            tablero[filas,columna] = -1;
        }
        else
        {
            tablero[filas,columna] = -2;
        }
        Console.Clear();
        paso3_imprimir_tablero();
    }while(true);
}

paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_coordenadas();