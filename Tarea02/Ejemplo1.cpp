#include <iostream>
using namespace std;
// BUCLE ESPACIADOR DE EVENTOS

/*
El bucle espaciador de eventos espera a que ocurra un evento, como una entrada del usuario, 
una respuesta de la red, o un temporizador que se dispara.

Cuando un evento ocurre, el bucle lo toma y ejecuta el código asociado a ese evento 
(generalmente a través de una función callback).

Una vez que el evento se ha manejado, el bucle vuelve a esperar más eventos, repitiendo este proceso indefinidamente.
*/
class Ventana{
    public:
        void OneKeyDown(char key){
            cout<<"Tecla presionada: "<<key<<endl;

        }
        void RunEventLoop(){
            char key;
            bool running =true;
            while(running == true){
                cout<<"Esperando evento... (presione una tecla o 'q' para salir)"<<endl;
                cin>>key;
                if(key == 'q'){
                    running = false;
                }
                else{
                    OneKeyDown(key);
                }
            }
            cout<<"Saliendo del bucle..."<<endl;
        }


};

int main(){
    Ventana ventana;
    ventana.RunEventLoop();

    return 0;
}