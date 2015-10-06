﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	public partial interface IDeleteByQueryRequest 
	{
		[JsonProperty("query")]
		IQueryContainer Query { get; set; }
	}

	public interface IDeleteByQueryRequest<T> : IDeleteByQueryRequest where T : class { }

	public partial class DeleteByQueryRequest 
	{
		public IQueryContainer Query { get; set; }

	}
	
	public partial class DeleteByQueryRequest<T> : IDeleteByQueryRequest<T>
		where T : class
	{
		public IQueryContainer Query { get; set; }
	}

	public partial class DeleteByQueryDescriptor<T> : IDeleteByQueryRequest<T>
		where T : class
	{
		IQueryContainer IDeleteByQueryRequest.Query { get; set; }

		public DeleteByQueryDescriptor<T> MatchAll() => Assign(a => a.Query = new QueryContainerDescriptor<T>().MatchAll());

		public DeleteByQueryDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) =>
			Assign(a => a.Query = querySelector?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
