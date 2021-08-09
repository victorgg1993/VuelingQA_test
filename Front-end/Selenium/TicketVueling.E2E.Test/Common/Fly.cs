namespace TicketVueling.E2E.Test
{
    public class Fly
    {
        public int origin_time {get; set;}

        public int destiny_time {get; set;}

        public int price {get; set;}
        
        public string company {get; set;} // to-do => make a company enum | interface
    }
}