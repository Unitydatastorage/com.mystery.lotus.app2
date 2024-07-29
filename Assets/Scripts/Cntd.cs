using System;
using System.Collections.Generic;

public class Cntd
{
        private static Cntd _instance;
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static Cntd Instance => _instance ??= new Cntd();
        
        private Cntd()
        {
        }

        public void Register<TContract>(TContract obj)
        {
                var key = typeof(TContract);
                
                if (_services.ContainsKey(key))
                        throw new ArgumentException($"{key} instance is already registered");

                _services[key] = obj;
        }

        public TContract Get<TContract>()
        {
                var key = typeof(TContract);

                if (!_services.ContainsKey(key))
                        throw new ArgumentException($"{key} is not registered");

                return (TContract) _services[key];
        }

        public TContract Unregister<TContract>()
        {
                var obj = Get<TContract>();

                _services.Remove(typeof(TContract));

                return obj;
        }
}