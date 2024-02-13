using System;

class Program
{
    const int capacidad = 15;
    string[] numerosFactura = new string[capacidad];
    string[] numerosPlaca = new string[capacidad];
    DateTime[] fechas = new DateTime[capacidad];
    TimeSpan[] horas = new TimeSpan[capacidad];
    int[] tiposVehiculo = new int[capacidad];
    int[] numerosCaseta = new int[capacidad];
    decimal[] montosAPagar = new decimal[capacidad];
    decimal[] pagaCon = new decimal[capacidad];
    decimal[] vueltos = new decimal[capacidad];

    static void Main(string[] args)
    {
        Program programa = new Program();
        programa.MenuPrincipal();
    }

    void MenuPrincipal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("** Menú Principal **");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por Número de Placa");
            Console.WriteLine("4. Modificar Datos de Vehículos por Número de Placa");
            Console.WriteLine("5. Reporte de Todos los Datos");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InicializarVectores();
                    break;
                case "2":
                    IngresarPasoVehicular();
                    break;
                case "3":
                    ConsultaPorPlaca();
                    break;
                case "4":
                    ModificarPorPlaca();
                    break;
                case "5":
                    ReporteTodosLosDatos();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    void InicializarVectores()
    {
        for (int i = 0; i < capacidad; i++)
        {
            numerosFactura[i] = "";
            numerosPlaca[i] = "";
            fechas[i] = DateTime.MinValue;
            horas[i] = TimeSpan.Zero;
            tiposVehiculo[i] = 0;
            numerosCaseta[i] = 0;
            montosAPagar[i] = 0;
            pagaCon[i] = 0;
            vueltos[i] = 0;
        }

        Console.WriteLine("Vectores inicializados correctamente.");
    }

