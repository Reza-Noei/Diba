﻿using System;

namespace Diba.Core.Domain
{
    public abstract class OrderState
    {
        public virtual bool ItemsCanModify()
        {
            return false;
        }

        public virtual bool CollectionInfoCanModify()
        {
            return false;
        }

        public virtual bool DeliveryInfoCanModify()
        {
            return false;
        }

        public virtual OrderState Collect()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Calculate()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Process()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Deliver()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Balance()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Cancel()
        {
            throw new NotSupportedException();
        }
    }
}