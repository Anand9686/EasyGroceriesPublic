namespace GroceryWebApp.Pages.Categories.Model
{
    public class CategoryProduct
    {
        public int Id { get; set; }        
        public string CategoryName { get; set; }        
        public string CategoryDescr { get; set; }
        public int CategoryParent { get; set; }
        public bool Flag { get; set; }
    }
}