    void IngresarPasoVehicular()
    {
        Console.WriteLine("** Registrar Flujo Vehicular **");

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] == "")
            {
                Console.WriteLine("Registro #{0}", i + 1);
                fechas[i] = DateTime.Now;
                horas[i] = TimeSpan.FromHours(DateTime.Now.Hour);
                Console.Write("Número de Factura: ");
                numerosFactura[i] = Console.ReadLine();

                Console.Write("Número de Placa: ");
                numerosPlaca[i] = Console.ReadLine();

                Console.WriteLine("Tipo de Vehículo:");
                Console.WriteLine("1. Moto");
                Console.WriteLine("2. Vehículo Liviano");
                Console.WriteLine("3. Camión o Pesado");
                Console.WriteLine("4. Autobús");
                Console.Write("Seleccione una opción: ");
                int tipoVehiculo;
                bool tipoValido;
                do
                {
                    Console.Write("Seleccione una opción: ");
                    tipoValido = int.TryParse(Console.ReadLine(), out tipoVehiculo) && tipoVehiculo >= 1 && tipoVehiculo <= 4;
                    if (!tipoValido)
                    {
                        Console.WriteLine("Por favor, ingrese un valor válido (1 a 4).");
                    }
                } while (!tipoValido);
                tiposVehiculo[i] = tipoVehiculo;

                Console.WriteLine("Número de Caseta:");
                Console.WriteLine("1. Caseta 1");
                Console.WriteLine("2. Caseta 2");
                Console.WriteLine("3. Caseta 3");
                Console.Write("Seleccione una opción: ");
                int numeroCaseta;
                bool casetaValida;
                do
                {
                    Console.Write("Seleccione una opción: ");
                    casetaValida = int.TryParse(Console.ReadLine(), out numeroCaseta) && numeroCaseta >= 1 && numeroCaseta <= 3;
                    if (!casetaValida)
                    {
                        Console.WriteLine("Por favor, ingrese un valor válido (1 a 3).");
                    }
                } while (!casetaValida);
                numerosCaseta[i] = numeroCaseta;

                switch (tiposVehiculo[i])
                {
                    case 1: // Moto
                        montosAPagar[i] = 500;
                        break;
                    case 2: // Vehículo Liviano
                        montosAPagar[i] = 700;
                        break;
                    case 3: // Camión o Pesado
                        montosAPagar[i] = 2700;
                        break;
                    case 4: // Autobús
                        montosAPagar[i] = 3700;
                        break;
                }
                
                Console.Write("Monto a Pagar: {0}", montosAPagar[i]);
                Console.WriteLine("============");

                Console.Write("Paga con: ");
                pagaCon[i] = decimal.Parse(Console.ReadLine());

                vueltos[i] = pagaCon[i] - montosAPagar[i];

                Console.Write("Vuelto: {0}", vueltos[i]);

                Console.Write("¿Desea continuar (S/N)? ");
                string continuar = Console.ReadLine();

                if (continuar.ToUpper() != "S")
                    break;
            }
        }
    }

    void ConsultaPorPlaca()
    {
        Console.Write("Ingrese el número de placa a consultar: ");
        string placa = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] == placa)
            {
                encontrado = true;

                Console.WriteLine("** Datos del Vehículo **");
                Console.WriteLine("Número de Factura: {0}", numerosFactura[i]);
                Console.WriteLine("Número de Placa: {0}", numerosPlaca[i]);
                Console.WriteLine("Fecha: {0}", fechas[i]);
                Console.WriteLine("Hora: {0}", horas[i]);
                Console.WriteLine("Tipo de Vehículo: {0}", tiposVehiculo[i]);
                Console.WriteLine("Número de Caseta: {0}", numerosCaseta[i]);
                Console.WriteLine("Monto a Pagar: {0}", montosAPagar[i]);
                Console.WriteLine("Paga con: {0}", pagaCon[i]);
                Console.WriteLine("Vuelto: {0}", vueltos[i]);

                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
    }

    void ModificarPorPlaca()
    {
        Console.Write("Ingrese el número de placa del vehículo a modificar: ");
        string placa = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] == placa)
            {
                encontrado = true;

                Console.WriteLine("** Datos del Vehículo **");
                Console.WriteLine("Número de Factura: {0}", numerosFactura[i]);
                Console.WriteLine("Número de Placa: {0}", numerosPlaca[i]);
                Console.WriteLine("Fecha: {0}", fechas[i]);
                Console.WriteLine("Hora: {0}", horas[i]);
                Console.WriteLine("Tipo de Vehículo: {0}", tiposVehiculo[i]);
                Console.WriteLine("Número de Caseta: {0}", numerosCaseta[i]);
                Console.WriteLine("Monto a Pagar: {0}", montosAPagar[i]);
                Console.WriteLine("Paga con: {0}", pagaCon[i]);
                Console.WriteLine("Vuelto: {0}", vueltos[i]);

                Console.WriteLine("¿Qué desea modificar?");
                Console.WriteLine("1. Número de Factura");
                Console.WriteLine("2. Fecha");
                Console.WriteLine("3. Hora");
                Console.WriteLine("4. Tipo de Vehículo");
                Console.WriteLine("5. Número de Caseta");
                Console.WriteLine("6. Paga con");
                Console.WriteLine("7. Vuelto");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nuevo Número de Factura: ");
                        numerosFactura[i] = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Ingrese la nueva fecha: ");
                        fechas[i] = DateTime.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Ingrese la nueva hora: ");
                        horas[i] = TimeSpan.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Nuevo Tipo de Vehículo:");
                        Console.WriteLine("1. Moto");
                        Console.WriteLine("2. Vehículo Liviano");
                        Console.WriteLine("3. Camión o Pesado");
                        Console.WriteLine("4. Autobús");
                        Console.Write("Seleccione una opción: ");
                        int tipoVehiculo;
                        bool tipoValido;
                        do
                        {
                            Console.Write("Seleccione una opción: ");
                            tipoValido = int.TryParse(Console.ReadLine(), out tipoVehiculo) && tipoVehiculo >= 1 && tipoVehiculo <= 4;
                            if (!tipoValido)
                            {
                                Console.WriteLine("Por favor, ingrese un valor válido (1 a 4).");
                            }
                        } while (!tipoValido);
                        tiposVehiculo[i] = tipoVehiculo;
                        break;

                    case 5:
                        Console.WriteLine("Nuevo Número de Caseta:");
                        Console.WriteLine("1. Caseta 1");
                        Console.WriteLine("2. Caseta 2");
                        Console.WriteLine("3. Caseta 3");
                        Console.Write("Seleccione una opción: ");
                        int numeroCaseta;
                        bool casetaValida;
                        do
                        {
                            Console.Write("Seleccione una opción: ");
                            casetaValida = int.TryParse(Console.ReadLine(), out numeroCaseta) && numeroCaseta >= 1 && numeroCaseta <= 3;
                            if (!casetaValida)
                            {
                                Console.WriteLine("Por favor, ingrese un valor válido (1 a 3).");
                            }
                        } while (!casetaValida);
                        numerosCaseta[i] = numeroCaseta;
                        break;
                    case 6:
                        Console.Write("Nuevo Paga con: ");
                        pagaCon[i] = decimal.Parse(Console.ReadLine());
                        vueltos[i] = pagaCon[i] - montosAPagar[i];
                        break;
                    case 7:
                        Console.Write("Nuevo Vuelto: ");
                        vueltos[i] = decimal.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("Datos modificados exitosamente.");
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
    }

    void ReporteTodosLosDatos()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("Título del Reporte");
        Console.WriteLine("Número de Factura\tNúmero de Placa\tTipo de Vehículo\tNúmero de Caseta\tMonto a Pagar\tPaga con\tVuelto");
        Console.WriteLine("===========================================");

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] != "")
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}",
                    numerosFactura[i], numerosPlaca[i], tiposVehiculo[i], numerosCaseta[i],
                    montosAPagar[i], pagaCon[i], vueltos[i]);
            }
        }

        Console.WriteLine("===========================================");
        Console.WriteLine("Cantidad de vehículos: {0}\t\tTotal: {1}", CantidadVehiculos(), TotalMontos());
        Console.WriteLine("===========================================");
        Console.WriteLine("<<< Pulse una tecla para regresar >>>");
        Console.ReadKey();
    }

    int CantidadVehiculos()
    {
        int cantidad = 0;

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] != "")
            {
                cantidad++;
            }
        }

        return cantidad;
    }

    decimal TotalMontos()
    {
        decimal total = 0;

        for (int i = 0; i < capacidad; i++)
        {
            if (numerosPlaca[i] != "")
            {
                total += montosAPagar[i];
            }
        }

        return total;
    }
}