﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityModel
{
    public class ClaimComparer : IEqualityComparer<Claim>
    {
        public bool Equals(Claim x, Claim y)
        {
            if (x == null && y == null) return true;
            if (x == null && y != null) return false;
            if (x != null && y == null) return false;

            return (x.Type == y.Type &&
                    x.Value == y.Value && 
                    x.Issuer == y.Issuer && 
                    x.ValueType == y.ValueType);
        }

        public int GetHashCode(Claim claim)
        {
            if (Object.ReferenceEquals(claim, null)) return 0;

            int typeHash = claim.Type == null ? 0 : claim.Type.GetHashCode();
            int valueHash = claim.Value == null ? 0 : claim.Value.GetHashCode();

            return typeHash ^ valueHash;
        }
    }
}