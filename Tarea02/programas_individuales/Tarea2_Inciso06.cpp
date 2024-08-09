#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

class CuentaBancaria {
protected:
    double saldo;
    string numeroCuenta;

public:
    CuentaBancaria(const string& numero, double saldoInicial) 
        : numeroCuenta(numero), saldo(saldoInicial) {}

    virtual void depositar(double monto) {
        saldo += monto;
        cout << "Depósito de " << monto << " realizado. Nuevo saldo: " << saldo << endl;
    }

    virtual void retirar(double monto) {
        if (saldo >= monto) {
            saldo -= monto;
            cout << "Retiro de " << monto << " realizado. Nuevo saldo: " << saldo << endl;
        } else {
            cout << "Fondos insuficientes para realizar el retiro." << endl;
        }
    }

    virtual void mostrarSaldo() const {
        cout << "Cuenta " << numeroCuenta << " - Saldo actual: " << fixed << setprecision(2) << saldo << endl;
    }

    virtual ~CuentaBancaria() {}
};

class CuentaCorriente : public CuentaBancaria {
private:
    double comisionMantenimiento;

public:
    CuentaCorriente(const string& numero, double saldoInicial, double comision) 
        : CuentaBancaria(numero, saldoInicial), comisionMantenimiento(comision) {}

    void cobrarComision() {
        saldo -= comisionMantenimiento;
        cout << "Comisión de mantenimiento de " << comisionMantenimiento << " cobrada. Nuevo saldo: " << saldo << endl;
    }

    void mostrarSaldo() const override {
        CuentaBancaria::mostrarSaldo();
        cout << "Comisión de mantenimiento mensual: " << comisionMantenimiento << endl;
    }
};

class CuentaAhorro : public CuentaBancaria {
private:
    double tasaInteres;

public:
    CuentaAhorro(const string& numero, double saldoInicial, double tasa) 
        : CuentaBancaria(numero, saldoInicial), tasaInteres(tasa) {}

    void calcularInteres() {
        double interes = saldo * (tasaInteres / 100);
        saldo += interes;
        cout << "Interés de " << interes << " calculado y añadido. Nuevo saldo: " << saldo << endl;
    }

    void mostrarSaldo() const override {
        CuentaBancaria::mostrarSaldo();
        cout << "Tasa de interés anual: " << tasaInteres << "%" << endl;
    }
};

int main() {
    CuentaCorriente cc("CC-001", 1000, 5);
    CuentaAhorro ca("CA-001", 2000, 2.5);

    cout << "Estado inicial de las cuentas:" << endl;
    cc.mostrarSaldo();
    ca.mostrarSaldo();

    cout << "\nOperaciones en Cuenta Corriente:" << endl;
    cc.depositar(500);
    cc.retirar(200);
    cc.cobrarComision();

    cout << "\nOperaciones en Cuenta de Ahorro:" << endl;
    ca.depositar(1000);
    ca.retirar(500);
    ca.calcularInteres();

    cout << "\nEstado final de las cuentas:" << endl;
    cc.mostrarSaldo();
    ca.mostrarSaldo();

    return 0;
}