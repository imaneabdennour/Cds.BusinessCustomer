using Cds.Foundation.Test.Pact.Consumer;
using System;

namespace Cds.BusinessCustomer.Tests.ConsumerPact
{
	/// <summary>
	/// Defines the Parameter Manager consumer
	/// </summary>
	public class BusinessCustomerConsumer : BaseConsumer
	{
		//private readonly int _servicePort = 9222;
		/// <summary>
		/// 
		/// </summary>
		public BusinessCustomerConsumer() : base(
			new Uri($"http://localhost:9222"),
			"CustomerApi",
			"CustomerWeb",
			"master",
			false)
		{ }
	}
}