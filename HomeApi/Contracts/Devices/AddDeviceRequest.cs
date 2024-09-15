using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        /// <summary>
        /// Название устройства (обязательное поле)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Производитель устройства (обязательное поле)
        /// </summary>
        [Required]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Модель устройства (обязательное поле)
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Серийный номер устройства (обязательное поле)
        /// </summary>
        [Required]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Напряжение питания устройства (обязательное поле)
        /// </summary>
        [Required]
        public int CurrentVolts { get; set; }

        /// <summary>
        /// Работает ли на газу (обязательное поле)
        /// </summary>
        [Required]
        public bool GasUsage { get; set; }

        /// <summary>
        /// Расположение устройства (обязательное поле)
        /// </summary>
        [Required]
        public string Location { get; set; }
    }
}
