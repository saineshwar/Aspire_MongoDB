namespace AspireApp6.ApiService.Models;

public class ProductRequest
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int? CategoryID { get; set; }
    public string ImageUrl { get; set; }
}