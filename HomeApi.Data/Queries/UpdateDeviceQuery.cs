using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновлении устройства
    /// </summary>
    public class UpdateDeviceQuery
    {
        public string NewName { get; }
        public string NewSerial { get; }
        public string NewModel { get; set; }
        public string NewManufacter { get; set; }

        public UpdateDeviceQuery(string newName = null, 
                                 string newSerial = null,
                                 string newModel = null,
                                 string newManufactor = null)
        {
            NewName = newName;
            NewSerial = newSerial;
            NewManufacter = newManufactor;
            NewModel = newModel;
        }
    }
}
