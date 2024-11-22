public class Comprador : Usuario
{   
   /* Crear un método que, reciba como parámetro el id del boleto y cambie el status a vendido y muestre los boletos comprados por el usuario comprador */

   private List<Ticket> boletosComprados;

   public Comprador()
   {
      boletosComprados = new List<Ticket>();
   }

   public void ComprarBoleto(int ticketId, List<Ticket> listaTickets)
   {
      var ticket = listaTickets.FirstOrDefault( x => x.Id == ticketId && x.Status == StatusTicket.OnSale);

      if (ticket != null)
      {
         ticket.Status = StatusTicket.Sold;

         boletosComprados.Add(ticket);

         Console.WriteLine($"Boleto comprado {ticket.NombreEvento} por {ticket.Precio}");

         MostrarBoletosComprados();
      }
      else
      {
            Console.WriteLine("Boleto n(o disponible o no existe");
      }
   }

   public void MostrarBoletosComprados()
   {
      if (boletosComprados.Count == 0)
      {
         Console.WriteLine("No has comprado boletos.");
         return;
      }

      Console.WriteLine("Boletos Comprados: ");
      foreach (var boleto in boletosComprados)
      {
         Console.WriteLine($"ID: {boleto.Id}, Evento: {boleto.NombreEvento}, Precio: {boleto.Precio}");
      }
   }

   public void GuardarBoletosComprados()
   {
        string fileName = $"boletos_comprador_{this.Id}.txt";

      using (StreamWriter writer = new StreamWriter(fileName))
      {
         writer.WriteLine($"Boletos Comprados por {this.Nombre}:");
         foreach (var ticket in boletosComprados)
         {
            writer.WriteLine($"ID: {ticket.Id}, Evento: {ticket.NombreEvento}, Precio: {ticket.Precio}");
         }
      }
   }
}