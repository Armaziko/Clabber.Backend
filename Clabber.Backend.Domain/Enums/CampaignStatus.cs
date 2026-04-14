namespace Clabber.Backend.Domain.Enums
{
    public enum CampaignStatus
    {
        // The campaign is being created but not yet visible to creators
        Draft = 1,

        // Waiting for the platform admin or a payment verification
        PendingReview = 2,

        // Live and accepting applications/offers from creators
        Active = 3,

        // The budget is exhausted or the buyer manually stopped it
        Paused = 4,

        // The campaign has reached its end date or goal
        Completed = 5,

        // Cancelled by the buyer (usually before any collaborations started)
        Cancelled = 6,

        // For cases where a campaign is flagged for policy violations
        Archived = 7
    }
}
