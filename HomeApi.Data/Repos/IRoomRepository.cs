using HomeApi.Data.Models.Home;
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
        /// Получить список имеющихся комнат асинхронно
        /// </summary>
        /// <returns>Список комнат</returns>
        Task<List<Room>> GetRooms();


    }
}
