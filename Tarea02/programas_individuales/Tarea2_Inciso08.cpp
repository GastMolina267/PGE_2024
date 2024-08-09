#include <iostream>
#include <string>
#include <iomanip>

using namespace std;

class Pelicula {
private:
    string titulo;
    string director;
    string genero;
    int anio;

public:
    Pelicula(string titulo, string director, string genero, int anio)
        : titulo(titulo), director(director), genero(genero), anio(anio) {}

    string getTitulo() const { return titulo; }
    string getDirector() const { return director; }
    string getGenero() const { return genero; }
    int getAnio() const { return anio; }

    void mostrarInfo() const {
        cout << "Película: " << titulo << endl
             << "Director: " << director << endl
             << "Género: " << genero << endl
             << "Año: " << anio << endl;
    }
};

class Alquiler {
private:
    Pelicula pelicula;
    int diasAlquiler;
    const double tarifaBase = 2.5; // Tarifa base por día

public:
    Alquiler(const Pelicula& peli, int dias) : pelicula(peli), diasAlquiler(dias) {}

    double calcularCosto() const {
        double costo = tarifaBase * diasAlquiler;

        // Películas más nuevas son más caras
        if (pelicula.getAnio() >= 2020) {
            costo *= 1.5;
        }

        // Descuento para alquileres de larga duración
        if (diasAlquiler > 7) {
            costo *= 0.9; // 10% de descuento
        }

        return costo;
    }

    void mostrarDetalles() const {
        cout << "Detalles del Alquiler:" << endl;
        pelicula.mostrarInfo();
        cout << "Días de alquiler: " << diasAlquiler << endl;
        cout << "Costo total: $" << fixed << setprecision(2) << calcularCosto() << endl;
    }
};

int main() {
    Pelicula peli1("Inception", "Christopher Nolan", "Ciencia Ficción", 2010);
    Pelicula peli2("Tenet", "Christopher Nolan", "Acción", 2020);

    Alquiler alquiler1(peli1, 3);
    Alquiler alquiler2(peli2, 10);

    cout << "Alquiler 1:" << endl;
    alquiler1.mostrarDetalles();

    cout << "\nAlquiler 2:" << endl;
    alquiler2.mostrarDetalles();

    return 0;
}