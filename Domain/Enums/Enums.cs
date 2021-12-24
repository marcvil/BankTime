namespace BankTimeApp.Domain.Enums
{
    public class Enums
    {
        public enum TaskState
        {
            Open = 0,
            InProcess = 1,
            Completed = 2
        }

        public enum RequestState
        {
            //Estado default de la solicitud, estado aceptada, estado denegada, 
            //por ahora no s eme ocurre mas
            OpenRequest = 0,
            Accepted = 1,
            Denied = 2
        }

        public enum ExchangeState
        {
            //tarea no devuelta
            //Intercambio ya devuelto
            NotReturned = 0,
            Returned = 1
        }
    }
}
