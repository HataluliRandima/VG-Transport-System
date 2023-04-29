namespace VG_TransportAPI.DTO.Car
{
    public class AddCar
    {

       

        public string CrName { get; set; } = null!;

        public string? CrModel { get; set; }

        public string? CrType { get; set; }

        public string? CrRegPlate { get; set; }


        //usage for documents of car
        public string? CrPaper1 { get; set; }

        //Usage of status of car to be verified
        public string? CrPaper2 { get; set; }


        //Usage of status to see if the car its availabe for delivery
        public string? CrDescription { get; set; }

        
    }
}
