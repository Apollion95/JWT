namespace JWT.DTO
{

    public class UpdateProductDTO
    {
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
