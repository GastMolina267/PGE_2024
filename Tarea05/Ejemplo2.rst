======================================
Análisis del Código: Event Dispatcher en C#
======================================

Este proyecto implementa un **Despachador de Eventos** en C# utilizando un patrón de diseño basado en la suscripción y despacho de eventos. El código abarca:

1. Simulación de un sistema de eventos que permite suscribir, desuscribir y despachar eventos.
2. Definición de un despachador de eventos con múltiples manejadores de eventos.
3. Uso de un evento global que maneja todas las operaciones de despacho.
4. Simulación del procesamiento de eventos mediante un retardo.

Descripción General
-------------------
El código simula un sistema de eventos basado en el patrón de **suscripción y despacho de eventos**. Se pueden registrar múltiples manejadores a eventos específicos y también hay un manejador global que responde a cualquier evento despachado.

**Componentes Clave**:

1. **EventDispatcher**: Clase que maneja la suscripción y despacho de eventos.
2. **Subscribe**: Método para suscribir manejadores de eventos a eventos específicos.
3. **Unsubscribe**: Método para desuscribir manejadores de eventos.
4. **DispatchEvent**: Método que despacha eventos a todos los suscriptores registrados.
5. **EventDispatched**: Evento global que se dispara cada vez que se despacha un evento.

Diseño de la Clase `EventDispatcher`
------------------------------------
La clase **EventDispatcher** actúa como el centro de administración de eventos. Contiene métodos para suscribir y desuscribir manejadores, así como para despachar eventos. También mantiene un diccionario de eventos y sus respectivos manejadores.

.. code-block:: csharp

    using System;
    using System.Collections.Generic;

    public class EventDispatcher
    {
        private readonly Dictionary<string, EventHandler> eventHandlers = new Dictionary<string, EventHandler>();

        public event EventHandler EventDispatched;

        public void Subscribe(string eventName, EventHandler eventHandler)
        {
            if (!eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = eventHandler;
            }
            else
            {
                eventHandlers[eventName] += eventHandler;
            }
        }

        public void Unsubscribe(string eventName, EventHandler eventHandler)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] -= eventHandler;
            }
        }

        public void DispatchEvent(string eventName)
        {
            Console.WriteLine($"Evento '{eventName}' despachado.");
            EventDispatched?.Invoke(this, EventArgs.Empty);
            // Simulación de procesamiento
            Thread.Sleep(1000);
        }
    }

Explicación:
~~~~~~~~~~~~
- **Diccionario de Manejadores de Eventos:** Un diccionario donde las claves son nombres de eventos (cadenas de texto) y los valores son los manejadores de eventos (delegados de tipo `EventHandler`).
- **Evento Global `EventDispatched`:** Se dispara cada vez que cualquier evento es despachado, permitiendo una respuesta general a todos los eventos.
- **Método `Subscribe`:** Permite que los manejadores se suscriban a eventos específicos.
- **Método `Unsubscribe`:** Permite que los manejadores se desuscriban de eventos específicos.
- **Método `DispatchEvent`:** Despacha un evento específico, notificando a los suscriptores y al evento global.

Suscripción y Desuscripción de Eventos
--------------------------------------
Las clases externas pueden suscribirse a eventos específicos mediante el método `Subscribe`, y desuscribirse con el método `Unsubscribe`. Esto permite flexibilidad en cómo se manejan los eventos.

.. code-block:: csharp

    // Suscribir a un evento
    eventDispatcher.Subscribe("Evento1", Event1Handler);

    // Desuscribir un evento
    eventDispatcher.Unsubscribe("Evento1", Event1Handler);

Manejo Global de Eventos
------------------------
Además de los manejadores de eventos específicos, hay un **manejador global** que responde a todos los eventos despachados, utilizando el evento `EventDispatched`.

.. code-block:: csharp

    // Manejar el evento global
    eventDispatcher.EventDispatched += GlobalEventHandler;

Simulación de Procesamiento de Eventos
--------------------------------------
El método `DispatchEvent` simula el procesamiento de eventos mediante un retardo (`Thread.Sleep(1000)`) que representa el tiempo que tardaría en procesarse un evento.

Ejemplo Completo
----------------

.. code-block:: csharp

    using System;
    using System.Collections.Generic;
    using System.Threading;

    namespace EventDispatcher
    {
        public delegate void EventHandler(object sender, EventArgs e);

        public class EventDispatcher
        {
            private readonly Dictionary<string, EventHandler> eventHandlers = new Dictionary<string, EventHandler>();

            public event EventHandler EventDispatched;

            public void Subscribe(string eventName, EventHandler eventHandler)
            {
                if (!eventHandlers.ContainsKey(eventName))
                {
                    eventHandlers[eventName] = eventHandler;
                }
                else
                {
                    eventHandlers[eventName] += eventHandler;
                }
            }

            public void Unsubscribe(string eventName, EventHandler eventHandler)
            {
                if (eventHandlers.ContainsKey(eventName))
                {
                    eventHandlers[eventName] -= eventHandler;
                }
            }

            public void DispatchEvent(string eventName)
            {
                Console.WriteLine($"Evento '{eventName}' despachado.");
                EventDispatched?.Invoke(this, EventArgs.Empty);
                Thread.Sleep(1000);
            }
        }

        class Program
        {
            static void Main()
            {
                EventDispatcher eventDispatcher = new EventDispatcher();

                // Suscribir a un evento
                eventDispatcher.Subscribe("Evento1", Event1Handler);

                // Suscribir a un evento diferente
                eventDispatcher.Subscribe("Evento2", Event2Handler);

                // Manejar el evento global
                eventDispatcher.EventDispatched += GlobalEventHandler;

                // Despachar eventos
                eventDispatcher.DispatchEvent("Evento1");
                eventDispatcher.DispatchEvent("Evento2");

                // Desuscribir un evento
                eventDispatcher.Unsubscribe("Evento1", Event1Handler);

                // Despachar eventos nuevamente
                eventDispatcher.DispatchEvent("Evento1");
                eventDispatcher.DispatchEvent("Evento2");
            }

            static void Event1Handler(object sender, EventArgs e)
            {
                Console.WriteLine("Manejador del Evento1");
            }

            static void Event2Handler(object sender, EventArgs e)
            {
                Console.WriteLine("Manejador del Evento2");
            }

            static void GlobalEventHandler(object sender, EventArgs e)
            {
                Console.WriteLine("Manejador Global del Evento");
            }
        }
    }

Explicación Completa:
~~~~~~~~~~~~~~~~~~~~~
1. **EventDispatcher:** Actúa como un centro para la suscripción y despacho de eventos.
2. **Suscripción y Desuscripción de Eventos:** Permite añadir y remover manejadores de eventos específicos.
3. **Evento Global:** Maneja todos los eventos despachados desde un único lugar.
4. **Simulación de Procesamiento:** El retardo simula el tiempo de procesamiento de eventos.
"""