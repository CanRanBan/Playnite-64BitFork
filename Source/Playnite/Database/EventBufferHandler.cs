using System;

namespace Playnite.Database
{
    public class EventBufferHandler : IDisposable
    {
        private GameDatabase database;

        public EventBufferHandler(GameDatabase db)
        {
            database = db;
            db.BeginBufferUpdate();
        }

        public void Dispose()
        {
            database.EndBufferUpdate();
        }
    }
}
