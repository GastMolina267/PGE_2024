#include <iostream>
using namespace std;
//FUNCIÓN CALLBACK
/*
La función que recibe la callback no la ejecuta inmediatamente, sino que la guarda para ejecutarla en el 
momento adecuado, como después de completar una operación asíncrona o cuando se activa un evento particular.

Las callbacks son comúnmente utilizadas en programación asíncrona, donde el código no se ejecuta 
secuencialmente. Por ejemplo, en JavaScript, cuando se realiza una solicitud HTTP, se pasa una función 
callback que se ejecutará cuando se reciba la respuesta.
*/
// Definición de una función de callback
void MiCallBack(int valor){
    cout<<"Valor recibido en el callback: "<<valor<<endl;

}

// Fucnión que toma un callback como argumento
void ProcesarDatos(int dato, void(*callback)(int)){
    //Realizar algún procesamiento...
    callback(dato); //Llama al callback
}

int main(){
    ProcesarDatos(42, MiCallBack);//Pasamos el callback como argumento

    return 0;
}