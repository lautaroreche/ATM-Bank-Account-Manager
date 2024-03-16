/* Cajero automático que maneja una caja de ahorro, la cual tiene las propiedades número, titular y saldo.
Mediante el cajero se puede depositar dinero, extraer dinero o consultar el saldo.
Consideraciones:
* El saldo de la cuenta debe estar entre 0 y 9999999
* Los valores de depósitos y extracciones pueden ser entre 1 y 10000
* Se trabaja sobre una sola caja de ahorro, creada y establecida
* Tener en cuenta el ingreso de opciones incorrectas */


using System;	


public class Program{
	public static void Main(){
		Cajero miCajero = new Cajero();
		miCajero.PresentarMenu();			
	}
}



public class CajaAhorro{
	private int numero;
	private string titular;
	private double saldo;
	
	public CajaAhorro(int n, string t, double s){
		this.numero = n;
		this.titular = t;
		this.saldo = s;
	}
	
	public void ModificarSaldo(double nuevoSaldo){
		saldo = nuevoSaldo;
	}
	
	public double GetSaldo(){
		return saldo;
	}
}



public class Cajero{
	
	public void PresentarMenu(){
		string opcion;
		
		CajaAhorro miCajaAhorro = new CajaAhorro(12345678, "Lautaro", 50000.50);
		
		do {
			Console.WriteLine("\nIngrese una opción\n1- Depositar dinero\n2- Extraer dinero\n3- Consultar saldo\n4- Salir");
			opcion = Console.ReadLine();
			if (opcion == "1"){
				double auxiliar = PedirMonto();
				if ((miCajaAhorro.GetSaldo() + auxiliar) <= 9999999){
					double nuevoSaldo = miCajaAhorro.GetSaldo() + auxiliar;
					miCajaAhorro. ModificarSaldo(nuevoSaldo);
					Console.WriteLine("Su saldo actual es " + miCajaAhorro.GetSaldo());
				}
				else{
					Console.WriteLine("\nOperación rechazada. El saldo total de la cuenta no puede superar los 9999999");
				}
			}
			else if (opcion == "2"){
				double auxiliar = PedirMonto();
				if (auxiliar <= miCajaAhorro.GetSaldo()){
					double nuevoSaldo = miCajaAhorro.GetSaldo() - auxiliar;
					miCajaAhorro. ModificarSaldo(nuevoSaldo);
					Console.WriteLine("Su saldo actual es " + miCajaAhorro.GetSaldo());
				}
				else{
					Console.WriteLine("\nOperación rechazada. El monto seleccionado excede el saldo actual");
				}
			}
			else if (opcion == "3"){
				Console.WriteLine("Su saldo actual es " + miCajaAhorro.GetSaldo());
			}
			else if (opcion == "4"){
				Console.WriteLine("Has elegido salir, gracias por usar el programa");
			}
			else {
				Console.WriteLine("Has ingresado una opción no válida. Ingresar 1, 2, 3 o 4");
			}
		} while (opcion != "4");
	}
	
	
	public double PedirMonto(){
		bool validDouble;
		double monto;
		
		do {
			Console.WriteLine("Ingrese el monto");
			validDouble = double.TryParse(Console.ReadLine(), out monto);
			
			if (!validDouble){
				Console.WriteLine("El dato ingresado no es un número");
			}
			if ((monto <=1) || (monto >= 10000)){
				Console.WriteLine("El monto ingresado debe estar entre 1 y 10000");
			}
		} while ((!validDouble) || ((monto <=1) || (monto >= 10000)));
		
		return monto;
	}
}
