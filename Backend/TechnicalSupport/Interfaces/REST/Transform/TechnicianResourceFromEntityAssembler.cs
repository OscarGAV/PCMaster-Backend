using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform
{
    public class TechnicianResourceFromEntityAssembler
    {
        public static TechnicianResource ToResourceFromEntity(Technician entity)
        {
            // Round the Stars property to the desired number of decimal places (e.g., 1)
            double roundedStars = Math.Round(entity.Stars, 1);
            
            return new TechnicianResource(entity.Id, entity.Name, entity.Status, roundedStars, entity.Img);
        }
    }
}