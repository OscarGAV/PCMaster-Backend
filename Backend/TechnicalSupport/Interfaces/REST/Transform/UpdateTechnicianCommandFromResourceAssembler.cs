using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public static class UpdateTechnicianCommandFromResourceAssembler
{
    public static UpdateTechnicianCommand ToCommandFromResource(int id, UpdateTechnicianResource resource)
    {
        return new UpdateTechnicianCommand
        (
            Id: id,
            Name: resource.Name,
            Status: resource.Status,
            Img: resource.Img
        );
    }
}