using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    public class EditDeviceRequest
    {
        public string NewName { get; set; }
        public string NewLocation { get; set; }
        public string NewModel { get; set; }
        public string NewSerialNumber { get; set; }
        public string NewManufacter { get; set; }
    }
}
