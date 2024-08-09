#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Persona {
protected:
    string nombre;
    int edad;
    string genero;

public:
    Persona(string n, int e, string g) : nombre(n), edad(e), genero(g) {}
    
    virtual void mostrarInfo() const {
        cout << "Nombre: " << nombre << ", Edad: " << edad << ", Género: " << genero << endl;
    }
};

class Empleado : public Persona {
protected:
    double salario;
    string cargo;

public:
    Empleado(string n, int e, string g, double s, string c)
        : Persona(n, e, g), salario(s), cargo(c) {}

    void mostrarInfo() const override {
        Persona::mostrarInfo();
        cout << "Cargo: " << cargo << ", Salario: $" << salario << endl;
    }
};

class Estudiante : public Persona {
private:
    double nota;

public:
    Estudiante(string n, int e, string g, double nt)
        : Persona(n, e, g), nota(nt) {}

    void mostrarInfo() const override {
        Persona::mostrarInfo();
        cout << "Nota: " << nota << endl;
    }
};

class Trabajador {
private:
    Persona persona;
    string departamento;
    int horasTrabajadas;

public:
    Trabajador(const Persona& p, string dep, int horas)
        : persona(p), departamento(dep), horasTrabajadas(horas) {}

    double calcularSalario() const {
        double tarifaPorHora = 10.0; // Tarifa base por hora
        if (departamento == "IT") tarifaPorHora *= 1.5;
        else if (departamento == "Gerencia") tarifaPorHora *= 2.0;
        return tarifaPorHora * horasTrabajadas;
    }

    void mostrarInfo() const {
        persona.mostrarInfo();
        cout << "Departamento: " << departamento 
                << ", Horas trabajadas: " << horasTrabajadas
                << ", Salario calculado: $" << calcularSalario() << endl;
    }
};

class SistemaGestionPersonal {
private:
    vector<Empleado> empleados;
    vector<Estudiante> estudiantes;
    vector<Trabajador> trabajadores;

public:
    void agregarEmpleado(const Empleado& emp) {
        empleados.push_back(emp);
    }

    void agregarEstudiante(const Estudiante& est) {
        estudiantes.push_back(est);
    }

    void agregarTrabajador(const Trabajador& trab) {
        trabajadores.push_back(trab);
    }

    void mostrarTodoElPersonal() const {
        cout << "Empleados:" << endl;
        for (const auto& emp : empleados) emp.mostrarInfo();

        cout << "\nEstudiantes:" << endl;
        for (const auto& est : estudiantes) est.mostrarInfo();

        cout << "\nTrabajadores:" << endl;
        for (const auto& trab : trabajadores) trab.mostrarInfo();
    }
};

int main() {
    SistemaGestionPersonal sistema;

    Empleado emp1("Juan Pérez", 30, "Masculino", 50000, "Gerente");
    Estudiante est1("María García", 20, "Femenino", 9.5);
    Persona p1("Carlos López", 25, "Masculino");
    Trabajador trab1(p1, "IT", 160);

    sistema.agregarEmpleado(emp1);
    sistema.agregarEstudiante(est1);
    sistema.agregarTrabajador(trab1);

    sistema.mostrarTodoElPersonal();

    return 0;
}