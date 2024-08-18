using System;
public class Publicador
{
    // Declaración de un evento
    public event EventHandler EventoOcurrido;

    // Método que dispara el evento
    public void DispararEvento()
    {
        // Cuando ocurre el evento, se llama a todos los manejadores registrados
        EventoOcurrido?.Invoke(this, EventArgs.Empty);
    }
}

public class Suscriptor
{
    // Manejador de eventos que responde al evento
    public void ManejadorEvento(object sender, EventArgs e)
    {
        Console.WriteLine("El evento ha ocurrido.");
    }
}

class Program
{
    static void Main()
    {
        Publicador publicador = new Publicador();
        Suscriptor suscriptor = new Suscriptor();

        // Suscripción del manejador de eventos
        publicador.EventoOcurrido += suscriptor.ManejadorEvento;

        // Disparo del evento
        publicador.DispararEvento();
    }
}
