#include <iostream>
#include <string>
using namespace std;

class Vehiculo {
protected:
    std::string modelo;
    int ano_lanzamiento;
    std::string marca;

public:
    Vehiculo(std::string marca, std::string modelo, int ano) 
        : marca(marca), modelo(modelo), ano_lanzamiento(ano) {}

    void setModelo(std::string modelo) { this->modelo = modelo; }
    void setMarca(std::string marca) { this->marca = marca; }
    void setAno(int ano_lanzamiento) { this->ano_lanzamiento = ano_lanzamiento; }
    std::string getModelo() const { return modelo; }
    std::string getMarca() const { return marca; }
    int getAno() const { return ano_lanzamiento; }

    virtual void mostrarInfo() const {
        std::cout << "Marca: " << marca << ", Modelo: " << modelo << ", Año: " << ano_lanzamiento;
    }
};

class Coche : public Vehiculo {
private:
    int numero_puertas;

public:
    Coche(std::string marca, std::string modelo, int ano, int puertas) 
        : Vehiculo(marca, modelo, ano), numero_puertas(puertas) {}

    void setNumeroPuertas(int puertas) { numero_puertas = puertas; }
    int getNumeroPuertas() const { return numero_puertas; }

    void mostrarInfo() const override {
        Vehiculo::mostrarInfo();
        std::cout << ", Número de puertas: " << numero_puertas << std::endl;
    }
};

class Moto : public Vehiculo {
private:
    int cilindrada;

public:
    Moto(std::string marca, std::string modelo, int ano, int cilindrada) 
        : Vehiculo(marca, modelo, ano), cilindrada(cilindrada) {}

    void setCilindrada(int cc) { cilindrada = cc; }
    int getCilindrada() const { return cilindrada; }

    void mostrarInfo() const override {
        Vehiculo::mostrarInfo();
        std::cout << ", Cilindrada: " << cilindrada << " cc" << std::endl;
    }
};

int main() {
    Coche miCoche("Toyota", "Corolla", 2022, 4);
    Moto miMoto("Honda", "CBR", 2021, 600);

    std::cout << "Información del coche:" << std::endl;
    miCoche.mostrarInfo();

    std::cout << "\nInformación de la moto:" << std::endl;
    miMoto.mostrarInfo();

    return 0;
}