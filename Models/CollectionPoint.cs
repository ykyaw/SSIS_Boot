using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class CollectionPoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string CollectionTime { get; set; }

        public CollectionPoint() { }
        public CollectionPoint(string Location, string CollectionTime)
        {
            this.Location = Location;
            this.CollectionTime = CollectionTime;
        }
    }
}
