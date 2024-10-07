using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Models.Home;
using HomeApi.Data.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public class DeviceRepository : IDeviceRepository
    {
        HomeApiContext _context;
        public DeviceRepository(HomeApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавить устройство в БД асинхронно
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="room">Комната</param>
        public async Task AddDevice(Device device, Room room)
        {
            //Добавляем идентификатор комнаты и комнату к устройству
            device.RoomId = room.Id;
            device.Room = room;

            //Добавляем устройство в асинхронном режиме
            var entry = _context.Entry(device);
            if (entry.State == EntityState.Detached)
                await _context.Devices.AddAsync(device);

            // Сохраняем изменения в базе 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDevice(Device device)
        {
            // Удаление 
            _context.Devices.Remove(device);

            // Сохранение изменений
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Получить список всех устройств в БД
        /// </summary>
        /// <returns>Список устройств</returns>
        public async Task<Device> GetDeviceById(Guid id)
        {
            //Получаем устройство вместе с объектом комнаты, в которых они расположены
            return await _context.Devices
                .Include(d => d.Room)
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получить устройство из БД по ID
        /// </summary>
        /// <param name="id">ID устройства</param>
        /// <returns>устройство</returns>
        public async Task<Device> GetDeviceByName(string name)
        {
            //Получаем устройство вместе с объектом комнаты, в которых они расположены
            return await _context.Devices
                .Include(d => d.Room)
                .Where(d => d.Name == name)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получить список всех устройств в БД
        /// </summary>
        /// <returns>Список устройств</returns>
        public async Task<List<Device>> GetDevices()
        {
            //Получаем устройства вместе с объектам комнат, в которых они расположены
            return await _context.Devices
                .Include(d => d.Room)
                .ToListAsync();
        }

        public async Task UpdateDevice(Device device, Room room, UpdateDeviceQuery updateDevieceQuery)
        {
            device.Room = room;
            device.RoomId = room.Id;

            if (!string.IsNullOrEmpty(updateDevieceQuery.NewName))
                device.Name = updateDevieceQuery.NewName;

            if (!string.IsNullOrEmpty(updateDevieceQuery.NewModel))
                device.Model = updateDevieceQuery.NewModel;

            if (!string.IsNullOrEmpty(updateDevieceQuery.NewSerial))
                device.SerialNumber = updateDevieceQuery.NewSerial;

            if (!string.IsNullOrEmpty(updateDevieceQuery.NewManufacter))
                device.Manufacturer = updateDevieceQuery.NewManufacter;

            // Обновление 
            var entry = _context.Entry(device);
            if (entry.State == EntityState.Detached)
                _context.Devices.Update(device);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }
    }
}
