﻿using System.Collections.Generic;

namespace Battle.Weapons
{
    public struct DamageMessage
    {
        int value;
        IEnumerable<DamageType> types;

        public int Value => value;
        public IEnumerable<DamageType> Types => types;

        public static DamageMessage Create(int dmg, params DamageType[] dmgTypes) => new DamageMessage
        {
            value = dmg,
            types = dmgTypes
        };

        public static DamageMessage Create(DamageMessage source, float multiplier) => new DamageMessage
        {
            value = (int)(source.value * multiplier),
            types = source.types
        };
    }
}
