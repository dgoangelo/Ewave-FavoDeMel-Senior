﻿using MediatR;

namespace FavoDeMel.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}