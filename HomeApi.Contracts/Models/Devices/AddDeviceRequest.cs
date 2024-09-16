using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        /// <summary>
        /// Название устройства (обязательное поле)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Производитель устройства (обязательное поле)
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Модель устройства (обязательное поле)
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Серийный номер устройства (обязательное поле)
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Напряжение питания устройства (обязательное поле)
        /// </summary>
        public int CurrentVolts { get; set; }

        /// <summary>
        /// Работает ли на газу (обязательное поле)
        /// </summary>
        public bool GasUsage { get; set; }

        /// <summary>
        /// Расположение устройства (обязательное поле)
        /// </summary>
        public string Location { get; set; }
    }
}
