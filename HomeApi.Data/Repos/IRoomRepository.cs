using HomeApi.Data.Models.Home;
using HomeApi.Data.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public interface IRoomRepository
    {
        /// <summary>
        /// добавить комнату (объект класса Room) в БД асинхронно
        /// </summary>
        /// <param name="room">Добавляемая комната</param>
        Task AddRoom(Room room);

        /// <summary>
        /// Получить объект класса Room из БД по названию асинхронно
        /// </summary>
        /// <param name="name">Название комнаты</param>
        /// <returns>Комната с названием, соответствующим name</returns>
        Task<Room> GetRoomByName(string name);

        /// <summary>
        /// Получить объект класса Room из БД по id асинхронно
        /// </summary>
        /// <param name="id">Идентификатор комнаты</param>
        /// <returns>Комната с идентификатором, соответствующим id</returns>
        Task<Room> GetRoomById(Guid id);


        /// <summary>
        /// Получить список имеющихся комнат асинхронно
        /// </summary>
        /// <returns>Список комнат</returns>
        Task<List<Room>> GetRooms();

        /// <summary>
        /// Обновить комнату
        /// </summary>
        /// <param name="room">Модель комнаты</param>
        /// <param name="query">Запр</param>
        /// <returns></returns>
        Task UpdateRoom(Room room, UpdateRoomQuery query);


    }
}
