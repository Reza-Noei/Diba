using System;
using Diba.Core.Common;

namespace Diba.Core.Domain
{
    public class CollectionInfo
    {
        public int? CollectorId { get; private set; }

        public DateTime? CollectionDate { get; private set; }

        public string CollectionLocation { get; private set; }

        private CollectionInfo(int? collectorId, DateTime? collectionDate, string collectionLocation)
        {
            this.CollectorId = collectorId;
            this.CollectionDate = collectionDate;
            this.CollectionLocation = collectionLocation;
        }

        public static CollectionInfo Create(int? collectorId, DateTime? collectionDate, string collectionLocation)
        {
            return new CollectionInfo(collectorId, collectionDate, collectionLocation);
        }

        public bool IsComplete => !this.CollectorId.IsNullOrValue(0) && this.CollectionDate.HasValue && !String.IsNullOrEmpty(this.CollectionLocation);
    }
}