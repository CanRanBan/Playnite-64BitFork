﻿using System;
using System.Collections.Generic;
using System.Linq;
using Playnite.SDK;
using Playnite.SDK.Models;

namespace Playnite.Database
{
    public class AgeRatingsCollection : ItemCollection<AgeRating>
    {
        private readonly GameDatabase db;

        public AgeRatingsCollection(GameDatabase database, LiteDB.BsonMapper mapper) : base(mapper, type: GameDatabaseCollection.AgeRatings)
        {
            db = database;
        }

        public static void MapLiteDbEntities(LiteDB.BsonMapper mapper)
        {
            mapper.Entity<AgeRating>().Id(a => a.Id, false);
        }

        private void RemoveUsage(Guid ageRatingId)
        {
            foreach (var game in db.Games.Where(a => a.AgeRatingIds?.Contains(ageRatingId) == true))
            {
                game.AgeRatingIds.Remove(ageRatingId);
                db.Games.Update(game);
            }
        }

        public override bool Remove(AgeRating itemToRemove)
        {
            RemoveUsage(itemToRemove.Id);
            return base.Remove(itemToRemove);
        }

        public override bool Remove(Guid id)
        {
            RemoveUsage(id);
            return base.Remove(id);
        }

        public override bool Remove(IEnumerable<AgeRating> itemsToRemove)
        {
            if (itemsToRemove.HasItems())
            {
                foreach (var item in itemsToRemove)
                {
                    RemoveUsage(item.Id);
                }
            }
            return base.Remove(itemsToRemove);
        }
    }
}
