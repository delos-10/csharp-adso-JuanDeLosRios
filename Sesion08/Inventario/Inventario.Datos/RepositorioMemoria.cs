using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioMemoria : IRepositorioProductos
{
    private readonly List<Producto> _productos = [];

    public List<Producto> ObtenerTodos() => [.. _productos];

    public Producto? BuscarPorCodigo(string codigo) =>
        _productos.FirstOrDefault(p => p.Codigo.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));

    public void Agregar(Producto producto) => _productos.Add(producto);

    public void Actualizar(Producto producto)
    {
        int i = _productos.FindIndex(p => p.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase));
        if (i >= 0) _productos[i] = producto;
    }

    public void Eliminar(string codigo) =>
        _productos.RemoveAll(p => p.Codigo.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));
}
