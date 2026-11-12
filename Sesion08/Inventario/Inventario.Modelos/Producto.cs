namespace Inventario.Modelos;

public class Producto
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }

    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");
        if (precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a cero.");
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo.");

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
    }

    public void AgregarStock(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad a agregar debe ser mayor a cero.");

        Stock += cantidad;
    }

    public void Vender(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad a vender debe ser mayor a cero.");
        if (cantidad > Stock)
            throw new StockInsuficienteException(Nombre, Stock);

        Stock -= cantidad;
    }

    public override string ToString() =>
        $"[{Codigo}] {Nombre} - Precio: ${Precio:N2} - Stock: {Stock} uds.";
}
