using Swashbuckle.AspNetCore.SwaggerGen;

namespace EvolutionAPI.Service
{
    public class MultipleOperationsWithSameVerbFilter : IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters != null)
            {
                operation.OperationId += "By";

                foreach (var parm in operation.Parameters)
                {
                    operation.OperationId += string.Format("{0}", parm.Name);
                }
            }
        }
    }
}
