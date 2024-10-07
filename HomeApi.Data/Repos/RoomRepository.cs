using HomeApi.Data.Models;
using HomeApi.Data.Models.Home;
using HomeApi.Data.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public class RoomRepository : IRoomRepository
    {
        HomeApiContext _context;
        public RoomRepository(HomeApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// добавить комнату (объект класса Room) в БД асинхронно
        /// </summary>
        /// <param name="room">Добавляемая комната</param>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить объект класса Room из БД по id асинхронно
        /// </summary>
        /// <param name="id">Идентификатор комнаты</param>
        /// <returns>Комната с идентификатором, соответствующим id</returns>
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Получить объект класса Room из БД по названию асинхронно
        /// </summary>
        /// <param name="name">Название комнаты</param>
        /// <returns>Комната с названием, соответствующим name</returns>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Получить список имеющихся комнат асинхронно
        /// </summary>
        /// <returns>Список комнат</returns>
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
                .Include(d => d.Devices)
                .ToListAsync();
        }

        /// <summary>
        /// Обновить комнату
        /// </summary>
        /// <param name="room">Модель комнаты</param>
        /// <param name="query">Запр</param>
        /// <returns></returns>
        public async Task UpdateRoom(Room room, UpdateRoomQuery query)
        {

            if (!string.IsNullOrEmpty(query.NewName))
                room.Name = query.NewName;

            if (query.NewArea != null)
                room.Area = (int)query.NewArea;

            if (query.NewGasConnected != null)
                room.GasConnected = (bool)query.NewGasConnected;

            if (query.NewVoltage != null)
                room.Voltage = (int)query.NewVoltage;

            // Обновление 
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(room);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        
        }
    }
}
