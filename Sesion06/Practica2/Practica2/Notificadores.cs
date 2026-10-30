namespace Practica2;

public interface INotificador
{
    string Canal { get; }
    void Enviar(string destinatario, string mensaje);
}

public class NotificadorCorreo : INotificador
{
    public string Canal => "Correo";
    public void Enviar(string destinatario, string mensaje) =>
        Console.WriteLine($"[Correo] Para {destinatario}: {mensaje}");
}

public class NotificadorSms : INotificador
{
    public string Canal => "SMS";
    public void Enviar(string destinatario, string mensaje)
    {
        string textoCorto = mensaje.Length > 160 ? mensaje[..160] : mensaje;
        Console.WriteLine($"[SMS] Para {destinatario}: {textoCorto}");
    }
}

public class NotificadorWhatsApp : INotificador
{
    public string Canal => "WhatsApp";
    public void Enviar(string destinatario, string mensaje) =>
        Console.WriteLine($"[WhatsApp] Para {destinatario}: {mensaje}");
}

public class NotificadorPush : INotificador
{
    public string Canal => "Push";
    public void Enviar(string destinatario, string mensaje) =>
        Console.WriteLine($"[Push] Para {destinatario}: {mensaje}");
}