using Backend.TechnicalSupport.Domain.Model.Command;
using Google.Protobuf.WellKnownTypes;

namespace Backend.TechnicalSupport;

public class TechnicalSupport
{
    /// <summary>
    /// Entity Identifier
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Foreign Key
    /// </summary>
    public string TechnicianId { get; set; }
    
    /// <summary>
    /// SupportType that could be Home meeting (If true) or Zoom meeting (If false)
    /// </summary>
    public bool SupportType { get; set; }
    
    /// <summary>
    /// The exact date of the technical support request submitted
    /// </summary>
    public DateTime DateOfRequest { get; set; }
    
    /// <summary>
    /// Meeting Starting Date Range 
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// Meeting Ending Date Range
    /// </summary>
    public DateTime EndDate { get; set; }
   
    protected TechnicalSupport()
    {
        TechnicianId = string.Empty;  
        SupportType = false;
        DateOfRequest = DateTime.Now;
        StartDate = DateTime.Now;
        EndDate = StartDate.AddDays(2);
    }

    public TechnicalSupport(CreateTechnicalSupportCommand command)
    {
        TechnicianId = command.TechnicianId;
        SupportType = command.SupportType;
        DateOfRequest = command.DateOfRequest;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
    }
    
    public void UpdateProperties(UpdateTechnicalSupportCommand command)
    {
        this.TechnicianId = command.TechnicianId;
        this.SupportType = command.SupportType;
        this.DateOfRequest = command.DateOfRequest;
        this.StartDate = command.StartDate;
        this.EndDate = command.EndDate;
    }
}