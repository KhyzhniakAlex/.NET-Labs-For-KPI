using DataAccess.Models;
using System.Collections.Generic;

namespace Services.Serialization
{
    public interface ISerialization
    {
        bool SerializeEntity<Entity>(Entity entity, string path);
        List<Entity> DeserizalizeEntity<Entity>(string path);
    }
}
