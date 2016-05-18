using System;
using System.Linq;
using System.Reflection;

namespace Halcyon.HAL.Attributes {
    public class HALAttributeConverter : IHALConverter {
        public bool CanConvert(Type type) {
            if(type == null || type == typeof(HALResponse)) {
                return false;
            }

            // Is it worth caching this check?
            return type.GetTypeInfo().GetCustomAttributes<HalModelAttribute>().Any();
        }

        public HALResponse Convert(object model) {
            if(!this.CanConvert(model?.GetType())) {
                throw new InvalidOperationException();
            }

            var resolver = new HALAttributeResolver();

            var halConfig = resolver.GetConfig(model);

            var response = new HALResponse(model, halConfig);
            response.AddLinks(resolver.GetLinks(model));
            response.AddEmbeddedCollections(resolver.GetEmbeddedCollections(model, halConfig));

            return response;
        }
    }
}