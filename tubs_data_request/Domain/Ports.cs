using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class Ports
    {
        public virtual int PortId { get; set; }
        public virtual String PortName { get; set; }
        public virtual String CtyCode { get; set; }
        public virtual String LocationCode { get; set; }
        public virtual String AlsoCalled { get; set; }
        public virtual Decimal PortLatd { get; set; }
        public virtual Decimal PortLond { get; set; }
        public virtual Boolean Active { get; set; }
    }
}