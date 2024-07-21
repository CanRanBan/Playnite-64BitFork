using System;
using System.Collections.Generic;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;

namespace Playnite
{
    public class FakePlayniteLibraryPlugin : LibraryPlugin
    {
        public override string Name => "Playnite";

        public override Guid Id => Guid.Empty;

        public FakePlayniteLibraryPlugin() : base(null)
        {
        }

        public override IEnumerable<GameMetadata> GetGames(LibraryGetGamesArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
