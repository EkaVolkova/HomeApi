using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Models.Home;
using HomeApi.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Добавить устройство в БД асинхронно
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="room">Комната</param>
        Task AddDevice(Device device, Room room);

        /// <summary>
        /// Получить список всех устройств в БД
        /// </summary>
        /// <returns>Список устройств</returns>
        Task<List<Device>> GetDevices();

        /// <summary>
        /// Получить устройство из БД по ID
        /// </summary>
        /// <param name="id">ID устройства</param>
        /// <returns>устройство</returns>
        Task<Device> GetDeviceById(Guid id);

        /// <summary>
        /// Получить устройство из БД по названию
        /// </summary>
        /// <param name="name">Название устройства</param>
        /// <returns>устройство</returns>
        Task<Device> GetDeviceByName(string name);

        /// <summary>
        /// Обновить устройство
        /// </summary>
        /// <param name="device">Модель устройства</param>
        /// <param name="room">Модель комнаты</param>
        /// <returns></returns>
        Task UpdateDevice(Device device, Room room, UpdateDeviceQuery updateDevieceQuery);

        /// <summary>
        /// Удалить устройство
        /// </summary>
        /// <param name="device">Модель устройства</param>
        /// <returns></returns>
        Task DeleteDevice(Device device);


    }
}
