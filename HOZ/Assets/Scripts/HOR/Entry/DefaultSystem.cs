using System;
using System.Collections.Generic;

namespace HOR.Entry
{
    public class DefaultSystem
    {
        List<ISubSystem> subSystems = new List<ISubSystem>();

        public void AddSubSystem(ISubSystem system)
        {
            if (system == null)
                throw new NullReferenceException("Subsystem is null ");
            subSystems.Add(system);
        }

        public void StartUp()
        {
            foreach (var system in subSystems)
                system.StartUp();
        }

        public void ShutDown()
        {
            foreach (var system in subSystems)
                system.ShutDown();
        }

        public T GetSubSytem<T>() where T : ISubSystem
        {
            foreach (var system in subSystems)
                if (system.GetType() == typeof(T))
                    return (T) system;

            throw new AggregateException(String.Format("Sub system of type '{0}' is not defined", typeof(T)));
        }
    }

    public interface ISubSystem
    {
        void StartUp();
        void ShutDown();
    }
}