using crud_system.Models;
using Type = crud_system.Models.Type;
namespace crud_system.Modelview
{
    public class BlogType
    {
        
        public Blog blog { get; set; }
        public List<Type> type { get; set; }


    }
}
