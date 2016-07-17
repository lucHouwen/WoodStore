namespace DatabaseCommunicator.Classes
{
   public class Profile : FloorCovering
    {
        public int ProfileID { get; set; }

        public Profile(string name, Unit unit, decimal priceForUnit,string picture, string type, double length, double width, double height, Color color, bool standard) : base(name, unit, priceForUnit, picture, type, length, width, height, color, standard)   
        { }   
    }
}
