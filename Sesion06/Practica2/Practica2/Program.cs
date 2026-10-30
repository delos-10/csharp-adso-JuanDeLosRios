using Practica2;

List<INotificador> canales =
[
    new NotificadorCorreo(),
    new NotificadorSms(),
    new NotificadorWhatsApp(),
    new NotificadorPush() // Paso 6: agregado sin modificar AvisarATodos
];

AvisarATodos(canales, "Ana", "Mañana no hay clase.");

static void AvisarATodos(List<INotificador> canales, string destinatario, string mensaje)
{
    foreach (INotificador canal in canales)
    {
        canal.Enviar(destinatario, mensaje);
    }
}