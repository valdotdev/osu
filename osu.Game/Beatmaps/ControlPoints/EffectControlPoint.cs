// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Beatmaps.ControlPoints
{
    public class EffectControlPoint : ControlPoint
    {
        /// <summary>
        /// Whether this control point enables Kiai mode.
        /// </summary>
        public bool KiaiMode;

        /// <summary>
        /// Whether the first bar line of this control point is ignored.
        /// </summary>
        public bool OmitFirstBarLine;

        public override bool Equals(ControlPoint other)
            => base.Equals(other)
               && other is EffectControlPoint effect
               && KiaiMode == effect.KiaiMode
               && OmitFirstBarLine == effect.OmitFirstBarLine;
    }
}
