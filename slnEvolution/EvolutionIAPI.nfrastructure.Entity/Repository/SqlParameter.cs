namespace EvolutionAPI.Infrastructure.Entity.Repository
{
    internal class SqlParameter
    {
        public string ParameterName { get; set; }
        public object DbType { get; set; }
        public object Value { get; set; }
        public object SqlValue { get; set; }
    }
}