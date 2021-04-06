using Cds.Foundation.Test.Pact.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cds.BusinessCustomer.Tests.ConsumerPact
{
    public class BusinessCustomerConsumer : BaseConsumer
    {
        public BusinessCustomerConsumer() : base(new Uri("http://a01pacbro.cdweb.biz/"), "BusinessCustomer", "BusinessCustomerConsumer", "master", false) { }
    }
}
