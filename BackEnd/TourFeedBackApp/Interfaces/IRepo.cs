﻿namespace TourFeedBackApp.Interfaces
{
    public interface IRepo<K, T>
    {
        public Task<T> Add(T item);
        public Task<T> Delete(K key);

        public Task<ICollection<T>> GetAll();
    }
}
