using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class PortsModel
    {
        public virtual int portId { get; set; }
        public virtual string portName { get; set; }
        public virtual string ctyCode { get; set; }
        public virtual string locationCode { get; set; }
        public virtual string alsoCalled { get; set; }
        public virtual Decimal portLatd { get; set; }
        public virtual Decimal portLond { get; set; }
        public virtual Boolean active { get; set; }

        public PortsModel() { }

        public PortsModel(Ports ports)
        {
            this.portId  = ports.PortId ;
            this.portName = ports. PortName;
            this.ctyCode = ports. CtyCode;
            this.locationCode = ports. LocationCode;
            this.alsoCalled = ports.AlsoCalled;
            this.portLatd = ports.PortLatd;
            this.portLond = ports.PortLond;
            this.active = ports.Active;

        }
    }
}