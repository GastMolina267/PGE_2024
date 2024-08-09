#include <iostream>
#include <string>
using namespace std;

class Animal {
protected:
    std::string nombre;

public:
    Animal(const string& nombre) : nombre(nombre) {}

    void comer() const {
        cout << nombre << " está comiendo." << endl;
    }

    void dormir() const {
        cout << nombre << " está durmiendo." << endl;
    }

    virtual void hacerSonido() const {
        cout << nombre << " hace un sonido." << endl;
    }

    virtual ~Animal() {} // Destructor virtual para permitir la correcta destrucción de objetos derivados
};

class Perro : public Animal {
public:
    Perro(const string& nombre) : Animal(nombre) {}

    void ladrar() const {
        cout << nombre << " está ladrando: ¡Guau guau!" << endl;
    }

    void hacerSonido() const override {
        ladrar();
    }
};

class Gato : public Animal {
public:
    Gato(const string& nombre) : Animal(nombre) {}

    void maullar() const {
        cout << nombre << " está maullando: ¡Miau miau!" << endl;
    }

    void hacerSonido() const override {
        maullar();
    }
};

int main() {
    Animal* animales[3];
    animales[0] = new Animal("Animal Genérico");
    animales[1] = new Perro("Firulais");
    animales[2] = new Gato("Michi");

    for (int i = 0; i < 3; ++i) {
        animales[i]->comer();
        animales[i]->dormir();
        animales[i]->hacerSonido();
        cout << std::endl;
    }

    // Liberar memoria
    for (int i = 0; i < 3; ++i) {
        delete animales[i];
    }

    return 0;
}