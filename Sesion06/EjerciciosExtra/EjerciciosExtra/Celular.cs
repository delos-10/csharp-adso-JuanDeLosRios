using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosExtra
{
    internal class Celular
    {

        private string _marca;
        private int _bateria;


        public Celular(string marca, int bateria = 100)
        {
            Marca = marca;
            _bateria = Math.Clamp(bateria, 0, 100);
        }


        public string Marca
        {
            get { return _marca; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El celular debe tener marca.");
                _marca = value;
            }
        }


        public int Bateria
        {
            get { return _bateria; }
            private set { _bateria = Math.Clamp(value, 0, 100); }
        }

        public void Cargar(int porcentaje)
        {
            if (porcentaje <= 0) return;
            Bateria = Math.Min(100, _bateria + porcentaje);
        }

        public bool Usar(int minutos)
        {
            if (minutos <= 0 || minutos > _bateria) return false;
            Bateria = _bateria - minutos;
            return true;
        }
    }

}

