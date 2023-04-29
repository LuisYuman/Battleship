//Luis Angel Yuman Rodas, 0905-22-6550, Seccion "B"


using System.Runtime.InteropServices;
using System.Threading;

int barcos, dm;

Console.WriteLine(" *******************************************");
Console.WriteLine(" *******************************************");
Console.WriteLine(" ********** B A T T L E S H I P ************");
Console.WriteLine(" *******************************************");
Console.WriteLine(" *******************************************");
Console.WriteLine("");
Console.WriteLine("Ingrese las dimensiones del tablero a utilizar:");
dm = int.Parse(Console.ReadLine());

int[,] tablero = new int[dm, dm];

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
    Random bar = new Random();
    Console.WriteLine("¿Cuantos barcos desea colocar?");
    barcos = int.Parse(Console.ReadLine());

    for(int b = 0; b < barcos; b++) 
    {
        tablero[bar.Next(0 , dm), bar.Next(0, dm)] = 1;
    }

    //tablero[4, 3] = 1;
    //tablero[1, 1] = 1;
    //tablero[2, 1] = 1;
    //tablero[3, 4] = 1;
}

void paso3_imprimir_tablero()
{
    String caracter_imprimir="";
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            
            Console.Write("|");
            switch (tablero[f,c])
            {
                case 0:
                    caracter_imprimir = " ~ ";
                    break;

                case 1:
                    caracter_imprimir = " ~ ";
                    break;

                case -1:
                    caracter_imprimir = " * ";
                    break;

                case -2:
                    caracter_imprimir = " X ";
                    break;

                default:
                    caracter_imprimir = " ~ ";
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
    int c1 = 0;
    int c2 = 5;

        do
        {

            Console.WriteLine("El temporizador ha comenzado. Tienes 60 segundos para hundir el barco.");
            int timeRemaining = 60;
            Timer timer = new Timer(state =>
            {
            timeRemaining--;

            if (timeRemaining == 0)
            {
                Console.WriteLine("Se ha acabado el tiempo.");
                Environment.Exit(0);
            }
            }, null, 0, 1000);

            do
            {
                Console.WriteLine($"Tienes {c2} intentos");
                Console.WriteLine("Ingresa la fila: ");
                filas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingresa la columna: ");
                columna = Convert.ToInt32(Console.ReadLine());

                if (filas < dm & columna < dm)
                {
                    c1 = 0;
                }
                else
                {
                    Console.WriteLine("Ingrese la fila/columna dentro del rango del tablero");
                    c1 = 1;
                }
            } while (c1 == 1);



        if (tablero[filas, columna] == 1)
            {
                Console.Beep();
                barcos--;
                tablero[filas, columna] = -1;    
            }
            else
            {
                tablero[filas, columna] = -2;
                c2--;
                
            }
            Console.Clear();
            paso3_imprimir_tablero();

        } while (barcos != 0 | c2 == 0);
    Console.ForegroundColor= ConsoleColor.Cyan;
    Console.WriteLine(" *******************************************");
    Console.WriteLine(" *******************************************");
    Console.WriteLine(" ******** F I N  D E L  J U E G O **********");
    Console.WriteLine(" *******************************************");
    Console.WriteLine(" *******************************************");
}

paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_coordenadas();