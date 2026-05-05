using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class CreateTechnicalSupportCommandFromResourceAssembler
{
    public static CreateTechnicalSupportCommand ToCommandFromResource(CreateTechnicalSupportResource resource)
    {
        return new CreateTechnicalSupportCommand(resource.TechnicianId, resource.SupportType, resource.DateOfRequest, resource.StartDate, resource.EndDate);
    }
}