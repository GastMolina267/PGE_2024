#include <iostream>
#include <string>
#include <vector>
#include <iomanip>
using namespace std;

class Producto {
private:
    string nombre;
    double precio;
    int cantidad;

public:
    Producto(const string& nombre, double precio, int cantidad)
        : nombre(nombre), precio(precio), cantidad(cantidad) {}

    string getNombre() const { return nombre; }
    double getPrecio() const { return precio; }
    int getCantidad() const { return cantidad; }

    void setCantidad(int nuevaCantidad) { cantidad = nuevaCantidad; }

    double getSubtotal() const { return precio * cantidad; }

    void mostrarInfo() const {
        std::cout << left << setw(20) << nombre 
                  << right << setw(10) << fixed << setprecision(2) << precio
                  << setw(10) << cantidad
                  << setw(15) << getSubtotal() << endl;
    }
};

class CarritoDeCompras {
private:
    vector<Producto> productos;

public:
    void agregarProducto(const Producto& producto) {
        productos.push_back(producto);
    }

    void removerProducto(const string& nombre) {
        for (auto it = productos.begin(); it != productos.end(); ++it) {
            if (it->getNombre() == nombre) {
                productos.erase(it);
                cout << "Producto '" << nombre << "' removido del carrito." << endl;
                return;
            }
        }
        cout << "Producto '" << nombre << "' no encontrado en el carrito." << endl;
    }

    double calcularTotal() const {
        double total = 0;
        for (const auto& producto : productos) {
            total += producto.getSubtotal();
        }
        return total;
    }

    void aplicarDescuento(double porcentaje) {
        double factor = 1 - (porcentaje / 100);
        for (auto& producto : productos) {
            producto.setCantidad(producto.getCantidad() * factor);
        }
        std::cout << "Descuento del " << porcentaje << "% aplicado." << std::endl;
    }

    void mostrarCarrito() const {
        cout << left << setw(20) << "Producto" 
                  << right << setw(10) << "Precio"
                  << setw(10) << "Cantidad"
                  << setw(15) << "Subtotal" << endl;
        cout << string(55, '-') << endl;

        for (const auto& producto : productos) {
            producto.mostrarInfo();
        }
        cout << string(55, '-') << endl;
        cout << "Total: $" << fixed << setprecision(2) << calcularTotal() << endl;
    }
};

int main() {
    CarritoDeCompras carrito;

    carrito.agregarProducto(Producto("Manzanas", 0.5, 6));
    carrito.agregarProducto(Producto("Leche", 2.5, 2));
    carrito.agregarProducto(Producto("Pan", 1.8, 1));
    carrito.agregarProducto(Producto("Queso", 4.0, 1));

    cout << "Carrito inicial:" << endl;
    carrito.mostrarCarrito();

    carrito.removerProducto("Pan");

    cout << "\nCarrito después de remover el pan:" << endl;
    carrito.mostrarCarrito();

    carrito.aplicarDescuento(10);

    cout << "\nCarrito después de aplicar un descuento del 10%:" << endl;
    carrito.mostrarCarrito();

    return 0;
}