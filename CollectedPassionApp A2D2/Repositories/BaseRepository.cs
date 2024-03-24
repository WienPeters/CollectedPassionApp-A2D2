using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectedPassionApp_A2D2.Abstractions;
using CollectedPassionApp_A2D2.MVVM.Models;


namespace CollectedPassionApp_A2D2.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }
        public BaseRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.flags);
            //EmptyTable<T>();
            connection.CreateTable<T>();
        }
        public void EmptyTable<T>() where T : new()
        {
            connection.DeleteAll<T>();
        }
        public void DeleteEntity(T entity)
        {
            try
            {

                connection.Delete(entity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeleteEntityWithChildren(T entity)
        {
            try
            {
                connection.Delete(entity, true);

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public List<T> GetEntities()
        {
            try
            {
                return connection.Table<T>().ToList();

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetEntitiesWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public T GetEntity(int id)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void SaveEntity(T entity)
        {
            int result = 0;
            if (entity != null)
            {
                try
                {
                    if (entity.Id != 0)
                    {
                        result = connection.Update(entity);
                        StatusMessage = $"{result} row(s) updated";
                    }
                    else
                    {
                        result = connection.Insert(entity);
                        StatusMessage = $"{result} row(s) added";
                    }

                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error: {ex.Message}";
                }
            }
        }

        public void SaveEntityWithChildren(T entity, bool recursive = false)
        {
            connection.InsertWithChildren(entity, recursive);
        }

        public void UpdateEntityWithChildren(T entity)
        {
            try
            {
                connection.UpdateWithChildren(entity);
                StatusMessage = "Entity updated with children";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }


    }
}

