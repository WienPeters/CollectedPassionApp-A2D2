using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        //createudate
        void SaveEntity(T entity);
        void EmptyTable<T>() where T : new();
        //read1ormore
        T? GetEntity(int id);
        T? GetEntityByName(string name);
        List<T>? GetEntities();
        //delete
        void DeleteEntity(T entity);
        //crud dat gekoppeld te wekr gaat
        void SaveEntityWithChildren(T entity, bool recursive = false);
        void DeleteEntityWithChildren(T entity);
        List<T> GetAllWithKinders(bool recursive = true);
        List<T>? GetEntitiesWithChildren();
        void UpdateEntityWithChildren(T entity);
        
    }
}
