using BeyondNetCode.Shell.Ddd.Interfaces;
using BeyondNetCode.Shell.Ddd.Services.Impl;

namespace BeyondNetCode.Shell.Ddd.Services.Interfaces
{
    public interface ITrackingStateManager
    {
        bool IsDeleted { get; }
        bool IsDirty { get; }
        bool IsNew { get; }
        bool IsSelfDeleted { get; }

        TrackingStateManager GetTracking<TProp>(TProp props) where TProp : IProps;
        void MarkAsClean();
        void MarkAsDeleted();
        void MarkAsDirty();
        void MarkAsNew();
        void MarkAsSelfDeleted();
    }
}