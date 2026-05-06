using Backend.TechnicalSupport.Domain.Model.Aggregates;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform
{
    public static class TechnicianResourceFromEntityAssembler
    {
        public static TechnicianResource ToResourceFromEntity(Technician entity, double? averageRating = null)
        {
            return new TechnicianResource(entity.Id, entity.Name, entity.Status, averageRating, entity.Img);
        }
    }
}