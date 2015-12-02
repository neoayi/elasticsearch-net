using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;
using static Nest.Static;

namespace Tests.QueryDsl.TypeLevel.Type
{
	public class TypeQueryUsageTests : QueryDslUsageTestsBase
	{
		public TypeQueryUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) {}

		protected override object QueryJson => new
		{
			type = new
			{
				_name = "named_query",
				boost = 1.1,
				value = "developer"
			}
		};

		protected override QueryContainer QueryInitializer => new TypeQuery
		{
			Name = "named_query",
			Boost = 1.1,
			Value = Type<Developer>()
		};

		protected override QueryContainer QueryFluent(QueryContainerDescriptor<Project> q) => q
			.Type(c => c
				.Name("named_query")
				.Boost(1.1)
				.Value<Developer>()
			);
	}
}