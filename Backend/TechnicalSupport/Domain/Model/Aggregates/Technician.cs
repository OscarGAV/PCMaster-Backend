using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Model.Aggregates;

public class Technician
{
    /// <summary>
    /// Entity Identifier
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Technician Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Technician Status could be available (if true) or unavailable (if false)
    /// </summary>
    public bool Status { get; set; }
    
    /// <summary>
    /// Photo Image of the technician
    /// </summary>
    public string Img { get; set; }
   
    protected Technician()
    {
        Name = string.Empty;
        Status = false;  
        Img = string.Empty;
    }

    public Technician(CreateTechnicianCommand command)
    {
        Name = command.Name;
        Status = command.Status;
        Img = command.Img;
    }
    
    public void UpdateProperties(UpdateTechnicianCommand command)
    {
        this.Name = command.Name;
        this.Status = command.Status;
        Img = command.Img;
    }
}