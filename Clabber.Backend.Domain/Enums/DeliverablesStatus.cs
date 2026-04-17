namespace Clabber.Backend.Domain.Enums
{
    /// <summary>
    /// Represents the current lifecycle stage of a campaign deliverable.
    /// </summary>
    public enum DeliverablesStatus
    {
        // Initial state when the contract is signed but work hasn't started
        NotStarted = 0,

        // Creator is currently working on the asset
        InProgress = 1,

        // Asset has been uploaded and is waiting for the Buyer to review it
        PendingReview = 2,

        // Buyer requested changes or edits to the submitted work
        RevisionRequired = 3,

        // Work is finished and approved by the Buyer
        Completed = 4,

        // The deliverable was cancelled (e.g., due to a dispute or change in campaign scope)
        Cancelled = 5,

        // The deadline has passed and the asset was not submitted
        Overdue = 6
    }
}
