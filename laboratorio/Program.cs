
using System;

class Program
{
    // DATOS DE LAS ENTREGAS DIGITALES

    static string[] codigos =
    {
        "EST001", "EST002", "EST003", "EST004",
        "EST005", "EST006", "EST007", "EST008"
    };

    static string[] archivos =
    {
        "laboratorio_final.pdf",
        "tarea_v2.docx",
        "informe_final.pdf",
        "practica_v1.pdf",
        "proyecto_final.zip",
        "actividad_v2.docx",
        "ejercicio.pdf",
        "reporte_final.docx"
    };

    static int[] puntajes =
    {
        18, 15, 20, 14, 19, 16, 17, 13
    };

    // MENU PRINCIPAL

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==========================================");
            Console.WriteLine("       LABORATORIO 7 - RECURSIVIDAD");
            Console.WriteLine("     SISTEMA DE ENTREGAS DIGITALES");
            Console.WriteLine("       FUNDAMENTOS DE PROGRAMACION");
            Console.WriteLine("==========================================");

            Console.ResetColor();
            Console.WriteLine("1. Mostrar entregas registradas");
            Console.WriteLine("2. Sumatoria recursiva de puntajes");
            Console.WriteLine("3. Buscar codigo de estudiante");
            Console.WriteLine("4. Contar archivos por palabra clave");
            Console.WriteLine("5. Calcular factorial recursivo");
            Console.WriteLine("6. Calcular potencia recursiva");
            Console.WriteLine("7. Comparar recursividad e iteracion");
            Console.WriteLine("8. Probar arreglo vacio");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==========================================");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)
              || opcion < 0 || opcion > 8)
           {
             opcion = -1;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    MostrarEntregas();
                    break;

                case 2:
                    Console.WriteLine("=== SUMATORIA RECURSIVA ===");

                    Console.WriteLine("Total de puntajes: " +
                        SumarRecursivo(puntajes, 0));
                    break;

                case 3:
                    BuscarEstudiante();
                    break;

                case 4:
                    ContarArchivos();
                    break;

                case 5:
                    CalcularFactorial();
                    break;

                case 6:
                    CalcularPotencia();
                    break;

                case 7:
                    CompararSoluciones();
                    break;

                case 8:
                    ProbarArregloVacio();
                    break;

                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;

               default:
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("Error: ingrese una opcion entre 0 y 8.");
                 Console.ResetColor();
                 break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcion != 0);
    }

    // 1. MOSTRAR ENTREGAS REGISTRADAS

    static void MostrarEntregas()
    {
        Console.WriteLine("========== ENTREGAS REGISTRADAS ==========\n");

        for (int i = 0; i < codigos.Length; i++)
        {
            Console.WriteLine("Codigo: " + codigos[i]);
            Console.WriteLine("Archivo: " + archivos[i]);
            Console.WriteLine("Puntaje: " + puntajes[i]);
            Console.WriteLine("------------------------------------------");
        }

        Console.WriteLine("Total de entregas: " + codigos.Length);
    }

    // 2. // Calcula la suma de los puntajes almacenados.
          // Caso base: retorna 0 al llegar al final del arreglo.
          // Caso recursivo: suma el puntaje actual y avanza el indice.

    static int SumarRecursivo(int[] datos, int indice)
    {
        // Caso base
        if (indice >= datos.Length)
        {
            return 0;
        }

        // Caso recursivo
        return datos[indice] +
               SumarRecursivo(datos, indice + 1);
    }

    // 3. // Busca un codigo de estudiante dentro del arreglo.
          // Retorna -1 si el codigo no existe.
          // Si encuentra una coincidencia, retorna su posicion.
          // En cada llamada recursiva incrementa el indice.

    static int BuscarRecursivo(string[] datos, string codigo, int indice)
    {
        // Caso base: codigo no encontrado
        if (indice >= datos.Length)
        {
            return -1;
        }

        // Caso base: codigo encontrado
        if (datos[indice].Equals(codigo,
            StringComparison.OrdinalIgnoreCase))
        {
            return indice;
        }

        // Caso recursivo
        return BuscarRecursivo(datos, codigo, indice + 1);
    }

    static void BuscarEstudiante()
    {
        Console.WriteLine("=== BUSCAR ESTUDIANTE ===");

        Console.Write("Ingrese codigo de estudiante: ");
        string codigo = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("Error: el codigo no puede estar vacio.");
            return;
        }

        int posicion = BuscarRecursivo(codigos, codigo, 0);

        if (posicion == -1)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            Console.WriteLine("\nESTUDIANTE ENCONTRADO");
            Console.WriteLine("Codigo: " + codigos[posicion]);
            Console.WriteLine("Archivo: " + archivos[posicion]);
            Console.WriteLine("Puntaje: " + puntajes[posicion]);
        }
    }

    // 4. // Cuenta los archivos que contienen una palabra clave.
          // Caso base: retorna 0 al finalizar el recorrido.
          // Acumula las coincidencias mediante llamadas recursivas.

    static int ContarRecursivo(string[] datos, string palabra, int indice)
    {
        // Caso base
        if (indice >= datos.Length)
        {
            return 0;
        }

        int cantidad = 0;

        if (datos[indice].Contains(palabra,
            StringComparison.OrdinalIgnoreCase))
        {
            cantidad = 1;
        }

        // Caso recursivo
        return cantidad +
               ContarRecursivo(datos, palabra, indice + 1);
    }

    static void ContarArchivos()
    {
        Console.WriteLine("=== CONTEO DE ARCHIVOS ===");

        Console.Write("Ingrese palabra clave: ");
        string palabra = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(palabra))
        {
            Console.WriteLine("Error: la palabra no puede estar vacia.");
            return;
        }

        int resultado = ContarRecursivo(archivos, palabra, 0);

        Console.WriteLine("Palabra buscada: " + palabra);
        Console.WriteLine("Archivos encontrados: " + resultado);
    }

    // 5. // Calcula el factorial de un numero entero.
          // Caso base: si el numero es 0 o 1, retorna 1.
          // Caso recursivo: multiplica el numero por Factorial(numero - 1).

    static long Factorial(int numero)
    {
        // Caso base
        if (numero == 0 || numero == 1)
        {
            return 1;
        }

        // Caso recursivo
        return numero * Factorial(numero - 1);
    }

    static void CalcularFactorial()
    {
        Console.WriteLine("=== FACTORIAL RECURSIVO ===");

        Console.Write("Ingrese un numero entre 0 y 20: ");

        if (!int.TryParse(Console.ReadLine(), out int numero)
            || numero < 0 || numero > 20)
        {
            Console.WriteLine("Error: numero fuera del rango permitido.");
            return;
        }

        Console.WriteLine("Factorial de " + numero +
                          " = " + Factorial(numero));
    }

    // 6. // Calcula una potencia mediante recursividad.
          // Caso base: si el exponente es 0, retorna 1.
          // Caso recursivo: disminuye el exponente en una unidad.

    static long Potencia(int numeroBase, int exponente)
    {
        // Caso base
        if (exponente == 0)
        {
            return 1;
        }

        // Caso recursivo
        return numeroBase *
               Potencia(numeroBase, exponente - 1);
    }

    static void CalcularPotencia()
    {
        Console.WriteLine("=== POTENCIA RECURSIVA ===");

        Console.Write("Ingrese la base (0 a 10): ");

        if (!int.TryParse(Console.ReadLine(), out int numeroBase)
            || numeroBase < 0 || numeroBase > 10)
        {
            Console.WriteLine("Error: base incorrecta.");
            return;
        }

        Console.Write("Ingrese el exponente (0 a 18): ");

        if (!int.TryParse(Console.ReadLine(), out int exponente)
            || exponente < 0 || exponente > 18)
        {
            Console.WriteLine("Error: exponente incorrecto.");
            return;
        }

        Console.WriteLine(numeroBase + " elevado a " +
            exponente + " = " + Potencia(numeroBase, exponente));
    }

    // 7. SUMATORIA ITERATIVA

    static int SumarIterativo(int[] datos)
    {
        int suma = 0;

        for (int i = 0; i < datos.Length; i++)
        {
            suma += datos[i];
        }

        return suma;
    }

    // COMPARACION DE SOLUCIONES

    static void CompararSoluciones()
    {
        Console.WriteLine("=== COMPARACION DE SOLUCIONES ===");

        int recursivo = SumarRecursivo(puntajes, 0);
        int iterativo = SumarIterativo(puntajes);

        Console.WriteLine("Resultado recursivo: " + recursivo);
        Console.WriteLine("Resultado iterativo: " + iterativo);

        if (recursivo == iterativo)
        {
            Console.WriteLine("Ambos resultados son iguales.");
        }
        else
        {
            Console.WriteLine("Los resultados son diferentes.");
        }

        Console.WriteLine("\nRECURSIVIDAD:");
        Console.WriteLine("Utiliza llamadas a la misma funcion.");

        Console.WriteLine("\nITERACION:");
        Console.WriteLine("Utiliza ciclos para recorrer el arreglo.");

        Console.WriteLine("\nLa iteracion consume menos memoria auxiliar");
        Console.WriteLine("en esta operacion.");
    }

    // 8. PRUEBA CON ARREGLO VACIO

    static void ProbarArregloVacio()
    {
        Console.WriteLine("=== PRUEBA DE ARREGLO VACIO ===");

        int[] puntajesVacios = new int[0];
        string[] datosVacios = new string[0];

        Console.WriteLine("Cantidad de elementos: 0");

        Console.WriteLine("Sumatoria recursiva: " +
            SumarRecursivo(puntajesVacios, 0));

        Console.WriteLine("Sumatoria iterativa: " +
            SumarIterativo(puntajesVacios));

        Console.WriteLine("Resultado de busqueda: " +
            BuscarRecursivo(datosVacios, "EST001", 0));

        Console.WriteLine("Conteo de archivos: " +
            ContarRecursivo(datosVacios, "final", 0));

        Console.WriteLine("\n-1 significa codigo no encontrado.");
    }
}

