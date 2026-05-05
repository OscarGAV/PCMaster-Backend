using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class UpdateTechnicianCommandFromResourceAssembler
{
    public static UpdateTechnicianCommand ToCommandFromResource(int id, UpdateTechnicianResource resource)
    {
        return new UpdateTechnicianCommand
        (
            Id: id,
            Name: resource.Name,
            Status: resource.Status,
            Stars: resource.Stars,
            Img: resource.Img
        );
    }
}