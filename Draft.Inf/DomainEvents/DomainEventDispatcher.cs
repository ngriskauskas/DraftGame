using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;

namespace Draft.Inf.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private IComponentContext _container;

        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }


        public void Dispatch(DomainEvent domainEvent)
        {
            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            IEnumerable handlers = (IEnumerable)_container
                .Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));

            IEnumerable<DomainEventHandler> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (DomainEventHandler)Activator.CreateInstance(wrapperType, handler));

            foreach (var handler in wrappedHandlers)
                handler.Handle(domainEvent);
        }

        private abstract class DomainEventHandler
        {
            public abstract void Handle(DomainEvent domainEvent);
        }

        private class DomainEventHandler<T> : DomainEventHandler where T : DomainEvent
        {
            private readonly IHandle<T> _handler;

            public DomainEventHandler(IHandle<T> handler)
            {
                _handler = handler;
            }

            public override void Handle(DomainEvent domainEvent)
            {
                _handler.Handle((T)domainEvent);
            }
        }
    }
}