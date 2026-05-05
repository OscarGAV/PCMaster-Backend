using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class CreateTechnicianCommandFromResourceAssembler
{
    public static CreateTechnicianCommand ToCommandFromResource(CreateTechnicianResource resource)
    {
        return new CreateTechnicianCommand(resource.Name, resource.Status, resource.Stars, resource.Img);
    }
}