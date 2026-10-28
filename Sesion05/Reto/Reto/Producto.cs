using System;
using System.Collections.Generic;
using System.Text;

namespace Reto
{
    internal class Producto
    {
        private string _nombre = "";
        private decimal _precio;

        public string Codigo { get; private set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                _nombre = value.Trim();
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor que cero.");
                _precio = value;
            }
        }

        public int Stock { get; private set; }

        public Producto(string codigo, string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código es obligatorio y no puede estar vacío.");
            if (stock < 0)
                throw new ArgumentException("El stock inicial no puede ser negativo.");

            Codigo = codigo.Trim().ToUpper();
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a agregar debe ser mayor que cero.");
            Stock += cantidad;
        }

        public bool Vender(int cantidad)
        {
            if (cantidad <= 0 || cantidad > Stock)
                return false;

            Stock -= cantidad;
            return true;
        }

        public override string ToString() =>
            $"[{Codigo}] {Nombre,-20} | Precio: ${Precio,10:N2} | Stock: {Stock}";
    }
}
