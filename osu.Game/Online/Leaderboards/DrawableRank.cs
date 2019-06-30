﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Extensions;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics;
using osu.Game.Graphics.Backgrounds;
using osu.Game.Graphics.Sprites;
using osu.Game.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Online.Leaderboards
{
    public class DrawableRank : CompositeDrawable
    {
        private readonly ScoreRank rank;

        public DrawableRank(ScoreRank rank)
        {
            this.rank = rank;

            RelativeSizeAxes = Axes.Both;
            FillMode = FillMode.Fit;
            FillAspectRatio = 2;

            var rankColour = getRankColour();
            InternalChild = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(64, 32),
                Strategy = DrawSizePreservationStrategy.Minimum,
                Child = new CircularContainer
                {
                    Masking = true,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = rankColour,
                        },
                        new Triangles
                        {
                            RelativeSizeAxes = Axes.Both,
                            ColourDark = rankColour.Darken(0.1f),
                            ColourLight = rankColour.Lighten(0.1f),
                            TriangleScale = 1,
                            Velocity = 0.25f,
                        },
                        new OsuSpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Padding = new MarginPadding { Top = 5 },
                            Colour = getRankNameColour(),
                            Font = OsuFont.GetFont(Typeface.Venera, 25),
                            Text = getRankName(),
                        },
                    }
                }
            };
        }

        private string getRankName() => rank.GetDescription().TrimEnd('+');

        /// <summary>
        ///  Retrieves the grade background colour.
        /// </summary>
        private Color4 getRankColour()
        {
            switch (rank)
            {
                case ScoreRank.XH:
                case ScoreRank.X:
                    return OsuColour.FromHex(@"ce1c9d");

                case ScoreRank.SH:
                case ScoreRank.S:
                    return OsuColour.FromHex(@"00a8b5");

                case ScoreRank.A:
                    return OsuColour.FromHex(@"7cce14");

                case ScoreRank.B:
                    return OsuColour.FromHex(@"e3b130");

                case ScoreRank.C:
                    return OsuColour.FromHex(@"f18252");

                default:
                    return OsuColour.FromHex(@"e95353");
            }
        }

        /// <summary>
        ///  Retrieves the grade text colour.
        /// </summary>
        private ColourInfo getRankNameColour()
        {
            switch (rank)
            {
                case ScoreRank.XH:
                case ScoreRank.SH:
                    return ColourInfo.GradientVertical(Color4.White, OsuColour.FromHex("afdff0"));

                case ScoreRank.X:
                case ScoreRank.S:
                    return ColourInfo.GradientVertical(OsuColour.FromHex(@"ffe7a8"), OsuColour.FromHex(@"ffb800"));

                case ScoreRank.A:
                    return OsuColour.FromHex(@"275227");

                case ScoreRank.B:
                    return OsuColour.FromHex(@"553a2b");

                case ScoreRank.C:
                    return OsuColour.FromHex(@"473625");

                default:
                    return OsuColour.FromHex(@"512525");
            }
        }
    }
}
