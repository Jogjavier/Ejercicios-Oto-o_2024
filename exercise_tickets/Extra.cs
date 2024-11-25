/*

// Lista para almacenar los boletos comprados por el comprador
   private List<Ticket> boletosComprados;

   // Constructor: Inicializa la lista de boletos comprados
   public Comprador()
   {
      boletosComprados = new List<Ticket>();
   }

   public void ComprarBoleto(int ticketId, List<Ticket> listaTickets)
   {
      // Busca un ticket disponible (OnSale) en la lista de tickets
      var ticket = listaTickets.FirstOrDefault( x => x.Id == ticketId && x.Status == StatusTicket.OnSale);

      // Si se encuentra el ticket y está disponible
      if (ticket != null)
      {
         // Cambia el estado del ticket a vendido
         ticket.Status = StatusTicket.Sold;

         // Añade el ticket a la lista de boletos comprados
         boletosComprados.Add(ticket);

         // Muestra un mensaje de confirmación al comprador
         Console.WriteLine($"Boleto comprado {ticket.NombreEvento} por {ticket.Precio}");

         // Muestra todos los boletos comprados por el comprador
         MostrarBoletosComprados();
      }
      else
      {
         // Mensaje de error si el ticket no está disponible o no existe
         Console.WriteLine("Boleto n(o disponible o no existe");
      }
   }

   // Método para mostrar en consola todos los boletos comprados por el comprador
   public void MostrarBoletosComprados()
   {
      // Verifica si el comprador no ha adquirido boletos
      if (boletosComprados.Count == 0)
      {
         Console.WriteLine("No has comprado boletos.");
         return;
      }
      
      // Muestra los detalles de cada boleto comprado
      Console.WriteLine("Boletos Comprados: ");
      foreach (var boleto in boletosComprados)
      {
         Console.WriteLine($"ID: {boleto.Id}, Evento: {boleto.NombreEvento}, Precio: {boleto.Precio}");
      }
   }

   // Método para guardar en un archivo de texto los boletos comprados por el comprador
   public void GuardarBoletosComprados()
   {
      // Genera un nombre de archivo único basado en el ID del comprador
      string fileName = $"boletos_comprador_{this.Id}.txt";

      // Usa StreamWriter para escribir los detalles de los boletos en el archivo
      using (StreamWriter writer = new StreamWriter(fileName))
      {
         // Escribe un encabezado indicando el nombre del comprador
         writer.WriteLine($"Boletos Comprados por {this.Nombre}:");
         foreach (var ticket in boletosComprados)
         {
            writer.WriteLine($"ID: {ticket.Id}, Evento: {ticket.NombreEvento}, Precio: {ticket.Precio}");
         }
      }
      // Confirmación de que el archivo se creó exitosamente.
      Console.WriteLine($"Boletos comprados guardados en el archivo: {fileName}");
   }

   */