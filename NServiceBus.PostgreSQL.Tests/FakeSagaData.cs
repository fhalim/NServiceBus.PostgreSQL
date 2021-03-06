﻿namespace NServiceBus.PostgreSQL.Tests
{
    using System;
    using NServiceBus.Saga;

    public class BiggerSagaData : ContainSagaData
    {
        [Unique] public string MyId { get; set; }

        public int MyInteger { get; set; }
        public Guid MyGuid { get; set; }
        public DateTime MyDateTime { get; set; }
    }

    public class FakeSagaData:ContainSagaData
    {
        protected bool Equals(FakeSagaData other)
        {
            return CorrelationId == other.CorrelationId && string.Equals(Message, other.Message);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FakeSagaData) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CorrelationId*397) ^ (Message != null ? Message.GetHashCode() : 0);
            }
        }

        [Unique]
        public virtual int CorrelationId { get; set; }

        [Unique]
        public virtual int MyOtherId { get; set; }

        // all other properties you want persisted
        public virtual string Message { get; set; }
    }
}