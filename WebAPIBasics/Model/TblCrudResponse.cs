namespace WebAPIBasics.Model;

public class TblCrudResponse
{
    public int Id { get; set; }        
    public string Name { get; set; }        
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
}
