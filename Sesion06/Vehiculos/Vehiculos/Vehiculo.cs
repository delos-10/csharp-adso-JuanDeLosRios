
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehiculos
{
    public abstract class Vehiculo
    {
        public string Placa { get; }
        public int Ruedas { get; }

        protected Vehiculo(string placa, int ruedas)
        {
            Placa = placa.ToUpper();
            Ruedas = ruedas;
            //Console.WriteLine($"(1) Constructor de Vehiculo {placa} {Ruedas}");
        }

        public abstract decimal CalcularPeaje();

        public virtual string Describir() =>
            $"{GetType().Name} {Placa} - {Ruedas} ruedas - Peaje {CalcularPeaje():C0}";
    }

    public class Carro : Vehiculo
    {
        public int Puestos { get; }

        public Carro(string placa, int puestos) : base(placa, 4) => Puestos = puestos;
        public override decimal CalcularPeaje() => 12000m;


    }
    public class Cohete : Vehiculo
    {
        public int Puestos { get; }

        public Cohete(string placa, int puestos) : base(placa, 4) => Puestos = puestos;
        public override decimal CalcularPeaje() => 522000m;
    }

    public class Moto : Vehiculo
    {
        public Moto(string placa) : base(placa, 2) { }
        public override decimal CalcularPeaje() => 0m;
        public override string Describir() => base.Describir() + " · usa casco";

    }

    public interface IRecargable
    {
        int Bateria { get; }
        void Recargar();
    }

    public class CarroElectrico : Carro, IRecargable
    {
        public int Bateria { get; private set; } = 40;

        public CarroElectrico(string placa, int puestos) : base(placa, puestos) { }

        public override decimal CalcularPeaje() => base.CalcularPeaje() * 0.5m;

        public void Recargar() => Bateria = 100;
    }

    public class Patineta : IRecargable
    {
        public int Bateria { get; private set; } = 15;

        public void Recargar() => Bateria = 80;
    }
}

