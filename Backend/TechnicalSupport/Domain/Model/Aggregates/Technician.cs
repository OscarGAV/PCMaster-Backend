using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport;

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
    /// Stars Quantity (maximum could be five stars)
    /// </summary>
    public double Stars { get; set; }
    
    /// <summary>
    /// Photo Image of the technician
    /// </summary>
    public string Img { get; set; }
   
    protected Technician()
    {
        Name = string.Empty;
        Status = false;  
        Stars = 0.0;
        Img = string.Empty;
    }

    public Technician(CreateTechnicianCommand command)
    {
        Name = command.Name;
        Status = command.Status;
        this.setRating(command.Stars);
        Img = command.Img;
    }
    
    public void UpdateProperties(UpdateTechnicianCommand command)
    {
        this.Name = command.Name;
        this.Status = command.Status;
        this.setRating(command.Stars);
        Img = command.Img;
    }
    
    // Validation methods
    public void setRating(double stars) {
        if (stars < 0.0 || stars > 5.0) {
            throw new ArgumentOutOfRangeException(nameof(stars), "Stars must be between 0 and 5.");
        }
        this.Stars = stars;
    }
}