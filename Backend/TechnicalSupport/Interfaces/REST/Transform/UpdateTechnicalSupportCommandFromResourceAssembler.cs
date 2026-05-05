using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class UpdateTechnicalSupportCommandFromResourceAssembler
{
    public static UpdateTechnicalSupportCommand ToCommandFromResource(int id, UpdateTechnicalSupportResource resource)
    {
        return new UpdateTechnicalSupportCommand
        (
            Id: id,
            TechnicianId: resource.TechnicianId,
            SupportType: resource.SupportType,
            DateOfRequest: resource.DateOfRequest,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate
        );
    }
}